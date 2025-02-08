using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class Command
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        }

        public static DataTable ExecuteQuery(SqlCommand cmd)
        {
            SqlConnection cn = Connection.Create_Connection();
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;

        }


        public static int ExecuteNonQuery(SqlCommand cmd) {

            try
            {
                SqlConnection cn = Connection.Open_Connection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
            }
            finally
            {
                Connection.Close_Connection();
            }

            return cmd.ExecuteNonQuery();
        }
        
    }
}