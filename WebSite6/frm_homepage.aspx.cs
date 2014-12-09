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
        if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
        {
            logedin = true;
            userid = Convert.ToInt32(Request.QueryString["userID"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["adminView"]))
        {
            userid = Convert.ToInt32(Request.QueryString["adminView"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["personalInfo"]))
        {
            logedin = true;
            userid = Convert.ToInt32(Request.QueryString["personalInfo"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["preferences"]))
        {
            logedin = true;
            userid = Convert.ToInt32(Request.QueryString["preferences"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["status"]))
        {
            logedin = true;
            userid = Convert.ToInt32(Request.QueryString["status"]);
        }


        if (logedin == true)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
            connect.Open();
            string FirstNameQuery = "select FirstName from Users where User_ID='" + userid + "'";
            SqlCommand FirstNameCommand = new SqlCommand(FirstNameQuery, connect);
            string FirstName = FirstNameCommand.ExecuteScalar().ToString();
            FirstName = FirstName.Trim();

            string stateQuery = "select FirstName from Users where User_ID='" + userid + "'";
            SqlCommand stateQueryCommand = new SqlCommand(stateQuery, connect);
            string stateID = stateQueryCommand.ExecuteScalar().ToString();
            stateID = stateID.Trim();
            if (stateID != "0")
            {
                Button2.Text = "Continue Booking";
                Button3.Text = "Continue Booking";
            }
            connect.Close();
            txt_Home_valueForm.Text = "home";
            Btn_Login_Reg.Text = "Log Out";
            Btn_Login_Reg.Height = 20;
            Btn_Login_Reg.Width = 100;
            Label1.Text = "Welcome, " + FirstName;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Btn_Login_Reg.Text == "Login/Register")
        {
            txt_Home_valueForm.Text = "home";
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
        txt_Home_valueForm.Text = "home";
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
            else if (aplication_state == "1")
            {
                string studioQuery = "select state from Users where User_ID='" + userid + "'";
                SqlCommand studioQueryCommand = new SqlCommand(studioQuery, connect);
                string studio_string = studioQueryCommand.ExecuteScalar().ToString();
                studio_string = studio_string.Trim();
                if (studio_string == "0")
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
            string t = "home" + " " + studio;
            Response.Redirect("Form_Login.aspx?homePI=" + t);
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