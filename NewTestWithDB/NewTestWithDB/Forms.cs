////////using DevComponents.Editors;
////////using System;
////////using System.Collections.Generic;
////////using System.ComponentModel;
////////using System.Data;
////////using System.Data.SqlClient;
////////using System.Drawing;
////////using System.Linq;
////////using System.Text;
////////using System.Threading.Tasks;
////////using System.Windows.Forms;

////////namespace NewTestWithDB
////////{
////////    public partial class Forms : DevComponents.DotNetBar.Office2007Form
////////    {
////////        private const string ConnectionString = @"Data Source=MADLEEN\SQLEXPRESS2014;Initial Catalog=Forms;Integrated Security=True;";

////////        public Forms()
////////        {
////////            InitializeComponent();
////////            FillFormsComboBox();
////////        }

////////        private void FillFormsComboBox()
////////        {
////////            using (SqlConnection connection = new SqlConnection(ConnectionString))
////////            {
////////                connection.Open();
////////                string query = "SELECT ID, FormName FROM MasterTable";
////////                SqlCommand command = new SqlCommand(query, connection);
////////                SqlDataReader reader = command.ExecuteReader();

////////                while (reader.Read())
////////                {
////////                    int formId = reader.GetInt32(0);
////////                    string formName = reader.GetString(1);
////////                    ComboBoxItem item = new ComboBoxItem(formId, formName);
////////                    comboBoxForms.Items.Add(item);
////////                }

////////                reader.Close();
////////            }
////////        }

////////        private void comboBoxForms_SelectedIndexChanged(object sender, EventArgs e)
////////        {
////////            if (comboBoxForms.SelectedItem != null)
////////            {
////////                int selectedFormId = ((ComboBoxItem)comboBoxForms.SelectedItem).Id;
////////                DrawControls(selectedFormId);
////////            }
////////        }

////////        private void DrawControls(int formId)
////////        {
////////            panelControls.Controls.Clear();

////////            using (SqlConnection connection = new SqlConnection(ConnectionString))
////////            {
////////                connection.Open();
////////                string query = "SELECT ControlName, ControlType, LocationX, LocationY, Height, Width FROM DetailTable WHERE FormID = @ID";
////////                SqlCommand command = new SqlCommand(query, connection);
////////                command.Parameters.AddWithValue("@ID", formId);
////////                SqlDataReader reader = command.ExecuteReader();

////////                while (reader.Read())
////////                {
////////                    string controlName = reader.GetString(0);

////////                    // Skip controls with specific names
////////                    if (controlName.Equals("formNameTxt", StringComparison.OrdinalIgnoreCase) || controlName.Equals("formNameLbl", StringComparison.OrdinalIgnoreCase))
////////                    {
////////                        continue;
////////                    }

////////                    string controlType = reader.GetString(1);
////////                    int locationX = reader.GetInt32(2);
////////                    int locationY = reader.GetInt32(3);
////////                    int height = reader.GetInt32(4);
////////                    int width = reader.GetInt32(5);

////////                    Control control = CreateControl(controlType, controlName);
////////                    control.Location = new Point(locationX, locationY);
////////                    control.Size = new Size(width, height);
////////                    panelControls.Controls.Add(control);
////////                }

////////                reader.Close();
////////            }
////////        }


////////        private Control CreateControl(string controlType, string controlName)
////////        {
////////            switch (controlType.ToLower())
////////            {
////////                case "textbox":
////////                    TextBox textBox = new TextBox
////////                    {
////////                        Name = controlName,
////////                        Text = null,
////////                        Multiline = true
////////                    };
////////                    if (textBox.Height > 50)
////////                    { textBox.ScrollBars = ScrollBars.Vertical; }
////////                    return textBox;
////////                case "label":
////////                    return new Label { Name = controlName, Text = controlName };
////////                case "button":
////////                    return new Button { Name = controlName, Text = controlName };
////////                case "IntegerInput":
////////                    return new IntegerInput { Name = controlName, Text = null };
////////                default:
////////                    throw new ArgumentException($"Unsupported control type: {controlType}");
////////            }
////////        }

////////        private class ComboBoxItem
////////        {
////////            public int Id { get; }
////////            public string Name { get; }

////////            public ComboBoxItem(int id, string name)
////////            {
////////                Id = id;
////////                Name = name;
////////            }

