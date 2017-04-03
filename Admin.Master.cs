using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security; // added lab 5  all updated

namespace SE256demoWEEK1
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region
                List<MenuItem> lmi = Menus.GetAdminMenu();
                foreach (MenuItem mi in lmi)
                {
                    mnuMain.Items.Add(mi);

                }

                #endregion
            }

            // # 5 The master pages (public and Admin versions) will need to show the appropriate login/out function by means of button control
            //(Link Button, Image Button, Button or menu item) in relation to current authentication status 
            //(If Request.IsAuthenticated) and a greeting will need to show the Full Name (stored in Session) 
            //if authenticated and a generic greeting if not authenticated.  
            
            //check to see if the browser has a valid authentication 
            //ticket for current user's session. If so, manipulate the 
            //log in and log out links and welcome message
            {
                if (Request.IsAuthenticated)
                {
                    //this means we are logged in so hide the login button
                    lbtnLogin.Visible = false;
                    //since we are logged in we can provide the link to logout
                    lbtnLogOut.Visible = true;
                    //generate a personalized text message to display on the site
                    //Grab the cookie
                    if (Session["FullName"] != null)
                    {
                        lblGreeting.Text = String.Concat("Welcome ", Session["FullName"].ToString());
                        //enable menu when user is authenticated
                    }
                }
                else
                {
                    //Since we have not been authenticated, we have to provide
                    //a link to log in with
                    lbtnLogin.Visible = true;
                    //hide logout button since user is not authenticated

                    lbtnLogOut.Visible = false;
                    //generate a generic text message to display on the site
                    lblGreeting.Text = "Welcome Stranger";
                }
            }
        }
        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            //when log in link is clicked, send them to the login page
            Response.Redirect("~/Sign-In");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        // Log User Off from Cookie Authentication System
        //(.NET built in security system)
        {
            FormsAuthentication.SignOut();
            //set name session variable to nothing
            Session["FullName"] = null;
            // Redirect user back to the Home Page
            Response.Redirect("~/Home");
        }


    }
}
