namespace TestManager
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
            this.button1 = new System.Windows.Forms.Button();
            this.rbtParallel = new System.Windows.Forms.RadioButton();
            this.rbtSequential = new System.Windows.Forms.RadioButton();
            this.cmbNoOfBrowsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtParallel
            // 
            this.rbtParallel.AutoSize = true;
            this.rbtParallel.Location = new System.Drawing.Point(165, 12);
            this.rbtParallel.Name = "rbtParallel";
            this.rbtParallel.Size = new System.Drawing.Size(86, 17);
            this.rbtParallel.TabIndex = 1;
            this.rbtParallel.Text = "Parallel(Grid)";
            this.rbtParallel.UseVisualStyleBackColor = true;
            // 
            // rbtSequential
            // 
            this.rbtSequential.AutoSize = true;
            this.rbtSequential.Checked = true;
            this.rbtSequential.Location = new System.Drawing.Point(52, 12);
            this.rbtSequential.Name = "rbtSequential";
            this.rbtSequential.Size = new System.Drawing.Size(75, 17);
            this.rbtSequential.TabIndex = 2;
            this.rbtSequential.TabStop = true;
            this.rbtSequential.Text = "Sequential";
            this.rbtSequential.UseVisualStyleBackColor = true;
            // 
            // cmbNoOfBrowsers
            // 
            this.cmbNoOfBrowsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoOfBrowsers.FormattingEnabled = true;
            this.cmbNoOfBrowsers.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.cmbNoOfBrowsers.Location = new System.Drawing.Point(343, 14);
            this.cmbNoOfBrowsers.Name = "cmbNoOfBrowsers";
            this.cmbNoOfBrowsers.Size = new System.Drawing.Size(42, 21);
            this.cmbNoOfBrowsers.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "No of Browsers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 96);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNoOfBrowsers);
            this.Controls.Add(this.rbtSequential);
            this.Controls.Add(this.rbtParallel);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Test Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbtParallel;
        private System.Windows.Forms.RadioButton rbtSequential;
        private System.Windows.Forms.ComboBox cmbNoOfBrowsers;
        private System.Windows.Forms.Label label1;
    }
}

