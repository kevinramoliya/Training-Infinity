using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class BAL_stop_master
    {
        public static int insert_stop_details(string Stop_name)
        {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_insert_stop_master";
            cmd.Parameters.Add(para.StringInputPara("@stop_name", Stop_name));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
        }
        public static DataTable get_stop_details()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "kevin_select_stop_master";

            return Command.ExecuteQuery(cmd);
        }
        public static int delete_stop_details(int stopid) {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_delete_stop_master";
            cmd.Parameters.Add(para.IntInputPara("stop_id", stopid));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
        }
    }
}