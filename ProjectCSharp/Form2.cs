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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // biến kiểm tra validate
            bool flat = true;

            // string message dành cho thông báo
            string alertMsg = "";

            // năm sau khi chuyển năm trong txtYear thành kiểu int
            int year = 0;

            // năm hiện tại
            int currentYear = Int32.Parse(DateTime.Now.Year.ToString());

            if (txtID.Text.Length == 0)
            {
                flat = false;
                alertMsg = "Vui lòng nhập ID!\n";
            }
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
                // thử chuyển năm thành int
                year = Int32.Parse(txtYear.Text);

                // năm phải bé hơn năm hiện tại và lớn hơn 1900
                if(year > currentYear || year < 1900)
                {
                    flat = false;
                    alertMsg += "Vui lòng nhập năm bằng số và từ 1900 đến " + currentYear + "!";
                }

            } catch(Exception exception)
            {
                flat = false;
                alertMsg += "Vui lòng nhập năm bằng số và từ 1900 đến " + currentYear + "!";
            }
            if (!flat)
            {
                MessageBox.Show(alertMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {

                // nếu validate thành công thì thử add vào database
                bool addResult = new DAO().addDepartment(new DepartmentDTO(txtID.Text, txtName.Text, year));

                // nếu add thành công thì thông báo cho người dùng
                if (addResult)
                {
                    MessageBox.Show("Thêm khoa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                // ngược lại thì có thể lỗi là do trùng ID
                else
                {
                    MessageBox.Show("Trùng ID, vui lòng nhập ID khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

    
    }
}
