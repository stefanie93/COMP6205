using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Preferences : System.Web.UI.Page
{
    int userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["test"]))
        {
            userId = Convert.ToInt32(Request.QueryString["test"]);
        }
        lbl_Message.Text = userId.ToString();
    }
    protected void dp_agePref_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_Confirmation_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        //Connection with the Internal server
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        SqlConnection userconnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
        SqlConnection ageConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Age_Preferences_ConnectionString"].ConnectionString);
        SqlConnection genderConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Gender_Preferences_ConnectionString"].ConnectionString);
        SqlConnection courseConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Course_Preferences_ConnectionString"].ConnectionString);
        SqlConnection nationalityConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Nationality_Preferences_ConnectionString"].ConnectionString);

        string labelString = "";
        Boolean register = true;

        if ((rb_course_dontMind.Checked == false) || (rb_noCoursePref.Checked == false) || (rb_yesCoursePref.Checked == false))
        {
            labelString += "Select what course preference you like @";
            register = false;
        }

        if ((rb_nationality_dontMind.Checked == false) || (rb_noNationPref.Checked == false) || (rb_yesNationPref.Checked == false))
        {
            labelString += "Select what nationality preference you like @";
            register = false;
        }

        
        if (register == true)
        {
            try
            {
                connect.Open();
                //string age_id_pref = "select FirstName from Users where User_ID='" + id + "'";
                //SqlCommand userCommand = new SqlCommand(user, userconnect);
                //string userrrr = userCommand.ExecuteScalar().ToString();
                //userrrr = userrrr.Trim();
                //int 
                //string newPersonel = "insert into PersonalData (course, User_ID, YearOfStudy, Gender, Smoker, DateOfBirth, Nationality, PhoneNumber, AddressLine1, AddressLine2, AddressLine3, AddressLine4, City_Country, Postcode, age_preference_id, course_preference_id, gender_preference_id, nationality_preference_id) values(@course, @user_ID, @yearOfStudy, @gender, @smoker, @dateOfBirth, @nationality, @phoneNumber, @addressLine1, @addressLine2, @addressLine3, @addressLine4, @city_Country, @postcode, @age_preference_id, @course_preference_id, @gender_preference_id, @nationality_preference_id)";
                //SqlCommand newPersonelCommand = new SqlCommand(newPersonel, connect);

                //newPersonelCommand.Parameters.AddWithValue("@course", CourseTextBox.Text.Trim());
                //newPersonelCommand.Parameters.AddWithValue("@user_ID", 1);
                //newPersonelCommand.Parameters.AddWithValue("@yearOfStudy", dp_StudyYear.SelectedItem.ToString().Trim());
                //string gend = "male";
                //string smoke = "no";
                //if (rb_nationality_dontMind.Checked == true)
                //{
                //    gend = "male";
                //}
                //else
                //{
                //    gend = "Female";
                //}
                //if (smokerNo.Checked == true)
                //{
                //    smoke = "false";
                //}
                //else
                //{
                //    smoke = "true";
                //}
                //newPersonelCommand.Parameters.AddWithValue("@gender", gend);
                //newPersonelCommand.Parameters.AddWithValue("@smoker", smoke);


                //string day, month, year;
                //int dd, mm, yyyy;
                //day = dp_Day.SelectedItem.ToString();
                //dd = Convert.ToInt32(day);
                //month = dp_month.SelectedItem.ToString();
                //mm = Convert.ToInt32(month);
                //year = dp_year.SelectedItem.ToString();
                //yyyy = Convert.ToInt32(year);
                //dateOfBirth = mm + "/" + dd + "/" + yyyy;
                //Response.Write(dateOfBirth);
                //newPersonelCommand.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                //newPersonelCommand.Parameters.AddWithValue("@nationality", dp_nationalityList.SelectedItem.ToString().Trim());
                //newPersonelCommand.Parameters.AddWithValue("@phoneNumber", telephoneTBox.Text.Trim());
                //newPersonelCommand.Parameters.AddWithValue("@addressLine1", AddressTBox1.Text.Trim());
                //string address2 = "none";
                //string address3 = "none";
                //string address4 = "none";
                //if (AddressTBox2.Text != "")
                //{
                //    address2 = AddressTBox2.Text.Trim();
                //}
                //if (AddressTBox3.Text != "")
                //{
                //    address3 = AddressTBox3.Text.Trim();
                //}

                //if (AddressTBox4.Text != "")
                //{
                //    address4 = AddressTBox4.Text.Trim();
                //}
                //newPersonelCommand.Parameters.AddWithValue("@addressLine2", address2);
                //newPersonelCommand.Parameters.AddWithValue("@addressLine3", address3);
                //newPersonelCommand.Parameters.AddWithValue("@addressLine4", address4);
                //newPersonelCommand.Parameters.AddWithValue("@city_Country", CountryTBox.Text);
                //newPersonelCommand.Parameters.AddWithValue("@postcode", PostcodeTBox.Text);
                //newPersonelCommand.Parameters.AddWithValue("@age_preference_id", 1);
                //newPersonelCommand.Parameters.AddWithValue("@course_preference_id", 1);
                //newPersonelCommand.Parameters.AddWithValue("@gender_preference_id", 1);
                //newPersonelCommand.Parameters.AddWithValue("@nationality_preference_id", 1);

                //newPersonelCommand.ExecuteNonQuery();
                //lbl_Message.Text = "Registration Complete";
                //txt_PIvalueForm.Text = "5";
                //Response.Redirect("Preferences.aspx?test=" + txt_PIvalueForm.Text.Trim());

            }
            catch (Exception ex)
            {
                lbl_Message.Text = ex.ToString();
            }
        }
        else
        {
            labelString = labelString.Replace("@", "<br />");
            lbl_Message.Text = labelString;
            lbl_Message.ForeColor = System.Drawing.Color.Red;
        }
        connect.Close();
    }
}