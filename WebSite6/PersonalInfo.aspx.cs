using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class PersonalInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_valueForm.Text = "d";
        string user_id;
        System.Collections.Specialized.NameValueCollection previuseFormCollection = Request.Form;
        user_id = previuseFormCollection["txt_userID"];
        if (previuseFormCollection["txt_login"] == "")
        {
            Server.Transfer("~/Form_Login.aspx", true);
        }

        dp_Day.Items.Insert(0, new ListItem("dd"));
        for(int i = 1; i<=31; i++)
        {
            string day;
            if (i < 10)
            {
                day = "0" + i.ToString();
            }
            else
            {
                day = i.ToString();
            }
            dp_Day.Items.Insert(i, new ListItem(day));
        }

        dp_month.Items.Insert(0, new ListItem("mm"));
        for (int i = 1; i <= 12; i++)
        {
            string month;
            if (i < 10)
            {
                month = "0" + i.ToString();
            }
            else
            {
                month = i.ToString();
            }
            dp_month.Items.Insert(i, new ListItem(month.ToString()));
        }

        dp_year.Items.Insert(0, new ListItem("yyyy"));
        for (int i = 1970; i <= 2014; i++)
        {
            dp_year.Items.Insert(i-1969, new ListItem(i.ToString()));
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_next_Click(object sender, EventArgs e)
    {
    //   lbl_Message.Text = "";
    //   //Connection with the Internal server
    //   SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
    //   connect.Open();
    //   //Create the query in order to check if the email exist
    //   string validateUser = "select count(*) from Users where email='" + txt_RegisterEmail.Text + "'";
    //   SqlCommand Emailcommand = new SqlCommand(validateUser,connect);
    //   int temp = Convert.ToInt32(Emailcommand.ExecuteScalar().ToString());
    //   connect.Close();
    //   //If it exist it check throw an exeption!
    //   if (temp == 1)
    //   {
    //       lbl_Message.Text = "Email already exist!!";
    //   }
    //   else
    //   {
    //       string labelString = "";
    //       Boolean register = true;

    //       if (txt_Name.Text == "")
    //       {
    //           labelString += "Enter your First Name @";
    //           register = false;
    //       }


    //       if (txt_Surname.Text == "")
    //       {
    //           labelString += "Enter your Last Name @";
    //           register = false;
    //       }

    //       //Boolean validEmail = IsValidEmail(txt_RegisterEmail.Text);
    //       //if (validEmail == false)
    //       //{
    //       //    labelString += "Enter a Valid Email @";
    //       //    register = false;
    //       //}

    //       //string emailValidator = txt_RegisterEmail.Text;
    //       //int sym = 0;
    //       //char[] emailarray = emailValidator.ToCharArray();
    //       //try
    //       //{
    //       //    if (char.IsLetter(emailarray[0]))
    //       //    {
    //       //        for (int i = 1; i < emailValidator.Length; i++)
    //       //        {
    //       //            if (emailValidator[i] == '@')
    //       //            {
    //       //                sym += 1;
    //       //            }
    //       //        }
    //       //        sym += 1;
    //       //    }
    //       //}
    //       //catch (Exception ex)
    //       //{ 
           
    //       //}

    //       if (txt_RegisterEmail.Text != txt_RegisterEmailConfirmation.Text)
    //       {
    //           txt_RegisterEmail.ForeColor = System.Drawing.Color.Red;
    //           txt_RegisterEmailConfirmation.ForeColor = System.Drawing.Color.Red;
    //           labelString += "The emails you entered are not maching @";
    //           register = false;
    //       }

    //       //if (sym != 2)
    //       //{
    //       //    labelString += "Enter a Valid Email @";
    //       //    register = false;
    //       //}

    //       if (txt_RegistrationPassword.Text != txt_RegisterPasswordConfirmation.Text)
    //       {
    //           labelString +=  "The passwords you entered are not maching @";
    //           register = false;
    //       }

    //       string temp1 = txt_RegistrationPassword.Text;
    //       int letter = 0;
    //       int number = 0;
    //       if ((temp1 == "") || (temp1.Length <= 6))
    //       {
    //           txt_RegistrationPassword.ForeColor = System.Drawing.Color.Red;
    //           txt_RegisterPasswordConfirmation.ForeColor = System.Drawing.Color.Red;
    //           labelString += "Your password needs to be at least 6 characters and at least one character and one number. @";
    //           register = false;
    //       }
    //       else
    //       {
    //           for (int i = 0; i < temp1.Length; i++)
    //           {
    //               if (char.IsLetter(temp1[i]))
    //               {
    //                   letter = 1;
    //               }
    //               if (char.IsDigit(temp1[i]))
    //               {
    //                   number = 1;
    //               }
    //           }
    //           if ((letter == 0) || (number == 0))
    //           {
    //               txt_RegistrationPassword.ForeColor = System.Drawing.Color.Red;
    //               txt_RegisterPasswordConfirmation.ForeColor = System.Drawing.Color.Red;
    //               labelString += "Your password needs to be at least 6 characters and at least one character and one number. @";
    //               register = false;
    //           }
    //       }
           
    //       if (register == true)
    //       {
    //            try
    //            {
    //                connect.Open();
    //                string newUser = "insert into Users (Email,FirstName,LastName,Password,Title) values(@email, @first, @last, @password, @title)";
    //                SqlCommand newUserCommand = new SqlCommand(newUser, connect);
    //                newUserCommand.Parameters.AddWithValue("@email", txt_RegisterEmail.Text);
    //                newUserCommand.Parameters.AddWithValue("@first", txt_Name.Text);
    //                newUserCommand.Parameters.AddWithValue("@last", txt_Surname.Text);
    //                newUserCommand.Parameters.AddWithValue("@password", txt_RegistrationPassword.Text);
    //                newUserCommand.Parameters.AddWithValue("@title", DropDownList1.SelectedItem.ToString());

    //                newUserCommand.ExecuteNonQuery();
    //                lbl_Message.Text = "Registration Complete";
    //                Response.Redirect("homepage.aspx");
    //                connect.Close();

    //            }
    //            catch (Exception ex)
    //            {
    //                lbl_Message.Text = "error:" + ex.ToString();
    //            }
    //       }
    //       else
    //       {
    //           labelString = labelString.Replace("@", "<br />");
    //           lbl_Message.Text = labelString;
    //           lbl_Message.ForeColor = System.Drawing.Color.Red;
    //       }

    //    }
    }

   public string endl { get; set; }
}