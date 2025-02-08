using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Data.SqlClient;


namespace Practise_project.BAL
{
    public class Connection
    {
        public static SqlConnection Create_Connection() {
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            return cn;
        }

        public static SqlConnection Open_Connection() {
            SqlConnection cn = Create_Connection();
            cn.Open();
            return cn;
        }
        public static void Close_Connection()
        {
            SqlConnection cn = Create_Connection();
            cn.Close();
            cn.Dispose();

        }

    }
}