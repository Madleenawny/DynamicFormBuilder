using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTestWithDB
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createFBtn_Click(object sender, EventArgs e)
        {
            CreateForm secondForm = new CreateForm();
            secondForm.Show();
        }

        private void FormsBtn_Click(object sender, EventArgs e)
        {
            Forms ThirdForm = new Forms();
            ThirdForm.Show();
        }

       
    }
}
