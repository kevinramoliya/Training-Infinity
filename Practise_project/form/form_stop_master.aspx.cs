using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practise_project.Stop
{
    public partial class form_stop_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                gridview();
            }
        }
        public void gridview() {
            DataTable dt = BAL.BAL_stop_master.get_stop_details();
            grid_stop.DataSource = dt;
            grid_stop.DataBind();
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string stopname = txt_stop.Text;
            

            int ret_id = BAL.BAL_stop_master.insert_stop_details(stopname);
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
            txt_stop.Text = string.Empty;






        }

        protected void grid_stop_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete_data") {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                int ret_id = BAL.BAL_stop_master.delete_stop_details(id);
                if (ret_id > 0) {
                    message.Text = "Record deleted Successfully";
                    message.Style.Add("color", "red");
                }
                gridview();
            }

        }

        
    }
}