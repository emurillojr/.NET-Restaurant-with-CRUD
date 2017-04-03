using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256demoWEEK1
{
    public class Menus
    {
        //returns a list of menu items
        public static List<MenuItem> GetMainMenu()
        {
            #region
            List<MenuItem> lstMenu = new List<MenuItem>();
                         //what navbar shows,  " ",  " ", friendly url
            lstMenu.Add(new MenuItem("Home", "", "", "~/Home"));
            lstMenu.Add(new MenuItem("Lunch Menu", "", "", "~/Lunch-Menu"));
            lstMenu.Add(new MenuItem("Dinner Menu", "", "", "~/Dinner-Menu"));
            lstMenu.Add(new MenuItem("Reservations", "", "", "~/Reservation"));
            lstMenu.Add(new MenuItem("Directions", "", "", "~/Directions"));
            lstMenu.Add(new MenuItem("About", "", "", "~/About"));
            lstMenu.Add(new MenuItem("Contact", "", "", "~/Contact"));

           // lstMenu.Add(new MenuItem("Sign In", "", "", "~/Sign-In"));    // removed to resolve errors lab 5 #5
            return lstMenu;
            #endregion
        }

        public static List<MenuItem> GetAdminMenu()
        {
            #region
            List<MenuItem> adminMenu = new List<MenuItem>();
                                 //what navbar shows,  " ",  " ", friendly url
       //     adminMenu.Add(new MenuItem("Admin Home", "", "", "~/Admin/Home"));
            adminMenu.Add(new MenuItem("Menu Items", "", "", "~/Admin/Menu-Items"));
            adminMenu.Add(new MenuItem("Menu Item", "", "", "~/Admin/Menu-Item"));  
            adminMenu.Add(new MenuItem("Sections", "", "", "~/Admin/Sections"));
            adminMenu.Add(new MenuItem("Section", "", "", "~/Admin/Section"));
            adminMenu.Add(new MenuItem("Tables", "", "", "~/Admin/Tables"));
            adminMenu.Add(new MenuItem("Table", "", "", "~/Admin/Table"));
            adminMenu.Add(new MenuItem("Res Mgmt", "", "", "~/Admin/Res-Management"));
           // adminMenu.Add(new MenuItem("Reservation", "", "", "~/Admin/Reservation"));
            adminMenu.Add(new MenuItem("Users", "", "", "~/Admin/Users"));
            adminMenu.Add(new MenuItem("User", "", "", "~/Admin/User"));
            return adminMenu;
            #endregion
        }


    }
}