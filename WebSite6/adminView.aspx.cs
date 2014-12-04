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
    string[,] users = new string[1000, 2];
    int userCount = 0;
    int group = 0;

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

        //tables for preferences
        string[,] allSelected = new string[lastUserID,2];
        string[,] AllDontMind = new string[lastUserID, 2];
        string[,] age_course = new string[lastUserID, 2];
        string[,] age_gender = new string[lastUserID, 2];
        string[,] age_nationality = new string[lastUserID, 2];
        string[,] course_gender = new string[lastUserID, 2];
        string[,] course_Nationality = new string[lastUserID, 2];
        string[,] gender_Nationality = new string[lastUserID, 2];

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
            //label += course_UserID[course_UserID_count, 0] + "    " + course_UserID[course_UserID_count, 1] + "@";
            course_UserID_count++;
        }

        DataView DataViewForGender = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForGender in DataViewForGender)
        {
            gender_UserID[gender_UserID_count, 0] = DataRowViewForGender["User_ID"].ToString();
            gender_UserID[gender_UserID_count, 1] = DataRowViewForGender["Gender"].ToString();
            //label += gender_UserID[gender_UserID_count, 0] + "    " + gender_UserID[gender_UserID_count, 1] + "@";
            gender_UserID_count++;
        }

        DataView DataViewForNationalities = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForNationalities in DataViewForNationalities)
        {
            nationality_UserID[nationality_UserID_count, 0] = DataRowViewForNationalities["User_ID"].ToString();
            nationality_UserID[nationality_UserID_count, 1] = DataRowViewForNationalities["nationality"].ToString();
            //label += nationality_UserID[nationality_UserID_count, 0] + "    " + nationality_UserID[nationality_UserID_count, 1] + "@";
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
            //label += preferences[preferencesCount, 0] + "    " + preferences[preferencesCount, 1] + "   " + preferences[preferencesCount, 2] + "   " + preferences[preferencesCount, 3] + "    " + preferences[preferencesCount, 4] + "@";
            preferencesCount++;
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
           //label += DoF_UserId[DoF_UserId_count, 0] + "    " + DoF_UserId[DoF_UserId_count, 1] + "@";
            DoF_UserId_count++;
        }

        //If all the preferences are selected
        label = all(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        label = "";
        for (int i = 0; i < userCount; i++)
        {
            label += users[i, 0] + "  " + users[i, 1] + "@";
        }
        label = label.Replace("@", "<br />");
        lbl_Message.Text = label;
    }
    public void age_nationality(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {
                if (((Convert.ToInt32(preferences[i, 2]) == 5) && (Convert.ToInt32(preferences[j, 2]) == 5)) && ((Convert.ToInt32(preferences[i, 3]) == 1) && (Convert.ToInt32(preferences[j, 3]) == 1)) && (Convert.ToInt32(preferences[i, 1]) == Convert.ToInt32(preferences[j, 1])) && (Convert.ToInt32(preferences[i, 4]) == Convert.ToInt32(preferences[j, 4])))
                {

                }
            }
        }
    }
    public string all(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        string stringlabel ="";
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j =i+ 1; j < preferencesCount; j++)
            {
                if ((Convert.ToInt32(preferences[i, 1]) == Convert.ToInt32(preferences[j, 1])) && (Convert.ToInt32(preferences[i, 2]) == Convert.ToInt32(preferences[j, 2])) && (Convert.ToInt32(preferences[i, 3]) == Convert.ToInt32(preferences[j, 3])) &&(Convert.ToInt32(preferences[i, 4]) == Convert.ToInt32(preferences[j, 4])))
                {
                    if ((course_UserID[i, 1].Trim() == course_UserID[j, 1].Trim()) && (nationality_UserID[i, 1].Trim() == nationality_UserID[j, 1].Trim()))
                    {
                        if (preferences[j, 1] == "3")
                        {
                            if (((Convert.ToInt32(DoF_UserId[i, 1]) < 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 20)))
                            {
                                //lbl_Message.Text = preferences[0, 3];
                                if (Convert.ToInt32(preferences[i, 3]) == 2)
                                {
                                    if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                    {
                                        save(preferences, i, j);
                                        group++;

                                    }
                                }
                            }
                            else if (Convert.ToInt32(preferences[i, 3]) == 4)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    save(preferences, i, j);
                                    group++;
                                }
                            }
                        }

                        else if ((preferences[i, 1] == "4") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 20) && (Convert.ToInt32(DoF_UserId[i, 1]) < 25)) && (((Convert.ToInt32(DoF_UserId[j, 1]) > 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 25)))))
                        {
                            if (Convert.ToInt32(preferences[i, 3]) == 2)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                {
                                    save(preferences, i, j);
                                    group++;
                                }
                            }
                            else if (Convert.ToInt32(preferences[i, 3]) == 4)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    save(preferences, i, j);
                                    group++;
                                }
                            }
                        }
                        else if ((preferences[i, 1] == "5") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35)) && ((Convert.ToInt32(DoF_UserId[j, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35))))
                        {
                            if (Convert.ToInt32(preferences[i, 3]) == 2)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                {
                                    save(preferences, i, j);
                                    group++;
                                }
                            }
                            else if (Convert.ToInt32(preferences[i, 3]) == 4)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    save(preferences, i, j);
                                    group++;
                                }
                            }
                        }
                        else if ((preferences[i, 1] == "6") && ((Convert.ToInt32(DoF_UserId[i, 1]) > 35) && (Convert.ToInt32(DoF_UserId[j, 1]) > 35)))
                        {
                            if (Convert.ToInt32(preferences[i, 3]) == 2)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                {
                                    save(preferences, i, j);
                                    group++;
                                }
                            }
                            else if (Convert.ToInt32(preferences[i, 3]) == 4)
                            {
                                if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    save(preferences, i, j);
                                    
                                }
                            }
                        }
                    }
                }
                
            }
        }

        return stringlabel;
    }

    public void save(string[,] preferences, int i, int j)
    {
        string id = preferences[i, 0];
        string id2 = preferences[j, 0];
        if (userCount != 0)
        {
            bool male = false;
            for (int m = 0; m < userCount; m++)
            {
                if ((users[m, 0] == id))
                {
                    male = true;
                }

            }
            if (male == false)
            {
                users[userCount, 0] = id;
                users[userCount, 1] = group.ToString();
                userCount++;
            }
            male = false;
            for (int m = 0; m < userCount; m++)
            {
                if ((users[m, 0] == id2))
                {
                    male = true;

                }
            }
            if (male == false)
            {
                users[userCount, 0] = id2;
                users[userCount, 1] = group.ToString();
                userCount++;
            }
        }
        else
        {
            users[userCount, 0] = id;
            users[userCount, 1] = group.ToString();
            userCount++;
            users[userCount, 0] = id2;
            users[userCount, 1] = group.ToString();
            userCount++;
        }
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