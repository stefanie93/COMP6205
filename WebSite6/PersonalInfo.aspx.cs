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
    int studio = 3; 
    int user_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_PIvalueForm.Text = "d";
        
        if (!string.IsNullOrEmpty(Request.QueryString["value_home"]))
        {
            string value = Request.QueryString["value_home"];
            string[] words = value.Split(' ');
            studio = Convert.ToInt32(words[1]);
            user_id = Convert.ToInt32(words[0]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["value_login"]))
        {
            string value = Request.QueryString["value_login"];
            string[] words = value.Split(' ');
            studio = Convert.ToInt32(words[1]);
            user_id = Convert.ToInt32(words[0]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["value_Register"]))
        {
            string value = Request.QueryString["value_Register"];
            string[] words = value.Split(' ');
            studio = Convert.ToInt32(words[1]);
            user_id = Convert.ToInt32(words[0]);
        }

        if (dp_Day.Items.Count == 0)
        {
            dp_Day.Items.Insert(0, new ListItem("dd"));
            for (int i = 1; i <= 31; i++)
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
        }
        if (dp_month.Items.Count == 0)
        {
            dp_month.Items.Insert(0, new ListItem("mm"));
            for (int j = 1; j <= 12; j++)
            {
                string month;
                if (j < 10)
                {
                    month = "0" + j.ToString();
                }
                else
                {
                    month = j.ToString();
                }
                dp_month.Items.Insert(j, new ListItem(month.ToString()));
            }
        }

        if (dp_year.Items.Count == 0)
        {
            dp_year.Items.Insert(0, new ListItem("yyyy"));
            for (int k = 1970; k <= 2014; k++)
            {
                dp_year.Items.Insert(k - 1969, new ListItem(k.ToString()));
            }
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

        lbl_Message.Text = "";
        //Connection with the Internal server
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        SqlConnection userconnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);

        string labelString = "";
        Boolean register = true;

        if (dp_StudyYear.SelectedIndex == 0)
        {
            labelString += "Select your Year of Study @";
            register = false;
        }

        if (CourseTextBox.Text == "")
        {
            labelString += "Enter your course @";
            register = false;
        }

        if ((dp_Day.SelectedItem.ToString() == "dd") || (dp_month.SelectedItem.ToString() == "mm") || (dp_year.SelectedItem.ToString() == "yyyy"))
        {
            labelString += "Select a valid Date of Birth @";
            register = false;
        }

        if (dp_nationalityList.SelectedIndex == 0)
        {
            labelString += "Select your Nationality @";
            register = false;
        }

        if (telephoneTBox.Text == "")
        {
            labelString += "Enter a valid UK telephone number @";
            register = false;
        }

        if (AddressTBox1.Text == "")
        {
            labelString += "The first line of Address is Required @";
            register = false;
        }

        if (CountryTBox.Text == "")
        {
            labelString += "Enter your City/Country @";
            register = false;
        }

        //if ((PostcodeTBox.Text.Length == 6) || (PostcodeTBox.Text.Length == 7))
        //{
        //    char[] postcodechar = PostcodeTBox.Text.ToCharArray();
        //    if ((char.IsLetter(postcodechar[0])) && (char.IsLetter(postcodechar[1])) && (char.IsDigit(postcodechar[2])) && (char.IsDigit(postcodechar[3])) && (char.IsLetter(postcodechar[4])) && (char.IsLetter(postcodechar[5])))
        //    {
        //    }
        //    else if ((char.IsLetter(postcodechar[0])) && (char.IsLetter(postcodechar[1])) && (char.IsDigit(postcodechar[2])) && (char.IsDigit(postcodechar[4])) && (char.IsLetter(postcodechar[5])) && (char.IsLetter(postcodechar[6])))
        //    {
        //    }
        //    else
        //    {
        //        labelString += "Enter a valid UK Postcode @";
        //        register = false;
        //    }
        //}

        string dateOfBirth = "";
        if (register == true)
        {
            try
            {
            connect.Open();
            string newPersonel = "insert into PersonalData (course, User_ID, YearOfStudy, Gender, Smoker, DateOfBirth, Nationality, PhoneNumber, AddressLine1, AddressLine2, AddressLine3, AddressLine4, City_Country, Postcode, age_preference_id, course_preference_id, gender_preference_id, nationality_preference_id, isStudioSelected) values(@course, @user_ID, @yearOfStudy, @gender, @smoker, @dateOfBirth, @nationality, @phoneNumber, @addressLine1, @addressLine2, @addressLine3, @addressLine4, @city_Country, @postcode, @age_preference_id, @course_preference_id, @gender_preference_id, @nationality_preference_id, @isStudioSelected)";
            SqlCommand newPersonelCommand = new SqlCommand(newPersonel, connect);

            newPersonelCommand.Parameters.AddWithValue("@course", CourseTextBox.Text.Trim());
            newPersonelCommand.Parameters.AddWithValue("@user_ID", user_id);
            newPersonelCommand.Parameters.AddWithValue("@yearOfStudy", dp_StudyYear.SelectedItem.ToString().Trim());
            string gend = "male";
            string smoke = "no";
            if (MaleRButton.Checked == true)
            {
                gend = "male";
            }
            else
            {
                gend = "Female";
            }
            if (smokerNo.Checked == true)
            {
                smoke = "false";
            }
            else
            {
                smoke = "true";
            }
            newPersonelCommand.Parameters.AddWithValue("@gender", gend);
            newPersonelCommand.Parameters.AddWithValue("@smoker", smoke);


            string day, month, year;
            int dd, mm, yyyy;
            day = dp_Day.SelectedItem.ToString();
            dd = Convert.ToInt32(day);
            month = dp_month.SelectedItem.ToString();
            mm = Convert.ToInt32(month);
            year = dp_year.SelectedItem.ToString();
            yyyy = Convert.ToInt32(year);
            dateOfBirth = mm + "/" + dd + "/" + yyyy;
            Response.Write(dateOfBirth);
            newPersonelCommand.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            newPersonelCommand.Parameters.AddWithValue("@nationality", dp_nationalityList.SelectedItem.ToString().Trim());
            newPersonelCommand.Parameters.AddWithValue("@phoneNumber", telephoneTBox.Text.Trim());
            newPersonelCommand.Parameters.AddWithValue("@addressLine1", AddressTBox1.Text.Trim());
            string address2 = "none";
            string address3 = "none";
            string address4 = "none";
            if (AddressTBox2.Text != "")
            {
                address2 = AddressTBox2.Text.Trim();
            }
            if (AddressTBox3.Text != "")
            {
                address3 = AddressTBox3.Text.Trim();
            }

            if (AddressTBox4.Text != "")
            {
                address4 = AddressTBox4.Text.Trim();
            }
            newPersonelCommand.Parameters.AddWithValue("@addressLine2", address2);
            newPersonelCommand.Parameters.AddWithValue("@addressLine3", address3);
            newPersonelCommand.Parameters.AddWithValue("@addressLine4", address4);
            newPersonelCommand.Parameters.AddWithValue("@city_Country", CountryTBox.Text);
            newPersonelCommand.Parameters.AddWithValue("@postcode", PostcodeTBox.Text);
            newPersonelCommand.Parameters.AddWithValue("@age_preference_id", 1);
            newPersonelCommand.Parameters.AddWithValue("@course_preference_id", 1);
            newPersonelCommand.Parameters.AddWithValue("@gender_preference_id", 1);
            newPersonelCommand.Parameters.AddWithValue("@nationality_preference_id", 1);
            newPersonelCommand.Parameters.AddWithValue("@isStudioSelected", studio);
                
            

            newPersonelCommand.ExecuteNonQuery();

            string updateQuery = "update Users set state=" + 1 + "where User_ID=" + user_id;
            SqlCommand updateQueryCommand = new SqlCommand(updateQuery, connect);
            updateQueryCommand.ExecuteNonQuery();

            lbl_Message.Text = "Registration Complete";
            txt_PIvalueForm.Text = user_id.ToString();
            if (studio == 0)
            {
                string sendVal = txt_PIvalueForm.Text;
                Response.Redirect("Preferences.aspx?value_PI=" + sendVal);
            }
            else
            {
                Response.Redirect("Status.aspx?User_ID_PI=" + txt_PIvalueForm.Text);
            }

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

   public string endl { get; set; }
   
   protected void smokerNo_CheckedChanged(object sender, EventArgs e)
   {
       if (smokerNo.Checked == true)
       {
           smokerYes.Checked = false;
       }
   }
   protected void smokerYes_CheckedChanged(object sender, EventArgs e)
   {
       if (smokerYes.Checked == true)
       {
           smokerNo.Checked = false;
       }
   }

   protected void Button1_Click(object sender, EventArgs e)
   {
       Response.Redirect("frm_homepage.aspx?personalInfo=" + user_id);
   }
   protected void MaleRButton_CheckedChanged(object sender, EventArgs e)
   {

   }
   protected void FemaleRButton_CheckedChanged(object sender, EventArgs e)
   {

   }
   protected void CountryCodeTBox_TextChanged(object sender, EventArgs e)
   {

   }
}