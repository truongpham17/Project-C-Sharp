using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectCSharp {
    class MyConnection {
        public static SqlConnection getConnection() {
            String sqlStringConnection = @"Data Source=localhost; Initial Catalog=QLSVien; uid=sa; pwd=123456";
            return new SqlConnection(sqlStringConnection);
        }
    }
}
