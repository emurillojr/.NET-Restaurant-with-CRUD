using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256demoWEEK1
{
    public partial class Table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            else
            {

                int tbl_id = Convert.ToInt32(RouteData.Values["tbl_id"]);
                if (!IsPostBack)
                {
                    if (tbl_id > 0)  // if there is a table id
                    {
                        lbtnUpdate.Text = "Update";
                        TableCS mt = new TableCS(tbl_id);
                        txtName.Text = mt.Tbl_Name;
                        txtDescription.Text = mt.Tbl_Desc;
                        ddlSection.SelectedValue = mt.Sect_ID.ToString();
                        txtSeatCount.Text = mt.Tbl_Seat_Cnt.ToString();
                        chkIsActive.Checked = mt.Tbl_Active;
                    }
                    else  // if no table id go to add
                    {
                        lbtnUpdate.Text = "Add";
                        TableCS mt = new TableCS(tbl_id);
                        txtName.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                        ddlSection.SelectedValue = null;
                        txtSeatCount.Text = String.Empty;
                        chkIsActive.Checked = false;
                    }
                }
            }

        }
        protected void lbtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Tables");
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            string updateBUTTON = lbtnUpdate.Text;

            if (updateBUTTON == "Update")    // update table
            {
                TableCS sr = new TableCS();
                if (RouteData.Values["tbl_id"] != null)
                {
                    bool success = false;
                    sr.Tbl_ID = Convert.ToInt32(RouteData.Values["tbl_id"]);
                    sr.Sect_ID = Convert.ToInt32(ddlSection.SelectedValue);
                    sr.Tbl_Name = txtName.Text.Trim();
                    sr.Tbl_Desc = txtDescription.Text.Trim();
                    sr.Tbl_Seat_Cnt = Convert.ToInt32(txtSeatCount.Text);
                    sr.Tbl_Active = chkIsActive.Checked;

                    success = TableCS.UpdateTable(sr);

                    if (success)  // if update menu is true
                    {
                        Response.Redirect("/Admin/Tables");
                    }
                }
            }

            else   // insert table
            {
                bool success = false;
                TableCS sr = new TableCS();
                sr.Tbl_ID = Convert.ToInt32(RouteData.Values["tbl_id"]);
                sr.Sect_ID = Convert.ToInt32(ddlSection.SelectedValue.ToString());
                sr.Tbl_Name = txtName.Text.Trim();
                sr.Tbl_Desc = txtDescription.Text.Trim();
                sr.Tbl_Seat_Cnt = Convert.ToInt32(txtSeatCount.Text);
                sr.Tbl_Active = chkIsActive.Checked;

                success = TableCS.InsertTable(sr);

                if (success)  // if insert menu is true
                {
                    Response.Redirect("/Admin/Tables");
                }
            }
        }
    }
}
