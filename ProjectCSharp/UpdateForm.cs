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
    public partial class UpdateForm : Form
    {

        // biến này để lấy dữ liệu(ID) từ form1
        public Form1 form1;
        public UpdateForm()
        {
            InitializeComponent();
        }

        public UpdateForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

            // lấy dữ liệu và gán dữ liệu
            DepartmentDTO department = new DAO().getDepartmentDetail(form1.cbId.SelectedItem.ToString());
            txtID.Text = department.Id;
            txtName.Text = department.Name;
            txtYear.Text = department.Year + "";

            // ID là readonly
            txtID.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flat = true;
            string alertMsg = "";
            int year = 0;
            int currentYear = Int32.Parse(DateTime.Now.Year.ToString());

            // check validate
            if (txtName.Text.Length == 0)
            {
                flat = false;
                alertMsg += "Vui lòng nhập tên Khoa!\n";
            }
            if (txtYear.Text.Length == 0)
            {
                flat = false;
                alertMsg += "Vui lòng nhập năm thành lập!\n";
            }
            try
            {
                year = Int32.Parse(txtYear.Text);
                if (year > currentYear || year < 1900)
                {
                    flat = false;
                    alertMsg += "Vui lòng nhập năm bằng số và từ 1900 đến " + currentYear + "!";
                }

            }
            catch (Exception exception)
            {
                flat = false;
                alertMsg += "Vui lòng nhập năm bằng số và từ 1900 đến " + currentYear + "!";
            }

            if (!flat)
            {

                // nếu có lỗi thì thông báo
                MessageBox.Show(alertMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {

                // ngược lại thì update dữ liệu vào database 
                bool updateResult = new DAO().updateDepartment(new DepartmentDTO(txtID.Text, txtName.Text, year));
                if (updateResult)
                {
                    MessageBox.Show("Sửa khoa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa khoa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
