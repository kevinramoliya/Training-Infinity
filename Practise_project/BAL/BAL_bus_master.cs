using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class BAL_bus_master
    {
        public static int insert_bus_details(string Bus_name, string Bus_number) {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "Kevin_insert_bus_master";
            cmd.Parameters.Add(para.StringInputPara("@bus_name", Bus_name));
            cmd.Parameters.Add(para.StringInputPara("@bus_number", Bus_number));
            cmd.Parameters.Add(para.IntOutputPara("@out_id"));
            int result = Command.ExecuteNonQuery(cmd);
            result = Convert.ToInt32(cmd.Parameters["@out_id"].Value);

            return result;
        }
        public static int update_bus_details(int bus_id, string bus_name, string bus_number) {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_update_bus_master";
            cmd.Parameters.Add(para.IntInputPara("@bus_id", bus_id));
            cmd.Parameters.Add(para.StringInputPara("@bus_name", bus_name));
            cmd.Parameters.Add(para.StringInputPara("@bus_number", bus_number));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
        }
        public static DataTable edit_record(int bus_id) {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "kevin_selectbypk_bus_master";
            cmd.Parameters.AddWithValue("@bus_id", bus_id);
            return Command.ExecuteQuery(cmd);
        }
       
        public static DataTable get_bus_details()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Kevin_select_bus_master";

            return Command.ExecuteQuery(cmd);
        }
        public static int delete_bus_details(int busid) {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_delete_bus_master";
            cmd.Parameters.Add(para.IntInputPara("@bus_id", busid));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
         
        }
    }
}