namespace NewTestWithDB
{
    partial class CreateForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.formNameTxt = new System.Windows.Forms.TextBox();
            this.formNameLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.AddTxtBtn = new System.Windows.Forms.Button();
            this.AddLblBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.addIntBtn = new System.Windows.Forms.Button();
            this.addDoublBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.addChBoxBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.formNameTxt);
            this.panel1.Controls.Add(this.formNameLbl);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 560);
            this.panel1.TabIndex = 0;
            // 
            // formNameTxt
            // 
            this.formNameTxt.Location = new System.Drawing.Point(270, 44);
            this.formNameTxt.Name = "formNameTxt";
            this.formNameTxt.Size = new System.Drawing.Size(228, 24);
            this.formNameTxt.TabIndex = 2;
            // 
            // formNameLbl
            // 
            this.formNameLbl.AutoSize = true;
            this.formNameLbl.Location = new System.Drawing.Point(504, 47);
            this.formNameLbl.Name = "formNameLbl";
            this.formNameLbl.Size = new System.Drawing.Size(74, 17);
            this.formNameLbl.TabIndex = 1;
            this.formNameLbl.Text = "اسم القالب";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.Controls.Add(this.addChBoxBtn);
            this.flowLayoutPanel1.Controls.Add(this.addIntBtn);
            this.flowLayoutPanel1.Controls.Add(this.addDoublBtn);
            this.flowLayoutPanel1.Controls.Add(this.AddBtn);
            this.flowLayoutPanel1.Controls.Add(this.AddTxtBtn);
            this.flowLayoutPanel1.Controls.Add(this.AddLblBtn);
            this.flowLayoutPanel1.Controls.Add(this.saveBtn);
            this.flowLayoutPanel1.Controls.Add(this.updateBtn);
            this.flowLayoutPanel1.Controls.Add(this.deleteBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(801, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(237, 560);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.AddBtn.Location = new System.Drawing.Point(3, 171);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(230, 50);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "ADD Button";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddTxtBtn
            // 
            this.AddTxtBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.AddTxtBtn.Location = new System.Drawing.Point(3, 227);
            this.AddTxtBtn.Name = "AddTxtBtn";
            this.AddTxtBtn.Size = new System.Drawing.Size(230, 50);
            this.AddTxtBtn.TabIndex = 1;
            this.AddTxtBtn.Text = "ADD TextBox";
            this.AddTxtBtn.UseVisualStyleBackColor = true;
            this.AddTxtBtn.Click += new System.EventHandler(this.AddTxtBtn_Click);
            // 
            // AddLblBtn
            // 
            this.AddLblBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.AddLblBtn.Location = new System.Drawing.Point(3, 283);
            this.AddLblBtn.Name = "AddLblBtn";
            this.AddLblBtn.Size = new System.Drawing.Size(230, 50);
            this.AddLblBtn.TabIndex = 2;
            this.AddLblBtn.Text = "ADD Label";
            this.AddLblBtn.UseVisualStyleBackColor = true;
            this.AddLblBtn.Click += new System.EventHandler(this.AddLblBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.deleteBtn.Location = new System.Drawing.Point(3, 451);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(230, 50);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.saveBtn.Location = new System.Drawing.Point(3, 339);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(230, 50);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // addIntBtn
            // 
            this.addIntBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.addIntBtn.Location = new System.Drawing.Point(3, 59);
            this.addIntBtn.Name = "addIntBtn";
            this.addIntBtn.Size = new System.Drawing.Size(230, 50);
            this.addIntBtn.TabIndex = 5;
            this.addIntBtn.Text = "ADD Int";
            this.addIntBtn.UseVisualStyleBackColor = true;
            this.addIntBtn.Click += new System.EventHandler(this.addIntBtn_Click);
            // 
            // addDoublBtn
            // 
            this.addDoublBtn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.addDoublBtn.Location = new System.Drawing.Point(3, 115);
            this.addDoublBtn.Name = "addDoublBtn";
            this.addDoublBtn.Size = new System.Drawing.Size(230, 50);
            this.addDoublBtn.TabIndex = 6;
            this.addDoublBtn.Text = "Add Double Input";
            this.addDoublBtn.UseVisualStyleBackColor = true;
            this.addDoublBtn.Click += new System.EventHandler(this.addDoublBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.updateBtn.Location = new System.Drawing.Point(3, 395);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(230, 50);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // addChBoxBtn
            // 
            this.addChBoxBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.addChBoxBtn.Location = new System.Drawing.Point(3, 3);
            this.addChBoxBtn.Name = "addChBoxBtn";
            this.addChBoxBtn.Size = new System.Drawing.Size(230, 50);
            this.addChBoxBtn.TabIndex = 8;
            this.addChBoxBtn.Text = "Add CheckBox";
            this.addChBoxBtn.UseVisualStyleBackColor = true;
            this.addChBoxBtn.Click += new System.EventHandler(this.addChBoxBtn_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 560);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button AddTxtBtn;
        private System.Windows.Forms.Button AddLblBtn;
        private System.Windows.Forms.TextBox formNameTxt;
        private System.Windows.Forms.Label formNameLbl;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addIntBtn;
        private System.Windows.Forms.Button addDoublBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button addChBoxBtn;
    }
}