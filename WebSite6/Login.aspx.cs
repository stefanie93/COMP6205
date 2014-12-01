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
       //Connection with the Internal server
       SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
       connect.Open();
       //Create the query in order to check if the email exist
       string validateUser = "select count(*) from Users where email='" + txt_email.Text + "'";
       SqlCommand Emailcommand = new SqlCommand(validateUser,connect);
       int temp = Convert.ToInt32(Emailcommand.ExecuteScalar().ToString());
       connect.Close();
       //If it exist it check if the password of that user is valid!
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
           Response.Write("Email is not correct!!");
       }
       
   }
   protected void cmd_Register_Click(object sender, EventArgs e)
   {
       //Connection with the Internal server
       SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
       connect.Open();
       //Create the query in order to check if the email exist
       string validateUser = "select count(*) from Users where email='" + txt_RegisterEmail.Text + "'";
       SqlCommand Emailcommand = new SqlCommand(validateUser,connect);
       int temp = Convert.ToInt32(Emailcommand.ExecuteScalar().ToString());
       connect.Close();
       //If it exist it check throw an exeption!
       if (temp == 1)
       {
           Response.Write("username already exist!!");
       }
       else
       {
           if (txt_RegisterEmail.Text != txt_RegisterEmailConfirmation.Text)
           {
               txt_RegisterEmailConfirmation.Style.Add("background-color", "red");
           }
           try
           {
               connect.Open();
               string newUser = "insert into Users (Email,FirstName,LastName,Password,Title) values(@email, @first, @last, @password, @title)";
               SqlCommand newUserCommand = new SqlCommand(newUser, connect);
               newUserCommand.Parameters.AddWithValue("@email", txt_RegisterEmail.Text);
               newUserCommand.Parameters.AddWithValue("@first", txt_Name.Text);
               newUserCommand.Parameters.AddWithValue("@last", txt_Surname.Text);
               newUserCommand.Parameters.AddWithValue("@password", txt_RegistrationPassword.Text);
               newUserCommand.Parameters.AddWithValue("@title", DropDownList1.SelectedItem.ToString());

               newUserCommand.ExecuteNonQuery();
               Response.Redirect("homepage.aspx");
               Response.Write("Registration Complete");
               connect.Close();
               
           }
           catch (Exception ex)
           {
               Response.Write("error:" + ex.ToString());
           }
       }
   }
}