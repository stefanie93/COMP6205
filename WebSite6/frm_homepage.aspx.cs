using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
        connect.Open();
        txt_Home_userID.Text = userid.ToString();
        txt_Home_valueForm.Text = "Personal";
        if (logedin == true)
        {
            string user = "select state from Users where User_ID='" + userid + "'";
            SqlCommand userCommand = new SqlCommand(user, connect);
            string aplication_state = userCommand.ExecuteScalar().ToString();
            aplication_state = aplication_state.Trim();
            if (aplication_state == "0")
            {
                Response.Redirect("PersonalInfo.aspx?userID=" + txt_Home_userID.Text);
            }
            else if (aplication_state == "1")
            {
                Response.Redirect("Preferences.aspx?testID=" + txt_Home_userID.Text);
            }
            else if (aplication_state == "2")
            {
                Response.Redirect("adminView.aspx");
            }
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