using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class BAL_route_master
    {
        public static int insert_route_details(string Route_name, string Route_start_time)
        {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_insert_route_master";
            cmd.Parameters.Add(para.StringInputPara("@route_name", Route_name));
            cmd.Parameters.Add(para.StringInputPara("@route_start_time", Route_start_time));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
        }
        public static DataTable get_route_details()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "kevin_select_route_master";

            return Command.ExecuteQuery(cmd);
        }
        public static int delete_route_details(int route_id) {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_delete_route_master";
            cmd.Parameters.Add(para.IntInputPara("@route_id", route_id));
            int result = Command.ExecuteNonQuery(cmd);
            return result;

        }
    }
}