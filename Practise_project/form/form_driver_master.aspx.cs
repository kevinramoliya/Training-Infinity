using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practise_project.Driver
{
    public partial class form_driver_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    edit_data1(Convert.ToInt32(Request.QueryString["id"]));
                }
                gridview();
            }
        }
        private void gridview()
        {
            DataTable dt = BAL.BAL_driver_master.get_driver_details();
            grid_driver.DataSource = dt;
            grid_driver.DataBind();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string drivername = txt_driver.Text;
            string drivernumber = txt_number.Text;
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int editid = Convert.ToInt32(Request.QueryString["id"]);
                string dname = Convert.ToString(drivername);
                string dnumber = Convert.ToString(drivernumber);
                int ret_id = BAL.BAL_driver_master.update_driver_details(editid, dname, dnumber);
                if (ret_id > 0)
                {
                    message.Text = "Record Updated Successfully...";
                    message.Style.Add("color", "green");

                    gridview();
                    Reload();
                }

            }
            else
            {
                int ret_id = BAL.BAL_driver_master.insert_driver_details(drivername, drivernumber);
                if (ret_id > 0)
                {
                    message.Text = "record Added Succesfully";
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
        private void Reload()
        {
            txt_driver.Text = string.Empty;
            txt_number.Text = string.Empty;






        }

        protected void grid_driver_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_data")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                int ret_id = BAL.BAL_driver_master.delete_driver_details(id);
                if (ret_id > 0)
                {
                    message.Text = "Record Deleted Successfully";
                    message.Style.Add("color", "red");
                }
                gridview();

            }
            else
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                String url = "form_driver_master.aspx?id=" + id;
                string script = "window.open('" + url + "','_blank')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
            }

        }
        public void edit_data1(int edit_id)
        {
            DataTable dt = BAL.BAL_driver_master.edit_record(edit_id);
            txt_driver.Text = dt.Rows[0]["driver_name"].ToString();
            txt_number.Text = dt.Rows[0]["driver_mobile_number"].ToString();

        }
    }
}