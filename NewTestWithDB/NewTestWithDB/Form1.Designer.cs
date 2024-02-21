namespace NewTestWithDB
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
            this.createFBtn = new System.Windows.Forms.Button();
            this.FormsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createFBtn
            // 
            this.createFBtn.Location = new System.Drawing.Point(232, 164);
            this.createFBtn.Name = "createFBtn";
            this.createFBtn.Size = new System.Drawing.Size(134, 59);
            this.createFBtn.TabIndex = 0;
            this.createFBtn.Text = "Create Form";
            this.createFBtn.UseVisualStyleBackColor = true;
            this.createFBtn.Click += new System.EventHandler(this.createFBtn_Click);
            // 
            // FormsBtn
            // 
            this.FormsBtn.Location = new System.Drawing.Point(429, 164);
            this.FormsBtn.Name = "FormsBtn";
            this.FormsBtn.Size = new System.Drawing.Size(134, 59);
            this.FormsBtn.TabIndex = 1;
            this.FormsBtn.Text = "Forms";
            this.FormsBtn.UseVisualStyleBackColor = true;
            this.FormsBtn.Click += new System.EventHandler(this.FormsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FormsBtn);
            this.Controls.Add(this.createFBtn);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createFBtn;
        private System.Windows.Forms.Button FormsBtn;
    }
}