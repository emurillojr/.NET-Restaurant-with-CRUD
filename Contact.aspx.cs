using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256demoWEEK1
{
    public partial class Directions : System.Web.UI.Page
    {
        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home");
        }

        protected void lbtnSendMessage_Click(object sender, EventArgs e)
        {
            lblmessage.Text = "Thank you for sending your message.";
            txtGuestEmail.Text = String.Empty;
            txtName.Text = String.Empty;
            txtPhone.Text = String.Empty;

        }
    }
}