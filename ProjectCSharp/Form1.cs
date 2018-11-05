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
        private void init_Data()
        {

            // kiêm tra xem gridview có chứa dữ liệu chưa, nếu có thì xóa đi
            if (gridView.Rows.Count > 1)
            {
                gridView.Rows.RemoveAt(0);
            }

            // lấy tất cả ID từ database để đưa vào combobox
            List<String> listIDs = new DAO().getAllDepartmentIDs();
            // đưa IDs vào combobox
            cbId.DataSource = listIDs;
            // đưa tổng khoa vào txtCount
            txtCount.Text = listIDs.Count + "";

            // kiểm tra xem trong database có ID nào không, nếu có thì điền dữ liệu vào gridview và txtName
            if (listIDs.Count > 0)
            {
                DepartmentDTO firstDepartment = new DAO().getDepartmentDetail(listIDs[0]);
                txtName.Text = firstDepartment.Name;


                gridView.ColumnCount = 2;
                gridView.Columns[0].Name = "ID";
                gridView.Columns[1].Name = "Name";
                string[] row = new string[] { firstDepartment.Id, firstDepartment.Name };
                gridView.Rows.Add(row);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init_Data();

            // set default size for gridView
            gridView.Columns[0].Width = 40;
            gridView.Columns[1].Width = 156;

            // these textbox is read only
            txtCount.ReadOnly = true;
            txtName.ReadOnly = true;

            // set style for combobox
            cbId.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e)
        {

            // lấy id được chọn từ combobox
            String id = cbId.SelectedItem.ToString();
            
            // lấy thông tin từ id được chọn
            DepartmentDTO department = new DAO().getDepartmentDetail(id);

            // kiểm tra xem gridview đã có dữ liệu hay chưa, nếu có thì xóa đi
            if(gridView.Rows.Count > 1)
            {
                gridView.Rows.RemoveAt(0);
            }

            // điền thông tin vào gridview
            string[] row = new string[] { department.Id, department.Name };
            gridView.Rows.Add(row);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            // form2 là form cho việc add khoa
            Form2 form = new Form2();
            form.Show();

            // nếu form2 đóng, thì load lại data
            form.FormClosed += new FormClosedEventHandler(Form_Close);
        }

        private void Form_Close(object sender, FormClosedEventArgs e)
        {
            init_Data();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateForm form = new UpdateForm(this);
            form.Show();

            // nếu form update đóng thì load lại data
            form.FormClosed += new FormClosedEventHandler(Form_Close);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa Khoa này không?", "Xóa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                new DAO().deleteDepartment(cbId.SelectedItem.ToString());
                init_Data();
            }
        }
    }
}
