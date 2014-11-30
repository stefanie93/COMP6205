using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
    }
   protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
   protected void btn_login_Click(object sender, EventArgs e)
   {
       SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
       connect.Open();
       string validateUser = "select count(*) from Users where email='" + txt_email.Text + "'";
       SqlCommand Emailcommand = new SqlCommand(validateUser,connect);
       int temp = Convert.ToInt32(Emailcommand.ExecuteScalar().ToString());
       connect.Close();
       if (temp == 1)
       {
           connect.Open();
           string validatePassword = "select password from Users where email='" + txt_email.Text + "'";
           SqlCommand PasswordCommantd = new SqlCommand(validatePassword, connect);
           string password = PasswordCommantd.ExecuteScalar().ToString();
           if (password == txt_Password.Text)
           {
               Session["New"] = txt_email.Text;
               Response.Write("password is correct!!");
           }
           else
           {
               Response.Write("password is not correct!!");
           }
       }
       else
       {
           Response.Write("username is not correct!!");
       }
       
   }
}