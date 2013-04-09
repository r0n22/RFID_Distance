using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _1DDistancing.Form_Code;

namespace _1DDistancing
{
    public partial class Form1 : Form
    {
        Form_Data D = new Form_Data();
        public Form1()
        {
            InitializeComponent();
            D.Init();
        }

        private void btt_initalize_Click(object sender, EventArgs e)
        {
            D.Start_Initaliztion(); 
        }

        private void btt_Find_Click(object sender, EventArgs e)
        {
            //Read Tags
            List<TagFound> Tags = D.ReadTags();
            //Create Grid
            Form_Data.Create_Grid(this.pb_Layout.CreateGraphics(), this.pb_Layout.Size);
            //Find Tag 1 and Display it
            TagFound T1 = Tags.SingleOrDefault(t => t.ID.Equals(1));
            if (T1.ID.Equals(1))
            {
                Form_Data.AddTag1(this.pb_Layout.CreateGraphics(), T1.X_Pos,  this.pb_Layout.Size);
            }
            
        }

        private void btt_BuildLookupTable_Click(object sender, EventArgs e)
        {
            D.Build_LookupTable();
        }

        private void btt_TestDraw_Click(object sender, EventArgs e)
        {
            Form_Data.Create_Grid(this.pb_Layout.CreateGraphics(), this.pb_Layout.Size);
            Form_Data.AddTag1(this.pb_Layout.CreateGraphics(), new Random().Next(10), this.pb_Layout.Size);
        }
    }
}