////////            public override string ToString()
////////            {
////////                return Name;
////////            }
////////        }

////////        private void btnSave_Click(object sender, EventArgs e)
////////        {
////////            if (comboBoxForms.SelectedItem == null)
////////            {
////////                MessageBox.Show("Please select a form first.");
////////                return;
////////            }

////////            string formName = ((ComboBoxItem)comboBoxForms.SelectedItem).Name;

////////            using (SqlConnection connection = new SqlConnection(ConnectionString))
////////            {
////////                connection.Open();

////////                //  distinct control names of type 'textbox' for the selected form
////////                SqlDataAdapter detailAdapter = new SqlDataAdapter($"SELECT DISTINCT ControlName FROM DetailTable WHERE ControlType = 'textbox' AND FormID = (SELECT ID FROM MasterTable WHERE FormName = '{formName}')", connection);
////////                DataTable controlInfoTable = new DataTable();
////////                detailAdapter.Fill(controlInfoTable);

////////                // Check for duplicate column names
////////                HashSet<string> uniqueColumns = new HashSet<string>();
////////                List<string> textboxColumns = new List<string>();

////////                // Control names from DetailTable and add columns to the list
////////                foreach (DataRow row in controlInfoTable.Rows)
////////                {
////////                    string columnName = row["ControlName"].ToString().Trim();  
////////                    if (!uniqueColumns.Contains(columnName))
////////                    {
////////                        uniqueColumns.Add(columnName);
////////                        textboxColumns.Add(columnName);
////////                    }
////////                }

////////                //output
////////                Console.WriteLine("CONTROL COLUMNS:");
////////                Console.WriteLine(string.Join(", ", textboxColumns));

////////                // Check if there are columns to insert
////////                if (textboxColumns.Count > 0)
////////                {
////////                    // Check if the table already exists
////////                    string checkTableQuery = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{formName}'";
////////                    SqlCommand checkTableCommand = new SqlCommand(checkTableQuery, connection);
////////                    int tableExists = (int)checkTableCommand.ExecuteScalar();

////////                    if (tableExists == 0)
////////                    {
////////                        // CREATE TABLE 
////////                        string createTableQuery = $"CREATE TABLE {formName} (ID INT IDENTITY(1,1) PRIMARY KEY";

////////                        // Add columns to the new table
////////                        foreach (string columnName in textboxColumns)
////////                        {
////////                            createTableQuery += $", [{columnName}] NVARCHAR(255)";
////////                        }

////////                        createTableQuery += ")";

////////                        // CREATE TABLE query to the console
////////                        Console.WriteLine("CREATE TABLE QUERY:");
////////                        Console.WriteLine(createTableQuery);

////////                        // Execute the SQL CREATE TABLE command
////////                        using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
////////                        {
////////                            createTableCommand.ExecuteNonQuery();
////////                        }    
////////                    }

////////                    // INSERT DATA query
////////                    string insertDataQuery = $"INSERT INTO {formName} (";

////////                    // Add columns 
////////                    bool firstColumn = true;
////////                    foreach (string columnName in textboxColumns)
////////                    {
////////                        if (!firstColumn)
////////                        {
////////                            insertDataQuery += ", ";
////////                        }
////////                        insertDataQuery += "[" + columnName + "]";
////////                        firstColumn = false;
////////                    }

////////                    insertDataQuery += ") VALUES (";

////////                    // Add parameter textbox column
////////                    for (int i = 0; i < textboxColumns.Count; i++)
////////                    {
////////                        if (i > 0)
////////                        {
////////                            insertDataQuery += ", ";
////////                        }
////////                        insertDataQuery += $"@{textboxColumns[i]}";
////////                    }

////////                    insertDataQuery += ")";

////////                    // INSERT DATA query to the console
////////                    Console.WriteLine("INSERT DATA QUERY:");
////////                    Console.WriteLine(insertDataQuery);

////////                    // SQL INSERT command
////////                    using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
////////                    {
////////                        try
////////                        {
////////                            // Add parameter values from the form controls
////////                            foreach (string columnName in textboxColumns)
////////                            {
////////                                string paramName = $"@{columnName}";
////////                                Control formControl = panelControls.Controls[columnName];

