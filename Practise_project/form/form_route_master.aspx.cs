using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practise_project.Route
{
    public partial class form_route_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridview();
        }
        public void gridview() { 

            DataTable dt = BAL.BAL_route_master.get_route_details();
            grid_route.DataSource = dt;
            grid_route.DataBind();

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string routename = txt_route.Text;
            string routetime = txt_start_time.Text;

            int ret_id = BAL.BAL_route_master.insert_route_details(routename, routetime);
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
        private void Reload()
        {
            txt_route.Text = string.Empty;
            txt_start_time.Text = string.Empty;
        }

        protected void grid_route_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_data") {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                int ret_id = BAL.BAL_route_master.delete_route_details(id);
                if (ret_id > 0) {
                    message.Text = "Record Deleted Successfully";
                    message.Style.Add("color", "red");
                }
                gridview();
            }

        }

       
    }
    }
