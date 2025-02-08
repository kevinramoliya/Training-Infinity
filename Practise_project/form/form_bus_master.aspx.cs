using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practise_project.Bus
{
    public partial class form_bus_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    edit_data(Convert.ToInt32(Request.QueryString["id"]));
                }
                gridview();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string busname = b_name.Text;
            string busnumber = b_number.Text;
            if (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int editid = Convert.ToInt32(Request.QueryString["id"]);
                string bname = Convert.ToString(busname);
                string bnumber = Convert.ToString(busnumber);
                int ret_id = BAL.BAL_bus_master.update_bus_details(editid, bname, bnumber);
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
                int ret_id = BAL.BAL_bus_master.insert_bus_details(busname, busnumber);
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
        public void gridview()
        {
            DataTable dt = BAL.BAL_bus_master.get_bus_details();
            grid_bus.DataSource = dt;
            grid_bus.DataBind();

        }
        private void Reload()
        {
            b_name.Text = string.Empty;
            b_number.Text = string.Empty;
        }

        protected void grid_bus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_data")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                int ret_id = BAL.BAL_bus_master.delete_bus_details(id);
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
                String url = "form_bus_master.aspx?id=" + id;
                string script = "window.open('" + url + "','_blank')";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
            }

        }
        public void edit_data(int edit_id)
        {
            DataTable dt = BAL.BAL_bus_master.edit_record(edit_id);
            b_name.Text = dt.Rows[0]["bus_name"].ToString();
            b_number.Text = dt.Rows[0]["bus_number"].ToString();

        }
    }
}