using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using _2DDistancing.Code;
using System.Diagnostics;

namespace _2DDistancing.Form_Code
{
    class Form_Data
    {
        

        LookupTable Data = new LookupTable("LookupTable.sdf");
        ComPort x_Reader = new ComPort("COM4");
        ComPort y_Reader = new ComPort("COM5");
        Distancing x_AVG =null;
        Distancing x_DFT = null;
        Distancing y_AVG =null;
        Distancing y_DFT = null;
            
        //Xside
        public static int x_interval = 10;
        public static int x_start = 50;
        public static int x_end = 150;
        public static int x_number_of_datapoints = (x_end - x_start) / x_interval;
        //Y side 
        public static int y_interval = x_interval;
        public static int y_start = x_start;
        public static int y_end = x_end;
        public static int y_number_of_datapoints = (y_end - y_start) / y_interval;

        public static int Configutation_num_reads = 64;


        #region Draw
        private static System.Drawing.Pen background = new System.Drawing.Pen(Color.Black, 2F);
        private static System.Drawing.SolidBrush tag1 = new System.Drawing.SolidBrush(Color.Green);
        private static System.Drawing.SolidBrush tag2 = new System.Drawing.SolidBrush(Color.Blue);



        public static void Create_Grid(Graphics g, Size Canvas)
        {
            g.Clear(Color.White);
            int x_scale = Canvas.Width/x_number_of_datapoints;
            int y_scale = Canvas.Height/y_number_of_datapoints;
            for (int i = 0; i < x_number_of_datapoints; i++)
            {
                int x_height = i*x_scale;
                g.DrawLine(background, x_height, 0, x_height, Canvas.Height);
            }
            for (int i = 0; i < y_number_of_datapoints; i++)
            {
                int y_height = i * y_scale;
                g.DrawLine(background, 0, y_height, Canvas.Width, y_height);
            }
           
        }

        private static int diamater = 15;

        public static void AddTag1(Graphics g, int x_pos, int y_pos,Size Canvas)
        {
            int x_scale = Canvas.Width / x_number_of_datapoints;
            int y_scale = Canvas.Height / y_number_of_datapoints;

            g.FillEllipse(tag1, (x_scale * x_pos)-diamater/2, (y_pos * y_scale)-diamater/2, diamater, diamater);

        }

        public static void AddTag2(Graphics g, int x_pos, int y_pos, Size Canvas)
        {
            int x_scale = Canvas.Width / x_number_of_datapoints;
            int y_scale = Canvas.Height / y_number_of_datapoints;

            g.FillEllipse(tag2, (x_scale * x_pos) - diamater / 2, (y_pos * y_scale) - diamater / 2, diamater, diamater);

        }
        #endregion

        #region Initalization

        internal void Init()
        {
            if (!Data.DatabaseExists())
                Data.CreateDatabase();

            Data.AddTagAssocation();
        }

       

        internal void Start_Initaliztion()
        {
            //Delete data in lookup table
            Data.DeleteLookup();
            MessageBox.Show("Information","Starting X initalizaiton", MessageBoxButtons.OK);
            this.Initalize(x_start,x_end,x_interval,LookupTable.Axis.X,x_Reader);
            MessageBox.Show("Information","Starting Y initalizaiton", MessageBoxButtons.OK);
            this.Initalize(y_start,y_end,y_interval,LookupTable.Axis.Y,y_Reader);
            MessageBox.Show("Information","Completed initalizaiton", MessageBoxButtons.OK);
            x_AVG = new Distancing(LookupTable.DistanceType.AVG, Data, LookupTable.Axis.X);
            x_DFT = new Distancing(LookupTable.DistanceType.DFT, Data, LookupTable.Axis.X);

            y_AVG = new Distancing(LookupTable.DistanceType.AVG, Data, LookupTable.Axis.Y);
            y_DFT = new Distancing(LookupTable.DistanceType.DFT, Data, LookupTable.Axis.Y);
            

        }

        internal void Initalize(int Distance_Start, int Distance_End, int Distance_interval, LookupTable.Axis ID, ComPort Reader)
        {
            List<Tag> Tags;
           
            //Start Distance of the configuration
            int Distance = Distance_Start;
            MessageBox.Show("Information",string.Format("Please put tag at {0}cm then press enter", Distance), MessageBoxButtons.OK);

            while (Distance < Distance_End)
            {

                List<Tag> ListRead = new List<Tag>();
                while (ListRead.Count < Configutation_num_reads)
                {
                    //Seach for tags with RSSI
                    Tags = Inventory.StartTagInventory(Reader);

                    //if more then 1 tag found and does not contain SHIT
                    //Then we read the tag and increment Read
                    if (Tags.Count > 0)
                        if (!Tags[0].ID.Contains("SHIT"))
                        {
                            ListRead.Add(Tags[0]);
                            Debug.WriteLine("I:{0}, Q:{1}", Tags[0].I, Tags[0].Q);
                        }
                    //Sleep thread to get accurate measurements each time
                    //Has to be adjusted so we do not overflow the reader
                    // Console.WriteLine("Attempt:{0}",iter);
                    //System.Threading.Thread.Sleep(SleepTimer);
                }
                Data.Add_Tags(Distance, ListRead,ID);
                Distance += Distance_interval;
                MessageBox.Show("Information",string.Format("Please put tag at {0}cm then press enter", Distance), MessageBoxButtons.OK);

            }
        }

        #endregion

        #region Reading

        internal List<TagFound> ReadTags()
        {
            List<Tag> Tags_X;
            List<Tag> Tags_Y;

            List<Tag> ListRead_X = new List<Tag>();
            List<Tag> ListRead_Y = new List<Tag>();
            while (ListRead_X.Count < Configutation_num_reads)
            {
                //Seach for tags with RSSI
                Tags_X = Inventory.StartTagInventory(x_Reader);
                Tags_Y = Inventory.StartTagInventory(y_Reader);
                //if more then 1 tag found and does not contain SHIT
                //Then we read the tag and increment Read
                foreach (Tag t in Tags_X)
                {
                    if (!t.ID.Contains("SHIT"))
                    {
                        ListRead_X.Add(t);
                    }
                }
                foreach (Tag t in Tags_Y)
                {
                    if (!t.ID.Contains("SHIT"))
                    {
                        ListRead_Y.Add(t);
                    }
                }

                //Sleep thread to get accurate measurements each time
                //Has to be adjusted so we do not overflow the reader
                // Console.WriteLine("Attempt:{0}",iter);
                //System.Threading.Thread.Sleep(SleepTimer);
            }

            List<int> Distance_Avg = AVG.Find_Distance(ListRead);
            List<int> Distance_DFT = DFT.Find_Distance(ListRead);
            if (Distance_Avg.Count == 1 && Distance_DFT.Count == 1)
            {
                Lookup.AddMeasurement(Distance, Distance_Avg.First(), Distance_DFT.First());
                Console.WriteLine("Added Results to the DB iteration:{0} for Distance:{1}", Iterations, Distance);
            }
            else
            {
                Console.WriteLine("One of the methods returned more then one result");
            }
        }

        #endregion

    }
}
