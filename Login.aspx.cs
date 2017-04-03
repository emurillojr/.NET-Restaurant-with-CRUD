using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Text;


namespace SE256demoWEEK1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // **** #3   for onclick event - lab 5
        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {





                // #3 Create an AppUser object
                AppUser au = new AppUser();

                // error message is not working - need to figure out why -----

                // Attempt to Validate User Credentials //create private variables for current web form
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    // #3 //and set its value to the AppUser class Login function return value sending the email and password 
                    // #3 //text box values from the form as parameters.
                    au = AppUser.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    lblMessage.Text = "Login Failed! You must enter a User name and Password!";
                    return;   // exits the function
                }

                // #3 // check the newly created AppUser object’s ValidLogin property value. 
                if (au.ValidLogin)
                // #3 // if the ValidLogin property value is “True”, create the FormsAuthentication Ticket within your Login.asxp login button’s click event.
                {

                    // Use .NET built in security system to set the UserID //within a client-side Cookie
                    FormsAuthenticationTicket t =
                        new FormsAuthenticationTicket(
                            1,
                            au.UserId.ToString(), // #3 // The value for the “Name” field in the ticket will be set from the  UserID property of your AppUser object.
                            DateTime.Now,
                            DateTime.Now.AddMinutes(480),
                            false,
                            "Admin");  // #3 // The value for the “userData” field in the ticket will be set statically to “Admin”.  

                    // #3 // encrypt the FormsAuthentication ticket and add it as a cookie to the Response object
                    //For security reasons we may hash the cookies
                    string encryptedTicked = FormsAuthentication.Encrypt(t);
                    HttpCookie c = new HttpCookie(
                        FormsAuthentication.FormsCookieName, encryptedTicked);
                    //add cookie to response
                    Response.Cookies.Add(c);

                    // # 4 // Create a Session variable called “FullName” and assign its value to the concatenated values of the AppUser’s FirstName and LastName properties.

                    //set the username to a client side cookie for future reference
                    Session["FullName"] = string.Concat(au.FirstName, " ", au.LastName);

                    // Redirect browser back to home page
                    Response.Redirect("~/Admin/Menu-Items");              // **** edited for week 5
                }
                // # 4 // If the ValidLogin property value is “False”, inform the user of a failed login attempt on the Login.aspx form.
                else
                {
                    lblMessage.Text = "Login Failed!";
                }
            }
            else
            {
                lblMessage.Text = "Login Failed! You must enter a User name and Password!";
                return;   // exits the function

            }
        }
    }
}