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
            sqlCon = MyConnection.getConnection();
            sqlCon.Open();
            List<String> result = new List<string>();
            cmd = new SqlCommand("SELECT MAKHOA FROM KHOA", sqlCon);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetString(0);
                result.Add(id);
            }
            closeConnection();
            return result;
        }

        public List<DepartmentDTO> getAllDepartments()
        {
            sqlCon = MyConnection.getConnection();
            sqlCon.Open();
            List<DepartmentDTO> result = new List<DepartmentDTO>();
            cmd = new SqlCommand("SELECT MAKHOA, TENKHOA, NAMTHANHLAP FROM KHOA", sqlCon);
            reader = cmd.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetString(0);
                var name = reader.GetString(1);
                var year = reader.GetInt16(2);
                result.Add(new DepartmentDTO(id, name, year));
            }
            closeConnection();
            return result;
        }

        public DepartmentDTO getDepartmentDetail(String id)
        {
            sqlCon = MyConnection.getConnection();
            sqlCon.Open();
            DepartmentDTO result = null;
            cmd = new SqlCommand("SELECT TENKHOA, NAMTHANHLAP FROM KHOA WHERE MAKHOA = '" + id + "'", sqlCon);
            reader = cmd.ExecuteReader();
            if (reader.Read()) {
                var name = reader.GetString(0);
                var year = reader.GetInt16(1);
                result = new DepartmentDTO(id, name, year);
            }
            closeConnection();
            return result;
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
