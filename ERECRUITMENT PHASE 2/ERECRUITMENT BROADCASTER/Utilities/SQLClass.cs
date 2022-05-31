using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERECRUITMENT_BROADCASTER.Utilities
{
    public class SQLClass
    {
        static string ConnectionDB = ConfigurationManager.ConnectionStrings["SQLCON"].ToString();
        bool disposed = false;
        public SqlConnection SqlConHd = new SqlConnection();
    }
}
