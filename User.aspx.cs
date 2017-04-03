using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256demoWEEK1
{

    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            else
            {

                int user_id = Convert.ToInt32(RouteData.Values["user_id"]);
                if (!IsPostBack)
                {
                    if (user_id > 0)  //if there is a user id
                    {
                        lbtnUpdate.Text = "Update";
                        UserCS mt = new UserCS(user_id);
                        txtFirstName.Text = mt.User_First;
                        txtLastName.Text = mt.User_Last;
                        txtAddress1.Text = mt.User_Add1;
                        txtAddress2.Text = mt.User_Add2;
                        txtCity.Text = mt.User_City;
                        ddlStates.SelectedValue = mt.State_ID.ToString();
                        txtZip.Text = mt.User_Zip;
                        txtPassword.Text = mt.User_Salt;  //salt
                        txtConfirmPassword.Text = mt.User_Pwd;   // password
                        txtEmail.Text = mt.User_Email;
                        txtConfirmEmail.Text = mt.User_Email;
                        txtPhone.Text = mt.User_Phone;
                        chkIsActive.Checked = mt.User_Active;
                    }
                    else  // if there is no user id go to add
                    {
                        lbtnUpdate.Text = "Add";
                        UserCS mt = new UserCS(user_id);
                        txtFirstName.Text = String.Empty;
                        txtLastName.Text = String.Empty;
                        txtAddress1.Text = String.Empty;
                        txtAddress2.Text = String.Empty;
                        txtCity.Text = String.Empty;
                        ddlStates.SelectedValue = null;
                        txtZip.Text = String.Empty;
                        txtPassword.Text = String.Empty;   //salt
                        txtConfirmPassword.Text = String.Empty;   //password
                        txtEmail.Text = String.Empty;
                        txtConfirmEmail.Text = String.Empty;
                        txtPhone.Text = String.Empty;
                        chkIsActive.Checked = false;
                    }
                }
            }
        }
        protected void lbtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Users");
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            string updateBUTTON = lbtnUpdate.Text;

            if (updateBUTTON == "Update")  // update user
            {
                UserCS sr = new UserCS();
                if (RouteData.Values["user_id"] != null)
                {
                    bool success = false;
                    sr.User_ID = Convert.ToInt32(RouteData.Values["user_id"]);
                    sr.User_Email = txtEmail.Text.Trim();
                    sr.User_First = txtFirstName.Text.Trim();
                    sr.User_Last = txtLastName.Text.Trim();
                    sr.User_Add1 = txtAddress1.Text.Trim();
                    sr.User_Add2 = txtAddress2.Text.Trim();
                    sr.User_City = txtCity.Text.Trim();
                    sr.State_ID = ddlStates.SelectedValue;
                    sr.User_Zip = txtZip.Text.Trim();
                    sr.User_Salt = txtPassword.Text.Trim();  // salt
                    sr.User_Pwd = txtConfirmPassword.Text.Trim();  // password
                    sr.User_Phone = txtPhone.Text.Trim();
                    sr.User_Active = chkIsActive.Checked;

                    success = UserCS.UpdateUser(sr);

                    if (success)
                    {
                        Response.Redirect("/Admin/Users");
                    }
                }
            }

            else  // inser user
            {
                bool success = false;
                UserCS sr = new UserCS();
                sr.User_Email = txtEmail.Text.Trim();
                sr.User_First = txtFirstName.Text.Trim();
                sr.User_Last = txtLastName.Text.Trim();
                sr.User_Add1 = txtAddress1.Text.Trim();
                sr.User_Add2 = txtAddress2.Text.Trim();
                sr.User_City = txtCity.Text.Trim();
                sr.State_ID = ddlStates.SelectedValue;
                sr.User_Zip = txtZip.Text.Trim();
                sr.User_Salt = txtPassword.Text.Trim();
                sr.User_Pwd = txtConfirmPassword.Text.Trim();
                sr.User_Phone = txtPhone.Text.Trim();
                sr.User_Active = chkIsActive.Checked;

                success = UserCS.InsertUser(sr);

                if (success)
                {
                    Response.Redirect("/Admin/Users");
                }
            }
        }
    }
}