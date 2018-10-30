using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectCSharp
{
    class DAO
    {
        private const String sqlStringConnection = @"Data Source=localhost; Initial Catalog=QLSVien; uid=sa; pwd=123456";

        private SqlConnection sqlCon;
        private SqlCommand cmd;
        private SqlDataReader reader;

        private void closeConnection()
        {
            if(reader != null)
            {
                reader.Close();
            }
            if(sqlCon != null)
            {
                sqlCon.Close();
            }

        }

        public List<String> getAllDepartmentIDs()
        {
            sqlCon = new SqlConnection(sqlStringConnection);
            sqlCon.Open();
            List<String> result = new List<string>();
            cmd = new SqlCommand("Select ID from KHOA", sqlCon);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ID = reader.GetString(0);
                result.Add(ID);
            }
            closeConnection();
            return result;
        }

        public List<DepartmentDTO> getAllDepartments()
        {
            // to do
            return null;
        }

        public DepartmentDTO getDepartmentDetail(String id)
        {
            //to do
            return null; 
        }

        public DepartmentDTO addDepartment(DepartmentDTO dto)
        {
            return null;
        }

        public DepartmentDTO deleteDepartment(String id)
        {
            return null;
        }

        public DepartmentDTO updateDepartment(String id, DepartmentDTO dto)
        {
            return null;
        } 
    }
}
