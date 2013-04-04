namespace _2DDistancing
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_startInitalization = new System.Windows.Forms.Button();
            this.btt_findTag = new System.Windows.Forms.Button();
            this.pB_Layout = new System.Windows.Forms.PictureBox();
            this.btn_create_grid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Layout)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_startInitalization
            // 
            this.btn_startInitalization.Location = new System.Drawing.Point(13, 318);
            this.btn_startInitalization.Name = "btn_startInitalization";
            this.btn_startInitalization.Size = new System.Drawing.Size(105, 23);
            this.btn_startInitalization.TabIndex = 0;
            this.btn_startInitalization.Text = "Start Initalization";
            this.btn_startInitalization.UseVisualStyleBackColor = true;
            this.btn_startInitalization.Click += new System.EventHandler(this.btn_startInitalization_Click);
            // 
            // btt_findTag
            // 
            this.btt_findTag.Location = new System.Drawing.Point(13, 289);
            this.btt_findTag.Name = "btt_findTag";
            this.btt_findTag.Size = new System.Drawing.Size(105, 23);
            this.btt_findTag.TabIndex = 1;
            this.btt_findTag.Text = "Find Tag";
            this.btt_findTag.UseVisualStyleBackColor = true;
            this.btt_findTag.Click += new System.EventHandler(this.btt_findTag_Click);
            // 
            // pB_Layout
            // 
            this.pB_Layout.Location = new System.Drawing.Point(254, 12);
            this.pB_Layout.Name = "pB_Layout";
            this.pB_Layout.Size = new System.Drawing.Size(320, 320);
            this.pB_Layout.TabIndex = 2;
            this.pB_Layout.TabStop = false;
            // 
            // btn_create_grid
            // 
            this.btn_create_grid.Location = new System.Drawing.Point(13, 260);
            this.btn_create_grid.Name = "btn_create_grid";
            this.btn_create_grid.Size = new System.Drawing.Size(105, 23);
            this.btn_create_grid.TabIndex = 3;
            this.btn_create_grid.Text = "Create Grid";
            this.btn_create_grid.UseVisualStyleBackColor = true;
            this.btn_create_grid.Click += new System.EventHandler(this.btn_create_grid_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 353);
            this.Controls.Add(this.btn_create_grid);
            this.Controls.Add(this.pB_Layout);
            this.Controls.Add(this.btt_findTag);
            this.Controls.Add(this.btn_startInitalization);
            this.Name = "frm_main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pB_Layout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_startInitalization;
        private System.Windows.Forms.Button btt_findTag;
        private System.Windows.Forms.PictureBox pB_Layout;
        private System.Windows.Forms.Button btn_create_grid;
    }
}

