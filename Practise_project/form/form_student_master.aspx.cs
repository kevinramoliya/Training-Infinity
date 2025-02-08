using Practise_project.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practise_project.Student
{
    public partial class form_student_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    edit_data(Convert.ToInt32(Request.QueryString["id"]));
                }
            gridview();

            }

        }

        private void gridview() {

            DataTable dt = BAL_student_master.get_student_details();
            if (dt.Rows.Count > 0)
            {
                grid_stud.DataSource = dt;
                grid_stud.DataBind(); }
            

        }





        protected void SubmitBtnClick(object sender, EventArgs e)
        {
            string sname = Sname.Text;
            string semail = SEmail.Text;
            string saddress = SAddress.Text;
            string rblist = rblGender.SelectedValue;
            string city = DropDownList1.SelectedValue;
            string mnumber = Mnumber.Text;

            if (Request.QueryString["id"]!=null && !string.IsNullOrEmpty(Request.QueryString["id"]) ) {
                int edit_id = Convert.ToInt32(Request.QueryString["id"]);
                string name = Convert.ToString(sname);
                int ret_id = BAL.BAL_student_master.update_student_details(edit_id, sname, semail, saddress, rblist, city, mnumber);
                if (ret_id > 0) {
                    message.Text = "Record Update Successfully";
                    message.Style.Add("color", "green");
                    Reload();
                    gridview();
                }
            }
            else {
                int ret_id = BAL_student_master.insert_student_details(sname, semail, saddress, rblist, city, mnumber);
                if (ret_id > 0)
                {
                    message.Text = "Insert Successfully";
                    message.Style.Add("color", "green");
                    Reload();
                }
                else
                {
                    message.Text = "Eroor Ocuured:";
                    message.Style.Add("color", "red");
                }
                gridview();
            }
            
               
            

            
        }

        public void edit_data(int edit_id) { 
            DataTable dt = BAL.BAL_student_master.EditRecord(edit_id);
            Sname.Text = dt.Rows[0]["student_name"].ToString();
            SEmail.Text = dt.Rows[0]["student_email"].ToString();
            SAddress.Text = dt.Rows[0]["student_address"].ToString();
            rblGender.SelectedValue = dt.Rows[0]["student_gender"].ToString();
            DropDownList1.SelectedValue = dt.Rows[0]["student_city"].ToString();
            Mnumber.Text = dt.Rows[0]["student_mobile"].ToString();

        }

        private void Reload()
        {
            Sname.Text = string.Empty;
            SEmail.Text = string.Empty;
            SAddress.Text = string.Empty;
            Mnumber.Text = string.Empty;

            DropDownList1.SelectedValue = string.Empty;

         


            
        }

    

        protected void grid_stud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_data")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                int ret_id = BAL.BAL_student_master.del_student_details(id);
                if (ret_id > 0)
                {
                    message.Text = "record deleted";
                    message.Style.Add("color", "red");
                    gridview();
                }

            }
            else {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                //int editID = Convert.ToInt32(grid_stud.DataKeys[id].Value);


                string url = "form_student_master.aspx?id=" + id;
                string script = "window.open('" + url + "', '_blank');";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
                gridview();
            }   
           
            
            }

        protected void btn_edit_Command(object sender, CommandEventArgs e)
        {

            //    int id = Convert.ToInt32(e.CommandArgument.ToString());
            //    //int editID = Convert.ToInt32(grid_stud.DataKeys[id].Value);


            //    string url = "form_student_master.aspx?id=" + id;
            //    string script = "window.open('" + url + "', '_blank');";

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
            //gridview();

        }
    }
    }



