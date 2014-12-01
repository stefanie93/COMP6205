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

    public bool IsValidEmail(string email)
    {
        try
        {
            var check = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }

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
       lbl_Message.Text = "";
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
               lbl_Message.Text = "password is correct!!";
           }
           else
           {
               lbl_Message.Text = "password is not correct!!";
           }
       }
       else
       {
           lbl_Message.Text = "Email is not correct!!";
       }
       
   }
   protected void cmd_Register_Click(object sender, EventArgs e)
   {
       lbl_Message.Text = "";
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
           lbl_Message.Text = "Email already exist!!";
       }
       else
       {
           string labelString = "";
           Boolean register = true;

           if (txt_Name.Text == "")
           {
               labelString += "Enter your First Name @";
               register = false;
           }


           if (txt_Surname.Text == "")
           {
               labelString += "Enter your Last Name @";
               register = false;
           }

           //Boolean validEmail = IsValidEmail(txt_RegisterEmail.Text);
           //if (validEmail == false)
           //{
           //    labelString += "Enter a Valid Email @";
           //    register = false;
           //}

           //string emailValidator = txt_RegisterEmail.Text;
           //int sym = 0;
           //char[] emailarray = emailValidator.ToCharArray();
           //try
           //{
           //    if (char.IsLetter(emailarray[0]))
           //    {
           //        for (int i = 1; i < emailValidator.Length; i++)
           //        {
           //            if (emailValidator[i] == '@')
           //            {
           //                sym += 1;
           //            }
           //        }
           //        sym += 1;
           //    }
           //}
           //catch (Exception ex)
           //{ 
           
           //}

           if (txt_RegisterEmail.Text != txt_RegisterEmailConfirmation.Text)
           {
               txt_RegisterEmail.ForeColor = System.Drawing.Color.Red;
               txt_RegisterEmailConfirmation.ForeColor = System.Drawing.Color.Red;
               labelString += "The emails you entered are not maching @";
               register = false;
           }

           //if (sym != 2)
           //{
           //    labelString += "Enter a Valid Email @";
           //    register = false;
           //}

           if (txt_RegistrationPassword.Text != txt_RegisterPasswordConfirmation.Text)
           {
               labelString +=  "The passwords you entered are not maching @";
               register = false;
           }

           string temp1 = txt_RegistrationPassword.Text;
           int letter = 0;
           int number = 0;
           if ((temp1 == "") || (temp1.Length <= 6))
           {
               txt_RegistrationPassword.ForeColor = System.Drawing.Color.Red;
               txt_RegisterPasswordConfirmation.ForeColor = System.Drawing.Color.Red;
               labelString += "Your password needs to be at least 6 characters and at least one character and one number. @";
               register = false;
           }
           else
           {
               for (int i = 0; i < temp1.Length; i++)
               {
                   if (char.IsLetter(temp1[i]))
                   {
                       letter = 1;
                   }
                   if (char.IsDigit(temp1[i]))
                   {
                       number = 1;
                   }
               }
               if ((letter == 0) || (number == 0))
               {
                   txt_RegistrationPassword.ForeColor = System.Drawing.Color.Red;
                   txt_RegisterPasswordConfirmation.ForeColor = System.Drawing.Color.Red;
                   labelString += "Your password needs to be at least 6 characters and at least one character and one number. @";
                   register = false;
               }
           }
           
           if (register == true)
           {
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
                    lbl_Message.Text = "Registration Complete";
                    Response.Redirect("homepage.aspx");
                    connect.Close();

                }
                catch (Exception ex)
                {
                    lbl_Message.Text = "error:" + ex.ToString();
                }
           }
           else
           {
               labelString = labelString.Replace("@", "<br />");
               lbl_Message.Text = labelString;
               lbl_Message.ForeColor = System.Drawing.Color.Red;
           }

        }
    }

   public string endl { get; set; }
   protected void txt_RegisterEmail_TextChanged(object sender, EventArgs e)
   {
       txt_RegisterEmail.ForeColor = System.Drawing.Color.Black;
       txt_RegisterEmail.Text = "";
       txt_RegisterEmailConfirmation.Text = "";
       txt_RegisterEmailConfirmation.ForeColor = System.Drawing.Color.Black;
   }
}
