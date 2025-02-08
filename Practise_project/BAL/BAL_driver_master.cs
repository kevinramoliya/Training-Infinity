using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class BAL_driver_master
    {
        public static int insert_driver_details(string Driver_name, string Driver_number)
        {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_insert_driver_master";
            cmd.Parameters.Add(para.StringInputPara("@driver_name", Driver_name));
            cmd.Parameters.Add(para.StringInputPara("@driver_mobile_number", Driver_number));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
        }
        public static int update_driver_details(int driver_id, string driver_name, string driver_number)
        {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_update_driver_master";
            cmd.Parameters.Add(para.IntInputPara("@driver_id", driver_id));
            cmd.Parameters.Add(para.StringInputPara("@driver_name", driver_name));
            cmd.Parameters.Add(para.StringInputPara("@driver_mobile_number", driver_number));
            int result = Command.ExecuteNonQuery(cmd);
            return result;
        }
        public static DataTable edit_record(int driver_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "kevin_selectbypk_driver_master";
            cmd.Parameters.AddWithValue("@driver_id", driver_id);
            return Command.ExecuteQuery(cmd);
        }
        public static DataTable get_driver_details()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "kevin_select_driver_master";

            return Command.ExecuteQuery(cmd);
        }
        public static int delete_driver_details(int driverid) { 
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_delete_driver_master";
            cmd.Parameters.Add(para.IntInputPara("@driver_id", driverid));
            int result = Command.ExecuteNonQuery(cmd);

            return result;
        }
    }
}