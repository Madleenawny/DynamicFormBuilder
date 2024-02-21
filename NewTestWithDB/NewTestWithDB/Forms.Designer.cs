namespace NewTestWithDB
{
    partial class Forms
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
            this.btnSave = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.formLbl = new System.Windows.Forms.Label();
            this.comboBoxForms = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSave.Location = new System.Drawing.Point(686, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControls
            // 
            this.panelControls.AutoScroll = true;
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 70);
            this.panelControls.Name = "panelControls";
            this.panelControls.Padding = new System.Windows.Forms.Padding(3);
            this.panelControls.Size = new System.Drawing.Size(1153, 486);
            this.panelControls.TabIndex = 3;
            // 
            // formLbl
            // 
            this.formLbl.AutoSize = true;
            this.formLbl.Location = new System.Drawing.Point(52, 20);
            this.formLbl.Name = "formLbl";
            this.formLbl.Size = new System.Drawing.Size(90, 17);
            this.formLbl.TabIndex = 6;
            this.formLbl.Text = "Choose Form";
            // 
            // comboBoxForms
            // 
            this.comboBoxForms.FormattingEnabled = true;
            this.comboBoxForms.Location = new System.Drawing.Point(174, 17);
            this.comboBoxForms.Name = "comboBoxForms";
            this.comboBoxForms.Size = new System.Drawing.Size(390, 24);
            this.comboBoxForms.TabIndex = 4;
            this.comboBoxForms.SelectedIndexChanged += new System.EventHandler(this.comboBoxForms_SelectedIndexChanged);
            // 
            // Forms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 556);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.formLbl);
            this.Controls.Add(this.comboBoxForms);
            this.DoubleBuffered = true;
            this.Name = "Forms";
            this.Text = "Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label formLbl;
        private System.Windows.Forms.ComboBox comboBoxForms;
    }
}