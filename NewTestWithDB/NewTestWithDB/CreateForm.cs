using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NewTestWithDB
{
    public partial class CreateForm : DevComponents.DotNetBar.Office2007Form
    {

        private bool isDragging = false;
        private Point offset;
        private Control selectedControl;
        private string connectionString = @"Data Source=MADLEEN\SQLEXPRESS2014;Initial Catalog=Forms;Integrated Security=True;";
        private SqlConnection  conn;
      
        public CreateForm()
        {
            InitializeComponent();
            deleteBtn.Click += deleteBtn_Click;

            formNameTxt.KeyPress += FormNameTxt_KeyPress;
        }

        private void FormNameTxt_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '_' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
               
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                selectedControl = sender as Control;
                offset = new Point(e.X, e.Y);
                if (selectedControl != null)
                {
                    selectedControl.BringToFront();
                }
            }
        }
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Control control = sender as Control;
                Point newLocation = control.PointToScreen(new Point(e.X, e.Y));
                newLocation.Offset(-offset.X, -offset.Y);
                control.Location = control.Parent.PointToClient(newLocation);
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private (string Name, bool IsMultiline, int Height, int Width) GetControlProperties()
        {
            using (var form = new Form())
            using (var nameTextBox = new TextBox())
            using (var multilineCheckBox = new CheckBox())
            using (var heightLabel = new Label())
            using (var heightNumericUpDown = new NumericUpDown())
            using (var widthLabel = new Label())
            using (var widthNumericUpDown = new NumericUpDown())
            using (var okButton = new Button())
            {
                form.Text = "Enter Control Properties";
                form.Size = new Size(400, 300);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                nameTextBox.Size = new Size(300, 20);
                nameTextBox.Location = new Point(50, 20);

                multilineCheckBox.Text = "Multiline";
                multilineCheckBox.Location = new Point(50, 50);

                heightLabel.Text = "Height:";
                heightLabel.AutoSize = true;
                heightLabel.Location = new Point(50, 80);

                heightNumericUpDown.Minimum = 1;
                heightNumericUpDown.Maximum = 500;
                heightNumericUpDown.Value = 20; 
                heightNumericUpDown.Location = new Point(130, 78);

                widthLabel.Text = "Width:";
                widthLabel.AutoSize = true;
                widthLabel.Location = new Point(50, 110);

                widthNumericUpDown.Minimum = 1;
                widthNumericUpDown.Maximum = 500;
                widthNumericUpDown.Value = 100; // Default width
                widthNumericUpDown.Location = new Point(130, 108);

                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.Location = new Point(230,200);

                form.Controls.AddRange(new Control[] { nameTextBox, multilineCheckBox, heightLabel, heightNumericUpDown, widthLabel, widthNumericUpDown, okButton });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return (nameTextBox.Text, multilineCheckBox.Checked, (int)heightNumericUpDown.Value, (int)widthNumericUpDown.Value);
                }
                else
                {
                    return (null, false, 0, 0);
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Button newButton = new Button();
            string controlName = GetControlName();
            if (!string.IsNullOrEmpty(controlName))
            {
                newButton.Name = controlName;
                newButton.Text = controlName;
                newButton.Location = new Point(50, 50);
                panel1.Controls.Add(newButton);

                newButton.MouseDown += Control_MouseDown;
                newButton.MouseMove += Control_MouseMove; 
                newButton.MouseUp += Control_MouseUp;
            }
        }

        private void AddTxtBtn_Click(object sender, EventArgs e)
        {
            (string controlName, bool isMultiline, int height, int width) = GetControlProperties();
            if (!string.IsNullOrEmpty(controlName))
            {
                TextBox newTextBox = new TextBox();
                newTextBox.Name = controlName;
                newTextBox.Text = controlName;
                newTextBox.Location = new Point(100, 100);
                newTextBox.Multiline = isMultiline;
                newTextBox.ScrollBars = ScrollBars.Both;
                newTextBox.Height = height;
                newTextBox.Width = width;
                panel1.Controls.Add(newTextBox);

                newTextBox.MouseDown += Control_MouseDown;
                newTextBox.MouseMove += Control_MouseMove;
                newTextBox.MouseUp += Control_MouseUp;
            }
        }

        private void AddLblBtn_Click(object sender, EventArgs e)
        {
            Label newLabel = new Label();
            string controlName = GetControlName();
            if (!string.IsNullOrEmpty(controlName))
            {
                newLabel.Name = controlName;
                newLabel.Text = controlName;
                newLabel.Location = new Point(150, 150);
                panel1.Controls.Add(newLabel);

                newLabel.MouseDown += Control_MouseDown;
                newLabel.MouseMove += Control_MouseMove;
                newLabel.MouseUp += Control_MouseUp;
            }
        }
        private void addIntBtn_Click(object sender, EventArgs e)
        {
            IntegerInput newIntegerInput = new IntegerInput();
            string controlName = GetControlName();
            if (!string.IsNullOrEmpty(controlName))
            {
                newIntegerInput.Name = controlName;
                newIntegerInput.MinValue = 0;
                newIntegerInput.MaxValue = 500;
                newIntegerInput.Location = new Point(150, 150);
                newIntegerInput.WatermarkText = "Enter Integer";
                panel1.Controls.Add(newIntegerInput);

                newIntegerInput.MouseDown += Control_MouseDown;
                newIntegerInput.MouseMove += Control_MouseMove;
                newIntegerInput.MouseUp += Control_MouseUp;
            }
        }

        private void addDoublBtn_Click(object sender, EventArgs e)
        {
            DoubleInput newDoubleInput = new DoubleInput();
            string controlName = GetControlName();
            if (!string.IsNullOrEmpty(controlName))
            {
                newDoubleInput.Name = controlName;
                newDoubleInput.MinValue = 0.0;
                newDoubleInput.MaxValue = 500.0;
                newDoubleInput.Location = new Point(300, 300);
                newDoubleInput.WatermarkText = "Enter Double";
                panel1.Controls.Add(newDoubleInput);

                newDoubleInput.MouseDown += Control_MouseDown;
                newDoubleInput.MouseMove += Control_MouseMove;
                newDoubleInput.MouseUp += Control_MouseUp;
            }
        }
        private void addChBoxBtn_Click(object sender, EventArgs e)
        {
            CheckBox newCheckBox = new CheckBox();
            string controlName = GetControlName();
            if (!string.IsNullOrEmpty(controlName))
            {
                newCheckBox.Name = controlName;
                newCheckBox.Text = controlName;
                newCheckBox.Checked = false;
                newCheckBox.Location = new Point(350, 350);
                panel1.Controls.Add(newCheckBox);

                newCheckBox.MouseDown += Control_MouseDown;
                newCheckBox.MouseMove += Control_MouseMove;
                newCheckBox.MouseUp += Control_MouseUp;
            }
        }

        private string GetControlName(string existingName = null)
        {
            using (var form = new Form())
            using (var textBox = new TextBox())
            using (var button = new Button())
            {
                form.Text = "Enter Control Name";
                form.Size = new Size(300, 120);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                textBox.Size = new Size(200, 20);
                textBox.Location = new Point(50, 20);
                textBox.Text = existingName; // Set default value to existing name

                button.Text = "OK";
                button.DialogResult = DialogResult.OK;
                button.Location = new Point(110, 50);

                form.Controls.AddRange(new Control[] { textBox, button });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text;
                }
                else
                {
                    return null;
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedControl != null)
            {
                string existingName = selectedControl.Name;
                string updatedName = GetControlName(existingName);

                // Update the Name of the selected control
                if (!string.IsNullOrEmpty(updatedName))
                {
                    selectedControl.Name = updatedName;

                    if (selectedControl is TextBox)
                    {
                        TextBox textBox = (TextBox)selectedControl;
                    }
                    else if (selectedControl is Label)
                    {
                        Label label = (Label)selectedControl;
                    }
                    else if (selectedControl is IntegerInput)
                    {
                        IntegerInput integerInput = (IntegerInput)selectedControl;
                        integerInput.Name = updatedName;
                    }
                    else if (selectedControl is DoubleInput)
                    {
                        DoubleInput doubleInput = (DoubleInput)selectedControl;
                        doubleInput.Name = updatedName;
                    }
                }
            }
        }

        private string GetControlName()
        {
            using (var form = new Form())
            using (var textBox = new TextBox())
            using (var button = new Button())
            {
                form.Text = "Enter Control Name";
                form.Size = new Size(300, 120);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                                
                textBox.Size = new Size(200, 20);
                textBox.Location = new Point(50, 20);

                button.Text = "OK";
                button.DialogResult = DialogResult.OK;
                button.Location = new Point(110, 50);

                form.Controls.AddRange(new Control[] { textBox, button });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text;
                }
                else
                {
                    return null;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string formName = formNameTxt.Text;
                string insertFormQuery = $"INSERT INTO MasterTable (FormName) VALUES ('{formName}'); SELECT SCOPE_IDENTITY();";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(insertFormQuery, conn))
                    {
                        conn.Open();
                        int formID = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();

                        foreach (Control control in panel1.Controls)
                        {
                            if (control is Label || control is TextBox || control is Button || control is IntegerInput || control is DoubleInput || control is CheckBox)
                            {
                                string controlType = control.GetType().Name;
                                string controlName = control.Name;

                                // skip controls with names
                                if (controlName != "formNameTxt" && controlName != "formNameLbl")
                                {
                                    int locationX = control.Location.X;
                                    int locationY = control.Location.Y;
                                    int height = control.Height;
                                    int width = control.Width;

                                    string insertQuery = $"INSERT INTO DetailTable (FormID, ControlName, ControlType, LocationX, LocationY, Height, Width) " +
                                                        $"VALUES ({formID}, '{controlName}', '{controlType}', {locationX}, {locationY}, {height}, {width})";

                                    using (SqlCommand detailCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        conn.Open();
                                        detailCmd.ExecuteNonQuery();
                                        conn.Close();
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Form and controls saved to the database.");
                        ClearPanel();
                    }
                }
                     catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedControl != null)
            {                
                panel1.Controls.Remove(selectedControl);
                selectedControl = null; 
            }
        }

        private void ClearPanel()
        {
           // Create a list to store controls to remove
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in panel1.Controls)
            {
                if (control != formNameLbl && control != formNameTxt &&
                    (control is Button || control is Label || control is TextBox || control is IntegerInput || control is DoubleInput || control is CheckBox))
                {
                    controlsToRemove.Add(control);
                }
            }

            // Remove controls from the panel
            foreach (Control controlToRemove in controlsToRemove)
            {
                panel1.Controls.Remove(controlToRemove);
                formNameTxt.Clear();
                controlToRemove.Dispose(); // Dispose the control to release resources
            }
        }

        
    }
}
