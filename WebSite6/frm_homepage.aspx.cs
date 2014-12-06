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
        if (logedin == true)
        {
            Button1.Text = "Log Out";
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Login")
        {
            Response.Redirect("Form_Login.aspx?home=" + txt_Home_valueForm.Text);
        }
        else
        {
            Response.Redirect("frm_homepage.aspx");   
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int studio = 0;
        sendToNextForm(studio);
    }

    public void sendToNextForm(int studio)
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

            string sendVal = txt_Home_userID.Text + " " + studio.ToString();

            if (aplication_state == "0")
            {
                Response.Redirect("PersonalInfo.aspx?value_home=" + sendVal);
            }
            else if ((aplication_state == "1"))
            {
                if (studio == 0)
                {
                    Response.Redirect("Preferences.aspx?testID=" + txt_Home_userID.Text);
                }
                else
                {
                    Response.Redirect("Status.aspx?User_ID_Home=" + txt_Home_userID.Text);
                }
            }
            else if (aplication_state == "2")
            {
                Response.Redirect("Status.aspx?User_ID_Home=" + txt_Home_userID.Text);
            }
        }
        else
        {
            Response.Redirect("Form_Login.aspx?home=" + txt_Home_valueForm.Text.Trim() + "&studio=" + studio);
        }
    }
    
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
      
    }
    protected void txt_Home_valueForm_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt_home_login_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int studio = 1;
        sendToNextForm(studio);
    }
}