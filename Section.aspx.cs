using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256demoWEEK1
{
    public partial class Section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            else
            {

                int sect_id = Convert.ToInt32(RouteData.Values["sect_id"]);
                if (!IsPostBack)
                {
                    if (sect_id > 0)  // if there is a section id
                    {
                        lbtnUpdate.Text = "Update";
                        SectionCS mt = new SectionCS(sect_id);
                        txtName.Text = mt.Sect_Name;
                        txtDescription.Text = mt.Sect_Desc;
                        chkIsActive.Checked = mt.Sect_Active;
                    }
                    else  // if no section id go to add
                    {
                        lbtnUpdate.Text = "Add";
                        txtName.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                        chkIsActive.Checked = false;
                    }
                }
            }
        }
        protected void lbtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Sections");
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            string updateBUTTON = lbtnUpdate.Text;

            if (updateBUTTON == "Update")
            {
                SectionCS sr = new SectionCS();
                if (RouteData.Values["sect_id"] != null)
                {
                    bool success = false;
                    sr.Sect_ID = Convert.ToInt32(RouteData.Values["sect_id"]);
                    sr.Sect_Name = txtName.Text.Trim();
                    sr.Sect_Desc = txtDescription.Text.Trim();
                    sr.Sect_Active = chkIsActive.Checked;

                    success = SectionCS.UpdateSectionItems(sr);

                    if (success)  // if update section is true
                    {
                        Response.Redirect("/Admin/Sections");
                    }
                }
            }

            else  // insert section
            {
                bool success = false;
                SectionCS sr = new SectionCS();
                sr.Sect_ID = Convert.ToInt32(RouteData.Values["sect_id"]);
                sr.Sect_Name = txtName.Text.Trim();
                sr.Sect_Desc = txtDescription.Text.Trim();
                sr.Sect_Active = chkIsActive.Checked;

                success = SectionCS.InsertSectionItem(sr);

                if (success)  // if insert section is true
                {
                    Response.Redirect("/Admin/Sections");
                }
            }
        }
    }
}