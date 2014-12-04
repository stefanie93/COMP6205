using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class adminView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_generate_Click(object sender, EventArgs e)
    {
        lbl_Message.Text = "";
        //Connection with the Internal server
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        connect.Open();
        string lastQuery = "select max(User_ID) from Users";
        SqlCommand lastCommand = new SqlCommand(lastQuery, connect);
        string last = lastCommand.ExecuteScalar().ToString();
        last = last.Trim();
        int lastUserID = Convert.ToInt32(last);
        
        string label = "";

        string[,] course_UserID = new string[lastUserID,2];
        int course_UserID_count = 0;
        string[,] gender_UserID = new string[lastUserID, 2];
        int gender_UserID_count = 0;
        string[,] nationality_UserID = new string[lastUserID, 2];
        int nationality_UserID_count = 0;
        string[,] DoF_UserId = new string[lastUserID, 3];
        int DoF_UserId_count = 0;
        string[,] preferences = new string[lastUserID, 5];
        int preferencesCount = 0;

        DataView DataViewForCourses = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForCourses in DataViewForCourses)
        {
            course_UserID[course_UserID_count, 0] = DataRowViewForCourses["User_ID"].ToString();
            course_UserID[course_UserID_count, 1] = DataRowViewForCourses["course"].ToString();
            label += course_UserID[course_UserID_count, 0] + "    " + course_UserID[course_UserID_count, 1] + "@";
            course_UserID_count++;
        }

        DataView DataViewForGender = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForGender in DataViewForGender)
        {
            gender_UserID[gender_UserID_count, 0] = DataRowViewForGender["User_ID"].ToString();
            gender_UserID[gender_UserID_count, 1] = DataRowViewForGender["Gender"].ToString();
            label += gender_UserID[gender_UserID_count, 0] + "    " + gender_UserID[gender_UserID_count, 1] + "@";
            gender_UserID_count++;
        }

        DataView DataViewForNationalities = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForNationalities in DataViewForNationalities)
        {
            nationality_UserID[nationality_UserID_count, 0] = DataRowViewForNationalities["User_ID"].ToString();
            nationality_UserID[nationality_UserID_count, 1] = DataRowViewForNationalities["nationality"].ToString();
            label += nationality_UserID[nationality_UserID_count, 0] + "    " + nationality_UserID[nationality_UserID_count, 1] + "@";
            nationality_UserID_count++;
        }

        DataView DataViewForPreferences = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForPreferences in DataViewForPreferences)
        {
            preferences[preferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
            preferences[preferencesCount, 1] = DataRowViewForPreferences["age_preference_id"].ToString();
            preferences[preferencesCount, 2] = DataRowViewForPreferences["course_preference_id"].ToString();
            preferences[preferencesCount, 3] = DataRowViewForPreferences["gender_preference_id"].ToString();
            preferences[preferencesCount, 4] = DataRowViewForPreferences["nationality_preference_id"].ToString();
            label += preferences[preferencesCount, 0] + "    " + preferences[preferencesCount, 1] + "   " + preferences[preferencesCount, 2] + "   " + preferences[preferencesCount, 3] + "    " + preferences[preferencesCount, 4] + "@";
            nationality_UserID_count++;
        }

        string date = "";
        int dateYear = 0;
        
        DataView DataViewDateOfBirth = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewDateOfBirth in DataViewDateOfBirth)
        {
            date = DataRowViewDateOfBirth["DateOfBirth"].ToString();
            char[] dateChar = date.ToCharArray();
            date = dateChar[7] + "" + dateChar[8];
            if (Convert.ToInt32(date) >= 70 && Convert.ToInt32(date) <= 99)
            {
                date = 19 + "" + date;
            }
            else
            {
                date = 20 + "" + date;
            }
            dateYear = Convert.ToInt32(date);

            
            DoF_UserId[DoF_UserId_count, 0] = DataRowViewDateOfBirth["User_ID"].ToString();
            DoF_UserId[DoF_UserId_count, 1] = ((DateTime.Now.Year - dateYear).ToString());

            label += DoF_UserId[DoF_UserId_count, 0] + "    " + DoF_UserId[DoF_UserId_count, 1] + "@";
            DoF_UserId_count++;
        }

        label = label.Replace("@", "<br />");
        lbl_Message.Text = label.ToString(); ;
    }
    public class user
    {
        public int User_ID { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}