////////                                if (formControl != null && formControl is TextBox textBoxControl)
////////                                {
////////                                    insertDataCommand.Parameters.AddWithValue(paramName, textBoxControl.Text);
////////                                }
////////                                else
////////                                {
////////                                    insertDataCommand.Parameters.AddWithValue(paramName, DBNull.Value);
////////                                }
////////                            }

////////                            // Execute the SQL INSERT command
////////                            insertDataCommand.ExecuteNonQuery();

////////                            MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
////////                        }
////////                        catch (Exception ex)
////////                        {
////////                            MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
////////                        }
////////                    }
////////                }
////////                else
////////                {
////////                    MessageBox.Show("No textbox columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
////////                }
////////            }
////////        }
////////    }
////////}

using DevComponents.Editors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NewTestWithDB
{
    public partial class Forms : DevComponents.DotNetBar.Office2007Form
    {
        private const string ConnectionString = @"Data Source=MADLEEN\SQLEXPRESS2014;Initial Catalog=Forms;Integrated Security=True;";

        // Dictionary to store control types for each control name
        private Dictionary<string, string> controlTypeDict = new Dictionary<string, string>();

        public Forms()
        {
            InitializeComponent();
            FillFormsComboBox();
        }

        private void FillFormsComboBox()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ID, FormName FROM MasterTable";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int formId = reader.GetInt32(0);
                    string formName = reader.GetString(1);
                    ComboBoxItem item = new ComboBoxItem(formId, formName);
                    comboBoxForms.Items.Add(item);
                }

                reader.Close();
            }
        }

        private void comboBoxForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxForms.SelectedItem != null)
            {
                int selectedFormId = ((ComboBoxItem)comboBoxForms.SelectedItem).Id;
                DrawControls(selectedFormId);
            }
        }

        private void DrawControls(int formId)
        {
            panelControls.Controls.Clear();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ControlName, ControlType, LocationX, LocationY, Height, Width FROM DetailTable WHERE FormID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", formId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string controlName = reader.GetString(0);

                    // Skip controls with specific names
                    if (controlName.Equals("formNameTxt", StringComparison.OrdinalIgnoreCase) || controlName.Equals("formNameLbl", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string controlType = reader.GetString(1);
                    int locationX = reader.GetInt32(2);
                    int locationY = reader.GetInt32(3);
                    int height = reader.GetInt32(4);
                    int width = reader.GetInt32(5);

                    Control control = CreateControl(controlType, controlName);
                    control.Location = new Point(locationX, locationY);
                    control.Size = new Size(width, height);
                    panelControls.Controls.Add(control);

                    // Store control type in the dictionary
                    controlTypeDict[controlName] = controlType;

                    ////if (GetDataType(controlType) == "BIT")
                    ////{
                    ////    CheckBox checkbox = new CheckBox
                    ////    {
                    ////        Name = controlName + "Checkbox",
                    ////        Text = "Is True",
                    ////        Location = new Point(locationX + width + 5, locationY),
                    ////        Checked = false
                    ////    };
                    ////    panelControls.Controls.Add(checkbox);
                    ////}
                }

                reader.Close();
            }
        }

        private Control CreateControl(string controlType, string controlName)
        {
            switch (controlType.ToLower())
            {
                case "textbox":
                    TextBox textBox = new TextBox
                    {
                        Name = controlName,
                        Text = null,
                        Multiline = true
                    };
                    if (textBox.Height > 50)
                    { textBox.ScrollBars = ScrollBars.Vertical; }
                    return textBox;
                case "label":
                    return new Label { Name = controlName, Text = controlName };
                case "button":
                    return new Button { Name = controlName, Text = controlName };
                case "integerinput":
                    return new IntegerInput { Name = controlName, Text = null, WatermarkText = "Enter Int" };
                case "doubleinput":
                    return new DoubleInput { Name = controlName, Text = null, WatermarkText = "Enter Double" };
                case "checkbox":
                    return new CheckBox { Name = controlName, Text = controlName, Checked = false };
                default:
                    throw new ArgumentException($"Unsupported control type: {controlType}");
            }
        }

        private string GetDataType(string controlType)
        {
            switch (controlType.ToLower())
            {
                case "textbox":
                    return "NVARCHAR(255)";
                case "integerinput":
                    return "INT";
                case "doubleinput":
                    return "FLOAT";
                case "checkbox":
                    return "BIT";
                default:
                    throw new ArgumentException($"Unsupported control type: {controlType}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxForms.SelectedItem == null)
            {
                MessageBox.Show("Please select a form first.");
                return;
            }

            string formName = ((ComboBoxItem)comboBoxForms.SelectedItem).Name;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // distinct control names of type 'textbox' or 'integerinput' for the selected form
                SqlDataAdapter detailAdapter = new SqlDataAdapter($"SELECT DISTINCT ControlName, ControlType FROM DetailTable WHERE FormID = (SELECT ID FROM MasterTable WHERE FormName = '{formName}')", connection);
                DataTable controlInfoTable = new DataTable();
                detailAdapter.Fill(controlInfoTable);

                // Check for duplicate column names
                HashSet<string> uniqueColumns = new HashSet<string>();
                List<string> columns = new List<string>();

                // Control names from DetailTable and add columns to the list
                foreach (DataRow row in controlInfoTable.Rows)
                {
                    string columnName = row["ControlName"].ToString().Trim();
                    string controlType = row["ControlType"].ToString().Trim();

                    // Skip Label controls
                    if (controlType.Equals("label", StringComparison.OrdinalIgnoreCase) || controlType.Equals("button", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (!uniqueColumns.Contains(columnName))
                    {
                        uniqueColumns.Add(columnName);
                        columns.Add(columnName);
                    }
                }


                // Check if there are columns to insert
                if (columns.Count > 0)
                {
                    // Check if the table already exists
                    string checkTableQuery = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{formName}'";
                    SqlCommand checkTableCommand = new SqlCommand(checkTableQuery, connection);
                    int tableExists = (int)checkTableCommand.ExecuteScalar();

                    if (tableExists == 0)
                    {
                        // CREATE TABLE 
                        string createTableQuery = $"CREATE TABLE {formName} (ID INT IDENTITY(1,1) PRIMARY KEY";

                        // Add columns to the new table
                        foreach (string columnName in columns)
                        {
                            string dataType = GetDataType(controlTypeDict[columnName]);
                            createTableQuery += $", [{columnName}] {dataType}";
                        }

                        createTableQuery += ")";

                        // Execute the SQL CREATE TABLE command
                        using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
                        {
                            createTableCommand.ExecuteNonQuery();
                        }
                    }

                    // INSERT DATA query
                    string insertDataQuery = $"INSERT INTO {formName} (";

                    // Add columns 
                    bool firstColumn = true;
                    foreach (string columnName in columns)
                    {
                        if (!firstColumn)
                        {
                            insertDataQuery += ", ";
                        }
                        insertDataQuery += "[" + columnName + "]";
                        firstColumn = false;
                    }

                    insertDataQuery += ") VALUES (";

                    // Add parameter for each column
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            insertDataQuery += ", ";
                        }
                        insertDataQuery += $"@{columns[i]}";
                    }

                    insertDataQuery += ")";

                    // SQL INSERT command
                    using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                    {
                        try
                        {
                            // Add parameter values from the form controls
                            foreach (string columnName in columns)
                            {
                                string paramName = $"@{columnName}";
                                Control formControl = panelControls.Controls[columnName];

                                if (formControl != null && formControl is TextBox textBoxControl)
                                {
                                    insertDataCommand.Parameters.AddWithValue(paramName, textBoxControl.Text);
                                }
                                else if (formControl != null && formControl is IntegerInput integerInputControl)
                                {
                                    insertDataCommand.Parameters.AddWithValue(paramName, integerInputControl.Value);
                                }
                                else if (formControl != null && formControl is DoubleInput DoubleInputControl)
                                {
                                    insertDataCommand.Parameters.AddWithValue(paramName, DoubleInputControl.Value);
                                }
                                else if (formControl is CheckBox checkBoxControl)
                                {
                                    insertDataCommand.Parameters.AddWithValue(paramName, checkBoxControl.Checked);
                                }
                                else
                                {
                                    insertDataCommand.Parameters.AddWithValue(paramName, DBNull.Value);
                                }
                            }

                            // Execute the SQL INSERT command
                            insertDataCommand.ExecuteNonQuery();

                            MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private class ComboBoxItem
        {
            public int Id { get; }
            public string Name { get; }

            public ComboBoxItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
