using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_homepage : System.Web.UI.Page
{
    bool logedin = false;
    int userid;
    protected void Page_Load(object sender, EventArgs e)
    {

        txt_Home_valueForm.Text = "home";

        if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
        {
            logedin = true;
            userid = Convert.ToInt32(Request.QueryString["userID"]);
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("Form_Login.aspx?home=" + txt_Home_valueForm.Text);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        txt_Home_userID.Text = userid.ToString();
        txt_Home_valueForm.Text = "Personal";
        if (logedin == true)
        {
            Response.Redirect("PersonalInfo.aspx?userID=" + txt_Home_userID.Text);
        }
        else
        {
            Response.Redirect("Form_Login.aspx?home=" + txt_Home_valueForm.Text.Trim());
        }
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
      
    }
}