using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _2DDistancing.Form_Code
{
    class Form_Data
    {
        
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



        internal static void Start_Initaliztion()
        {
            throw new NotImplementedException();
        }
    }
}
