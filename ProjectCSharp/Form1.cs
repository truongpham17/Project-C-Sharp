using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbId.DataSource = (new DAO()).getAllDepartmentIDs();
            // fetch the number of department to textBox
            // fill the first department's name to textBox and gridView
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load Department info from database and bind to gridview
            // fill Department name to textBox
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Show Add dialog
            // Validate info
            // Add to database
            // Fetch ID again
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Show Add dialog
            // Cannot edit ID
            // Fill info to form
            // Validate info
            // Add to database
            // Fetch ID again
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show comfirm dialog
            // Ok : Fetch ID again
            // Not : nothing
        }
    }
}
