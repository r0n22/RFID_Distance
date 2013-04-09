using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using _1DDistancing.Code;
using System.Diagnostics;

namespace _1DDistancing.Form_Code
{
    class Form_Data
    {
        

        LookupTable Data = new LookupTable("LookupTable.sdf");
        ComPort Reader = new ComPort("COM4");
        //ComPort y_Reader = new ComPort("COM5");
        Distancing x_AVG = null;
        Distancing x_DFT = null;
        Distancing y_AVG = null;
        Distancing y_DFT = null;
            
        //Xside
        public static int x_interval = 10;
        public static int x_start = 0;
        public static int x_end = 70;
        public static int x_number_of_datapoints = (x_end - x_start) / x_interval;
        //Y side 
        
        public static int Configutation_num_reads = 64;


        #region Draw
        private static System.Drawing.Pen background = new System.Drawing.Pen(Color.Black, 2F);
        private static System.Drawing.SolidBrush tag1 = new System.Drawing.SolidBrush(Color.Green);
        private static System.Drawing.SolidBrush tag2 = new System.Drawing.SolidBrush(Color.Blue);



        public static void Create_Grid(Graphics g, Size Canvas)
        {
            g.Clear(Color.White);
            int x_scale = Canvas.Width/x_number_of_datapoints;
            for (int i = 0; i < x_number_of_datapoints; i++)
            {
                int x_height = i*x_scale;
                g.DrawLine(background, x_height, 0, x_height, Canvas.Height);
            }

            g.DrawLine(background, 0, Canvas.Height / 2, Canvas.Width, Canvas.Height / 2);
            
           
        }

        private static int diamater = 15;

        public static void AddTag1(Graphics g, int x_pos,Size Canvas)
        {
            int x_scale = Canvas.Width / x_number_of_datapoints;

            g.FillEllipse(tag1, (x_scale * x_pos) - diamater / 2, (Canvas.Height / 2) - diamater / 2, diamater, diamater);

        }

        public static void AddTag2(Graphics g, int x_pos, Size Canvas)
        {
            int x_scale = Canvas.Width / x_number_of_datapoints;

            g.FillEllipse(tag2, (x_scale * x_pos) - diamater / 2, (Canvas.Height / 2) - diamater / 2, diamater, diamater);

        }

       
        #endregion

        #region Initalization

        internal void Init()
        {
            if (!Data.DatabaseExists())
                Data.CreateDatabase();

            
        }

       

        internal void Start_Initaliztion()
        {
            //Delete data in lookup table
            Data.DeleteLookup();
            MessageBox.Show("Starting X initalizaiton", "Information", MessageBoxButtons.OK);
            this.Initalize(x_start,x_end,x_interval,Reader);
            MessageBox.Show("Completed initalizaiton", "Information", MessageBoxButtons.OK);
            x_DFT = new Distancing(LookupTable.DistanceType.DFT, Data);
            MessageBox.Show("Completed LookupTable", "Information", MessageBoxButtons.OK);
            

        }

        internal void Build_LookupTable()
        {
            x_DFT = new Distancing(LookupTable.DistanceType.DFT, Data);
            MessageBox.Show("Completed LookupTable", "Information", MessageBoxButtons.OK);
        }

        internal void Initalize(int Distance_Start, int Distance_End, int Distance_interval, ComPort Reader)
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
                Data.Add_Tags(Distance, ListRead);
                Distance += Distance_interval;
                MessageBox.Show("Information",string.Format("Please put tag at {0}cm then press enter", Distance), MessageBoxButtons.OK);

            }
        }

        #endregion

        #region Reading

        internal List<TagFound> ReadTags()
        {
            List<Tag> Tags_X;
            
            List<Tag> ListRead_X = new List<Tag>();
            while (ListRead_X.Count < Configutation_num_reads)
            {
                //Seach for tags with RSSI
                Tags_X = Inventory.StartTagInventory(Reader);
                //if more then 1 tag found and does not contain SHIT
                //Then we read the tag and increment Read
                foreach (Tag t in Tags_X)
                {
                    if (!t.ID.Contains("SHIT"))
                    {
                        ListRead_X.Add(t);
                    }
                }
                

                //Sleep thread to get accurate measurements each time
                //Has to be adjusted so we do not overflow the reader
                // Console.WriteLine("Attempt:{0}",iter);
                //System.Threading.Thread.Sleep(SleepTimer);
            }
            //Pull Tag data to into the diffrent lists
            List<Tag> x_Tag1 = ListRead_X.ToList();
            

            List<TagFound> List_of_tags = new List<TagFound>();
            //Do the calculations
            //only do the calculations if there are tag reads
            if (x_Tag1.Count > 0)
            {
                List<int> x_Tag1_DFT = x_DFT.Find_Distance(x_Tag1);
                if (x_Tag1_DFT.Count == 1)
                {
                    int xpos = (x_Tag1_DFT[0] - x_start) / x_interval;
                    List_of_tags.Add(new TagFound(1, xpos));
                }

            }
            
            
            return List_of_tags;

        }

        #endregion

    }
}
