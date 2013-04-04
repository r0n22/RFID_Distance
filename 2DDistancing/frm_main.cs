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
            
            Form_Data.Create_Grid(this.pB_Layout.CreateGraphics(), this.pB_Layout.Size);
            Form_Data.AddTag1(this.pB_Layout.CreateGraphics(), 2, 4, this.pB_Layout.Size);
            Form_Data.AddTag2(this.pB_Layout.CreateGraphics(), 4, 2, this.pB_Layout.Size);
        }

        private void btn_startInitalization_Click(object sender, EventArgs e)
        {
            D.Start_Initaliztion(); 
        }

    }
}
