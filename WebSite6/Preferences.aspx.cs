using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Preferences : System.Web.UI.Page
{
    int userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["testID"]))
        {
            userId = Convert.ToInt32(Request.QueryString["testID"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["testID_login"]))
        {
            userId = Convert.ToInt32(Request.QueryString["testID_login"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["value_PI"]))
        {
            userId = Convert.ToInt32(Request.QueryString["value_PI"]);
        }
    }
    protected void dp_agePref_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_Confirmation_Click(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        SqlConnection userconnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration_ConnectionString"].ConnectionString);
        SqlConnection ageConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Age_Preferences_ConnectionString"].ConnectionString);
        SqlConnection genderConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Gender_Preferences_ConnectionString"].ConnectionString);
        SqlConnection courseConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Course_Preferences_ConnectionString"].ConnectionString);
        SqlConnection nationalityConnnect = new SqlConnection(ConfigurationManager.ConnectionStrings["Nationality_Preferences_ConnectionString"].ConnectionString);
        if (txt_GroupID.Text == "")
        {
            lbl_Message.Text = "";
            //Connection with the Internal server
            
            string labelString = "";
            Boolean register = true;

            if ((rb_course_dontMind.Checked == false) && (rb_yesCoursePref.Checked == false))
            {
                labelString += "Select what course preference you like @";
                register = false;
            }

            if ((rb_nationality_dontMind.Checked == false) && (rb_yesNationPref.Checked == false))
            {
                labelString += "Select what nationality preference you like @";
                register = false;
            }


            if (register == true)
            {
                try
                {
                    connect.Open();

                    //Select query
                    string customer_id = "select customer_ID from PersonalData where User_ID='" + userId + "'";

                    SqlCommand customerCommand = new SqlCommand(customer_id, connect);
                    string customer = customerCommand.ExecuteScalar().ToString();
                    customer = customer.Trim();
                    int customerID = Convert.ToInt32(customer);

                    int coursePreference = 1;
                    int agePreference = Convert.ToInt32(dp_agePref.SelectedValue);
                    int genderPreference = Convert.ToInt32(dp_genderPref.SelectedValue);
                    int nationalityPreference = 1;

                    if (rb_course_dontMind.Checked == true)
                    {
                        coursePreference = 5;
                    }
                    else if (rb_yesCoursePref.Checked == true)
                    {
                        coursePreference = 1;
                    }

                    if (rb_nationality_dontMind.Checked == true)
                    {
                        nationalityPreference = 3;
                    }
                    else if (rb_yesNationPref.Checked == true)
                    {
                        nationalityPreference = 1;
                    }

                    string update_age_Query = "update PersonalData set age_preference_id=" + agePreference + "where customer_ID=" + customerID;
                    SqlCommand update_age_Query_Command = new SqlCommand(update_age_Query, connect);
                    update_age_Query_Command.ExecuteNonQuery();

                    string update_course_Query = "update PersonalData set course_preference_id=" + coursePreference + "where customer_ID=" + customerID;
                    SqlCommand update_course_Query_Command = new SqlCommand(update_course_Query, connect);
                    update_course_Query_Command.ExecuteNonQuery();

                    string update_gender_Query = "update PersonalData set gender_preference_id=" + genderPreference + "where customer_ID=" + customerID;
                    SqlCommand update_gender_Query_Command = new SqlCommand(update_gender_Query, connect);
                    update_gender_Query_Command.ExecuteNonQuery();

                    string update_nationality_Query = "update PersonalData set nationality_preference_id=" + nationalityPreference + "where customer_ID=" + customerID;
                    SqlCommand update_nationality_Query_Command = new SqlCommand(update_nationality_Query, connect);
                    update_nationality_Query_Command.ExecuteNonQuery();

                    string update_status_Query = "update Users set state=" + "2" + "where User_ID=" + userId;
                    SqlCommand update_status_Query_Command = new SqlCommand(update_status_Query, connect);
                    update_status_Query_Command.ExecuteNonQuery();

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
            Response.Redirect("Status.aspx?User_ID_Pref=" + userId);
        }
        else
        {
            
            int[] groupids = new int[10000];
            int groupidsCount = 0;

            DataView DataViewForgroups = (DataView)SqlDataSource6.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView DataRowViewForGroups in DataViewForgroups)
            {
                groupids[groupidsCount] = Convert.ToInt32(DataRowViewForGroups["groupID"].ToString());
                groupidsCount++;
            }

            int dd = 0;
            for (int i = 0; i < groupidsCount; i++)
            {
                if (groupids[i] == Convert.ToInt32(txt_GroupID.Text))
                {
                    dd++;
                }
            }
            if (dd <= 6)
            {
                string update_groupID_Query = "update PersonalData set groupID=" + txt_GroupID.Text + "where User_ID=" + userId;
                SqlCommand update_groupID_Query_Command = new SqlCommand(update_groupID_Query, connect);
                update_groupID_Query_Command.ExecuteNonQuery();
            }
            else
            {
                string display = "No more than 6 People can be in the same flat";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
            connect.Close();
        }

    }
    
    static int RandomNumber()
    {
        Random random = new Random();
        return random.Next(2000000, 9999999);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        int[] groupids = new int[10000];
        int groupidsCount = 0;
        connect.Open();

        DataView DataViewForgroups= (DataView)SqlDataSource6.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForGroups in DataViewForgroups)
        {
            if (DataRowViewForGroups["groupID"].ToString() != "")
            {
                groupids[groupidsCount] = Convert.ToInt32(DataRowViewForGroups["groupID"].ToString().Trim());
                groupidsCount++;
            }
        }

        int generated_group_id = RandomNumber();
        int m = generated_group_id;
        
        for (int i = 0; i < groupidsCount; i++)
        {
            while (generated_group_id == groupids[i])
            {
                 if (groupids[i] == generated_group_id)
                 {
                     m = RandomNumber();
                 }
            }
        }
        generated_group_id = m;
        txt_GroupID.Text = generated_group_id.ToString();

        string update_groupID_Query = "update PersonalData set groupID=" + generated_group_id + "where User_ID=" + userId;
        SqlCommand update_groupID_Query_Command = new SqlCommand(update_groupID_Query, connect);
        update_groupID_Query_Command.ExecuteNonQuery();

        connect.Close();
    }

    protected void Btn_Yes_Click(object sender, EventArgs e)
    {
        Label5.Enabled = true;
        txt_GroupID.Enabled = true;
        Label8.Enabled = true;
        Button1.Enabled = true;
        Label1.Enabled = false;
        Label2.Enabled = false;
        Label3.Enabled = false;
        Label4.Enabled = false;
        dp_agePref.Enabled = false;
        dp_genderPref.Enabled = false;
        rb_course_dontMind.Enabled = false;
        rb_nationality_dontMind.Enabled = false;
        rb_yesCoursePref.Enabled = false;
        rb_yesNationPref.Enabled = false;
    }
    protected void Btn_No_Click(object sender, EventArgs e)
    {

        Label1.Enabled = true;
        Label2.Enabled = true;
        Label3.Enabled = true;
        Label4.Enabled = true;
        dp_agePref.Enabled = true;
        dp_genderPref.Enabled = true;
        rb_course_dontMind.Enabled = true;
        rb_nationality_dontMind.Enabled = true;
        rb_yesCoursePref.Enabled = true;
        rb_yesNationPref.Enabled = true;
        Label5.Enabled = false;
        txt_GroupID.Enabled = false;
        Label8.Enabled = false;
        Button1.Enabled = false;

        
    }
}