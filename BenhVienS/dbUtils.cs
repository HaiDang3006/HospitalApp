using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS
{
    public class dbUtils
    {
        public static string ConnectionString =
           "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=BenhVienV1;Integrated Security=True;TrustServerCertificate=True";
        //"Data Source=DESKTOP-GA7P42L;Initial Catalog=benhvienv10;Integrated Security=True;Encrypt=true;TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
