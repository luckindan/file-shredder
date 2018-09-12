namespace WindowsFormsApp1
{
    partial class FIle_path
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
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Runbottom = new System.Windows.Forms.Button();
            this.Destination = new System.Windows.Forms.Label();
            this.Dialog = new System.Windows.Forms.Label();
            this.System_Log = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(88, 52);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(366, 20);
            this.FileNameBox.TabIndex = 0;
            this.FileNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(471, 53);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(61, 19);
            this.Browse.TabIndex = 1;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Runbottom
            // 
            this.Runbottom.Location = new System.Drawing.Point(554, 53);
            this.Runbottom.Name = "Runbottom";
            this.Runbottom.Size = new System.Drawing.Size(59, 19);
            this.Runbottom.TabIndex = 2;
            this.Runbottom.Text = "Run";
            this.Runbottom.UseVisualStyleBackColor = true;
            this.Runbottom.Click += new System.EventHandler(this.Runbottom_Click);
            // 
            // Destination
            // 
            this.Destination.AutoSize = true;
            this.Destination.Location = new System.Drawing.Point(22, 56);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(47, 13);
            this.Destination.TabIndex = 3;
            this.Destination.Text = "File path";
            // 
            // Dialog
            // 
            this.Dialog.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Dialog.AutoSize = true;
            this.Dialog.Location = new System.Drawing.Point(90, 84);
            this.Dialog.Name = "Dialog";
            this.Dialog.Size = new System.Drawing.Size(259, 13);
            this.Dialog.TabIndex = 4;
            this.Dialog.Text = "This Application will shred your file, don\'t try it at home";
            // 
            // System_Log
            // 
            this.System_Log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.System_Log.Location = new System.Drawing.Point(554, 112);
            this.System_Log.Name = "System_Log";
            this.System_Log.Size = new System.Drawing.Size(59, 22);
            this.System_Log.TabIndex = 5;
            this.System_Log.Text = "Log";
            this.System_Log.UseVisualStyleBackColor = true;
            this.System_Log.Click += new System.EventHandler(this.button1_Click);
            // 
            // FIle_path
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(646, 146);
            this.Controls.Add(this.System_Log);
            this.Controls.Add(this.Dialog);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.Runbottom);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.FileNameBox);
            this.MaximizeBox = false;
            this.Name = "FIle_path";
            this.Text = "File Shredder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button Runbottom;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.Label Dialog;
        private System.Windows.Forms.Button System_Log;
    }
}

