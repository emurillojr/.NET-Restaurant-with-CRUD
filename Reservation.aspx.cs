using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SE256demoWEEK1
{
    public partial class Reservation : System.Web.UI.Page
    {
       

        int res_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Request.IsAuthenticated)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            //else
            //{

                if (!IsPostBack)
                {
                    res_id = Convert.ToInt32(RouteData.Values["res_id"]);

                    BindTime();
                    if (res_id > 0)  // if there is a res id
                    {
                        lbtnUpdate.Text = "Update";
                        GUESTINFO.Visible = false; // hide guest information on update hide 

                        ReservationCS mt = new ReservationCS(res_id);
                        hidetxtGuestID.Value = mt.Guest_ID.ToString();   // make it hidden
                                                                         //txtGuestID.Text = mt.Guest_ID.ToString();
                        hidetxtTblID.Value = mt.Tbl_ID.ToString();  // make it hidden
                                                                    //txtTblID.Text = mt.Tbl_ID.ToString();
                        ddlEmployee.SelectedValue = mt.User_ID.ToString();   // changed it to ddl  user id to employee name   edited users get all sotred procedure
                                                                             //txtUserID.Text = mt.User_ID.ToString();

                        txtResDate.Text = mt.Res_Date;
                        ddlResTime.SelectedValue = mt.Res_Time.ToString();
                        txtResGuestCnt.Text = mt.Res_Guest_Cnt.ToString();
                        txtResSpecReq.Text = mt.Res_Spec_Req;
                    }
                    else  // if no res id go to add
                    {
                        //lbtnUpdate.Text = "Add";

                        GuestCS ng = new GuestCS();
                        txtGuestEmail.Text = ng.Guest_Email;
                        txtGuestFirstName.Text = ng.Guest_First;
                        txtGuestLastName.Text = ng.Guest_Last;
                        txtGuestPhone.Text = ng.Guest_Phone;

                        ReservationCS mt = new ReservationCS(res_id);
                        ddlEmployee.SelectedValue = null;  // changed it to ddl  user id to employee name
                        txtResDate.Text = String.Empty;
                        ddlResTime.SelectedValue = null;
                        txtResGuestCnt.Text = String.Empty;
                        txtResSpecReq.Text = String.Empty;
                    }
                }
          //  }
        }
     
        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Res-Management");
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            ReservationCS sr = new ReservationCS();
            //string updateBUTTON = lbtnUpdate.Text;

            //    if (updateBUTTON == "Update")   // update reservation
            //   {
            //ReservationCS sr = new ReservationCS();
            if (RouteData.Values["res_id"] != null)
            {
                bool success = false;
                sr.Res_ID = Convert.ToInt32(RouteData.Values["res_id"]);
                sr.Guest_ID = Convert.ToInt32(hidetxtGuestID.Value);   // make it hidden
                                                                       //sr.Guest_ID = Convert.ToInt32(txtGuestID.Text.Trim());
                sr.Tbl_ID = Convert.ToInt32(hidetxtTblID.Value); // make it hidden
                                                                 //sr.Tbl_ID = Convert.ToInt32(txtTblID.Text.Trim());
                sr.User_ID = Convert.ToInt32(ddlEmployee.SelectedValue);  // changed it to ddl  user id to employee name
                                                                          //sr.User_ID = Convert.ToInt32(txtUserID.Text.Trim());
                sr.Res_Date = txtResDate.Text.ToString();
                sr.Res_Time = ddlResTime.SelectedValue.ToString();
                sr.Res_Guest_Cnt = Convert.ToInt32(txtResGuestCnt.Text.Trim());
                sr.Res_Spec_Req = txtResSpecReq.Text.Trim();

                success = ReservationCS.UpdateReservation(sr);

                if (success) // if update reservation is true
                {
                    Response.Redirect("/Admin/Res-Management");
                }

            }
            // }

            else  // insert reservation
            {
                //bool success = false;
                int new_id = 0;

                GuestCS ng = new GuestCS();

                ng.Guest_Pwd = UserCS.CreatePasswordHash(ng.Guest_Salt, "password");
                ng.Guest_First = txtGuestFirstName.Text.Trim();
                ng.Guest_Last = txtGuestLastName.Text.Trim();

                ng.Guest_Email = txtGuestEmail.Text.Trim();
                ng.Guest_Phone = txtGuestPhone.Text.Trim();

                GuestCS g = new GuestCS(txtGuestEmail.Text);
                if (g.Guest_ID > 0)
                {
                    sr.Guest_ID = g.Guest_ID;
                }
                else
                {
                    sr.Guest_ID = GuestCS.InsertGuest(ng);
                }
                //ReservationCS sr = new ReservationCS();
                // sr.Guest_ID = GuestCS.InsertGuest(ng);  // guest id = new id

                sr.Tbl_ID = ReservationCS.GetAvailableTable(txtResDate.Text, ddlResTime.SelectedValue, Convert.ToInt32(txtResGuestCnt.Text));  // card coded for test
                sr.User_ID = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());  // changed it to ddl  user id to employee name
                sr.Res_Date = txtResDate.Text.Trim();
                sr.Res_Time = ddlResTime.SelectedValue;
                sr.Res_Guest_Cnt = Convert.ToInt32(txtResGuestCnt.Text);
                sr.Res_Spec_Req = txtResSpecReq.Text.Trim();

                new_id = ReservationCS.InsertReservation(sr);

                //if (success) // if insert guest and reservation is true
                //{
                //    Response.Redirect("/Admin/Res-Management");
                //}
                //else
                //{
                lblError.Text = String.Concat("The Email " + ng.Guest_Email + " The Reservation id is " + new_id);
                //}


            }
        }

        private void BindTime()
        {
            //convert to dictionary
            Dictionary<string, string> customersDict = new Dictionary<string, string>();
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("11:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:00", "HH:mm", null);
            // Set 15 minutes interval
            TimeSpan Interval = new TimeSpan(0, 15, 0);

            while (StartTime <= EndTime)
            {
                customersDict.Add(StartTime.ToString("HH:mm"), StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }

            //bind dictionary to dropdowm
            ddlResTime.DataSource = customersDict;
            ddlResTime.DataTextField = "Value";
            ddlResTime.DataValueField = "Key";
            ddlResTime.DataBind();
            ddlResTime.Items.Insert(0, new ListItem("--Select Time--", "0"));
        }


    }
}