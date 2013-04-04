using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _2DDistancing.Form_Code;
using _2DDistancing.Code;

namespace _2DDistancing
{
    public partial class frm_main : Form
    {
        Form_Data D = new Form_Data();
        public frm_main()
        {
            InitializeComponent();
            D.Init();
        }

       

        private void btn_create_grid_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Form_Data.Create_Grid(this.pB_Layout.CreateGraphics(), this.pB_Layout.Size);
            Form_Data.AddTag1(this.pB_Layout.CreateGraphics(), rand.Next(10), rand.Next(10), this.pB_Layout.Size);
            Form_Data.AddTag2(this.pB_Layout.CreateGraphics(), rand.Next(10), rand.Next(10), this.pB_Layout.Size);
        }

        private void btn_startInitalization_Click(object sender, EventArgs e)
        {
            D.Start_Initaliztion(); 
        }

        private void btt_findTag_Click(object sender, EventArgs e)
        {
            //Read Tags
            List<TagFound> Tags = D.ReadTags();
            //Create Grid
            Form_Data.Create_Grid(this.pB_Layout.CreateGraphics(), this.pB_Layout.Size);
            //Find Tag 1 and Display it
            TagFound T1 = Tags.SingleOrDefault(t => t.ID.Equals(1));
            if (T1.ID.Equals(1))
            {
                Form_Data.AddTag1(this.pB_Layout.CreateGraphics(), T1.X, T1.Y, this.pB_Layout.Size);
            }
            //Find Tag 2 and Display it
            TagFound T2 = Tags.SingleOrDefault(t => t.ID.Equals(2));
            if (T2.ID.Equals(2))
            {
                Form_Data.AddTag2(this.pB_Layout.CreateGraphics(), T2.X, T2.Y, this.pB_Layout.Size);
            }
            
        }

    }
}
