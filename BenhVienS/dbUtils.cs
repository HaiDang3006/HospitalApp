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
           "Data Source=DESKTOP-2F65IMT;Initial Catalog=haidang6868;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //"Data Source=DESKTOP-2F65IMT;Initial Catalog=haidang6868 ;Integrated Security=True;Encrypt=true;TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
