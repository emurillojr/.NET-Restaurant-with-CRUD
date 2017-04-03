using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256demoWEEK1
{
    public partial class Menu_Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            else
            {

                int item_id = Convert.ToInt32(RouteData.Values["item_id"]);
                if (!IsPostBack)
                {
                    if (item_id > 0)   // if there is an item id
                    {
                        lbtnUpdate.Text = "Update";
                        MenuItemCS mt = new MenuItemCS(item_id);
                        txtName.Text = mt.Item_Name;
                        txtDescription.Text = mt.Item_Desc;
                        txtAllergens.Text = mt.Item_Allergens;
                        txtPrice.Text = mt.Item_Price.ToString();
                        ddlMenu.SelectedValue = mt.Menu_Id.ToString();
                        ddlCategory.SelectedValue = mt.Cat_Id.ToString();
                        chkGluten_Free.Checked = mt.Item_Gluten_Free;
                        chkIsActive.Checked = mt.Item_Active;
                    }
                    else  // if no item id go to add
                    {
                        lbtnUpdate.Text = "Add";
                        MenuItemCS mt = new MenuItemCS(item_id);
                        txtName.Text = String.Empty;
                        txtDescription.Text = String.Empty;
                        txtAllergens.Text = String.Empty;
                        txtPrice.Text = String.Empty;
                        ddlMenu.SelectedValue = null;
                        ddlCategory.SelectedValue = null;
                        chkGluten_Free.Checked = false;
                        chkIsActive.Checked = false;
                    }
                }
            }
        }

        protected void lbtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Menu-Items");
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            string updateBUTTON = lbtnUpdate.Text;
            
            if (updateBUTTON == "Update")    // update menu item
            {
                MenuItemCS sr = new MenuItemCS();
                if (RouteData.Values["item_id"] != null)
                {
                    bool success = false;
                    sr.Item_ID = Convert.ToInt32(RouteData.Values["item_id"]);
                    sr.Menu_Id = Convert.ToInt32(ddlMenu.SelectedValue);
                    sr.Cat_Id = Convert.ToInt32(ddlCategory.SelectedValue);
                    sr.Item_Name = txtName.Text.Trim();
                    sr.Item_Desc = txtDescription.Text.Trim();
                    sr.Item_Allergens = txtAllergens.Text.Trim();
                    sr.Item_Price = Convert.ToDecimal(txtPrice.Text);
                    sr.Item_Gluten_Free = false;
                    sr.Item_Active = chkIsActive.Checked;

                    success = MenuItemCS.UpdateMenuItems(sr);

                    if (success)  // if update menu is true
                    {
                        Response.Redirect("~/Admin/Menu-Items");
                    }
                }
            }

            else   // insert menu item
            {
                bool success = false;
                MenuItemCS sr = new MenuItemCS();
                sr.Item_ID = Convert.ToInt32(RouteData.Values["item_id"]);
                sr.Menu_Id = Convert.ToInt32(ddlMenu.SelectedValue);
                sr.Cat_Id = Convert.ToInt32(ddlCategory.SelectedValue);
                sr.Item_Name = txtName.Text.Trim();
                sr.Item_Desc = txtDescription.Text.Trim();
                sr.Item_Allergens = txtAllergens.Text.Trim();
                sr.Item_Price = Convert.ToDecimal(txtPrice.Text);
                sr.Item_Gluten_Free = false;
                sr.Item_Active = chkIsActive.Checked;

                success = MenuItemCS.InsertMenuItem(sr);

                if (success)  // if insert menu is true
                {
                    Response.Redirect("/Admin/Menu-Items");
                }
            }
        }
    }
}