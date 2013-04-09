namespace _1DDistancing
{
    partial class Form1
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
            this.pb_Layout = new System.Windows.Forms.PictureBox();
            this.btt_initalize = new System.Windows.Forms.Button();
            this.btt_BuildLookupTable = new System.Windows.Forms.Button();
            this.btt_Find = new System.Windows.Forms.Button();
            this.btt_TestDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Layout)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Layout
            // 
            this.pb_Layout.Location = new System.Drawing.Point(12, 71);
            this.pb_Layout.Name = "pb_Layout";
            this.pb_Layout.Size = new System.Drawing.Size(847, 50);
            this.pb_Layout.TabIndex = 0;
            this.pb_Layout.TabStop = false;
            // 
            // btt_initalize
            // 
            this.btt_initalize.Location = new System.Drawing.Point(12, 228);
            this.btt_initalize.Name = "btt_initalize";
            this.btt_initalize.Size = new System.Drawing.Size(75, 23);
            this.btt_initalize.TabIndex = 1;
            this.btt_initalize.Text = "Initialize";
            this.btt_initalize.UseVisualStyleBackColor = true;
            this.btt_initalize.Click += new System.EventHandler(this.btt_initalize_Click);
            // 
            // btt_BuildLookupTable
            // 
            this.btt_BuildLookupTable.Location = new System.Drawing.Point(93, 228);
            this.btt_BuildLookupTable.Name = "btt_BuildLookupTable";
            this.btt_BuildLookupTable.Size = new System.Drawing.Size(122, 23);
            this.btt_BuildLookupTable.TabIndex = 2;
            this.btt_BuildLookupTable.Text = "Build Lookup Table";
            this.btt_BuildLookupTable.UseVisualStyleBackColor = true;
            this.btt_BuildLookupTable.Click += new System.EventHandler(this.btt_BuildLookupTable_Click);
            // 
            // btt_Find
            // 
            this.btt_Find.Location = new System.Drawing.Point(221, 228);
            this.btt_Find.Name = "btt_Find";
            this.btt_Find.Size = new System.Drawing.Size(75, 23);
            this.btt_Find.TabIndex = 3;
            this.btt_Find.Text = "Find Tag";
            this.btt_Find.UseVisualStyleBackColor = true;
            this.btt_Find.Click += new System.EventHandler(this.btt_Find_Click);
            // 
            // btt_TestDraw
            // 
            this.btt_TestDraw.Location = new System.Drawing.Point(784, 228);
            this.btt_TestDraw.Name = "btt_TestDraw";
            this.btt_TestDraw.Size = new System.Drawing.Size(75, 23);
            this.btt_TestDraw.TabIndex = 4;
            this.btt_TestDraw.Text = "Test Draw";
            this.btt_TestDraw.UseVisualStyleBackColor = true;
            this.btt_TestDraw.Click += new System.EventHandler(this.btt_TestDraw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 263);
            this.Controls.Add(this.btt_TestDraw);
            this.Controls.Add(this.btt_Find);
            this.Controls.Add(this.btt_BuildLookupTable);
            this.Controls.Add(this.btt_initalize);
            this.Controls.Add(this.pb_Layout);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Layout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Layout;
        private System.Windows.Forms.Button btt_initalize;
        private System.Windows.Forms.Button btt_BuildLookupTable;
        private System.Windows.Forms.Button btt_Find;
        private System.Windows.Forms.Button btt_TestDraw;
    }
}

