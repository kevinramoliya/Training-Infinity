using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class BAL_student_master
    {
        public static int insert_student_details(string student_name, string student_email, string student_address, string student_gender, string student_city, string student_mobile)
        {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "Kevin_insert_student_master";
            cmd.Parameters.Add(para.StringInputPara("@student_name", student_name));
            cmd.Parameters.Add(para.StringInputPara("@student_email", student_email));

            cmd.Parameters.Add(para.StringInputPara("@student_address", student_address));

            cmd.Parameters.Add(para.StringInputPara("@student_gender", student_gender));
            cmd.Parameters.Add(para.StringInputPara("@student_city", student_city));
            cmd.Parameters.Add(para.StringInputPara("@student_mobile", student_mobile));

            int result = Command.ExecuteNonQuery(cmd);
            return result;

        }
        public static int update_student_details(int student_id, string student_name, string student_email, string student_address, string student_gender, string student_city, string student_mobile) {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.CommandText = "kevin_update_student_master";
            cmd.Parameters.Add(para.IntInputPara("@student_id", student_id));
            cmd.Parameters.Add(para.StringInputPara("@student_name", student_name));
            cmd.Parameters.Add(para.StringInputPara("@student_email", student_email));
            cmd.Parameters.Add(para.StringInputPara("@student_address", student_address));
            cmd.Parameters.Add(para.StringInputPara("@student_gender", student_gender));
            cmd.Parameters.Add(para.StringInputPara("@student_city", student_city));
            cmd.Parameters.Add(para.StringInputPara("@student_mobile", student_mobile));

            int result = Command.ExecuteNonQuery(cmd);
            return result;

        }

        public static DataTable get_student_details()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Kevin_select_student_master";


            return Command.ExecuteQuery(cmd);
        }

        public static int del_student_details(int student_id)
        {
            SqlCommand cmd = new SqlCommand();
            parameter para = new parameter();
            cmd.Parameters.Add(para.IntInputPara("@student_id", student_id));
            cmd.CommandText = "Kevin_delete_student_master";

            int result = Command.ExecuteNonQuery(cmd);
            return result;


        }
        internal static DataTable EditRecord(int editID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "kevin_selectbypk_student_master";
            cmd.Parameters.AddWithValue("@stuent_id", editID);
            return Command.ExecuteQuery(cmd);
        }

        //public static DataTable update_student_details(int student_id) {
        //    SqlCommand cmd = new SqlCommand();
        //    parameter para = new parameter();
        //    cmd.Parameters.Add(para.IntInputPara("@student_id", student_id));
        //    cmd.CommandText = "kevin_selectbypk_student_master";

        //    return   Command.Execute(cmd);


        //}
    }
}