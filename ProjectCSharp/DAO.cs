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
        private string stringConn =  @"Data Source = localhost; Initial Catalog =QLSVien ;Persist Security Info=True;User ID= sa ;Password=123456";
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
            sqlCon = new SqlConnection(stringConn);
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
            sqlCon = new SqlConnection(stringConn);
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
            sqlCon = new SqlConnection(stringConn);
            sqlCon.Open();
            DepartmentDTO result = null;
            cmd = new SqlCommand("SELECT TENKHOA, NAMTHANHLAP FROM KHOA WHERE MAKHOA = '" + id + "'", sqlCon);
            reader = cmd.ExecuteReader();
            if (reader.Read()) {
                var name = reader.GetString(0);
                var year = reader.GetInt32(1);
                result = new DepartmentDTO(id, name, year);
            }
            closeConnection();
            return result;
        }

        public bool addDepartment(DepartmentDTO dto)
        {
            bool check = false;
            try
            {
                sqlCon = new SqlConnection(stringConn);
                sqlCon.Open();
                cmd = new SqlCommand(String.Format("INSERT INTO KHOA VALUES('{0}','{1}','{2}')", dto.Id, dto.Name, dto.Year), sqlCon);
                check = cmd.ExecuteNonQuery() > 0 ? true : false;
                closeConnection();
            }
            catch(Exception e)
            {

            }
           
            return check;
        }

        public bool deleteDepartment(String id)
        {
            bool check = false;
            sqlCon = new SqlConnection(stringConn);
            sqlCon.Open();
            cmd = new SqlCommand("DELETE from KHOA where MAKHOA = '" + id + "'", sqlCon);
            check = cmd.ExecuteNonQuery() > 0 ? true : false;
            closeConnection();
            return check;
        }

        public bool updateDepartment(DepartmentDTO dto)
        {
            bool check = false;
            sqlCon = new SqlConnection(stringConn);
            sqlCon.Open();
            cmd = new SqlCommand("UPDATE KHOA set MAKHOA = '" + dto.Id + "', TENKHOA = '" + dto.Name + "', NAMTHANHLAP = '"+ dto.Year+"' where MAKHOA = '" + dto.Id + "'", sqlCon);
            check = cmd.ExecuteNonQuery() > 0 ? true : false;
            closeConnection();
            return check;
        } 
    }
}
