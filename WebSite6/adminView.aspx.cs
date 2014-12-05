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
    
    int userCount = 0;
    int group = 0;
    string[,] users = new string[1000, 5];
    string[,] print_data = new string[100000, 10];
    int print_data_count = 0;
    string[,] roomsArray = new string[100000, 5];
    int roomsArrayCount = 0;
    int studioNum = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void emptyTables()
    {
        for (int i = 0; i < userCount; i++)
        {
            users[i, 0] = null;
            users[i, 1] = null;
            users[i, 2] = null;
            users[i, 3] = null;
            users[i, 4] = null;
        }
        userCount = 0;

        for (int i = 0; i < print_data_count; i++)
        {
            print_data[i, 0] = null;
            print_data[i, 1] = null;
            print_data[i, 2] = null;
            print_data[i, 3] = null;
            print_data[i, 4] = null;
            print_data[i, 5] = null;
            print_data[i, 6] = null;
            print_data[i, 7] = null;
            print_data[i, 8] = null;
        }
        print_data_count = 0;

        for (int i = 0; i < roomsArrayCount; i++)
        {
            roomsArray[i, 0] = null;
            roomsArray[i, 1] = null;
            roomsArray[i, 2] = null;
            roomsArray[i, 3] = null;
            roomsArray[i, 4] = null;
        }
        roomsArrayCount = 0;
    }

    protected void btn_generate_Click(object sender, EventArgs e)
    {
        emptyTables();
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
        //string[,] allSelected = new string[lastUserID,2];
        //string[,] AllDontMind = new string[lastUserID, 2];
        //string[,] age_course = new string[lastUserID, 2];
        //string[,] age_gender = new string[lastUserID, 2];
        //string[,] age_nationality = new string[lastUserID, 2];
        //string[,] course_gender = new string[lastUserID, 2];
        //string[,] course_Nationality = new string[lastUserID, 2];
        //string[,] gender_Nationality = new string[lastUserID, 2];

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
        string[,] studioPreferences = new string[lastUserID, 5];
        int studioPreferencesCount = 0;
        string[,] groupPreferences = new string[lastUserID, 5];
        int groupPreferencesCount = 0;


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
            if ((DataRowViewForPreferences["isStudioSelected"].ToString() == "1")  )
            {
                studioPreferences[studioPreferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
                studioPreferencesCount++;
                
            }
            else
            {
                if (!string.IsNullOrEmpty(DataRowViewForPreferences["groupID"].ToString()))
                {
                    groupPreferences[groupPreferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
                    groupPreferencesCount++;
                   
                }
                else
                {
                    preferences[preferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
                    preferences[preferencesCount, 1] = DataRowViewForPreferences["age_preference_id"].ToString();
                    preferences[preferencesCount, 2] = DataRowViewForPreferences["course_preference_id"].ToString();
                    preferences[preferencesCount, 3] = DataRowViewForPreferences["gender_preference_id"].ToString();
                    preferences[preferencesCount, 4] = DataRowViewForPreferences["nationality_preference_id"].ToString();
                    //label += preferences[preferencesCount, 0] + "    " + preferences[preferencesCount, 1] + "   " + preferences[preferencesCount, 2] + "   " + preferences[preferencesCount, 3] + "    " + preferences[preferencesCount, 4] + "@";
                    preferencesCount++;
                }
            }
            
        }

        DataView DataViewForRooms = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForRooms in DataViewForRooms)
        {
            if (DataRowViewForRooms["isStudio"].ToString().Trim() == "0")
            {
                roomsArray[roomsArrayCount, 0] = DataRowViewForRooms["Room_id"].ToString();
                roomsArray[roomsArrayCount, 1] = DataRowViewForRooms["Flat_id"].ToString();
                roomsArray[roomsArrayCount, 2] = DataRowViewForRooms["Room_num"].ToString();
                roomsArray[roomsArrayCount, 3] = DataRowViewForRooms["Available"].ToString();
                //label += preferences[preferencesCount, 0] + "    " + preferences[preferencesCount, 1] + "   " + preferences[preferencesCount, 2] + "   " + preferences[preferencesCount, 3] + "    " + preferences[preferencesCount, 4] + "@";
                roomsArrayCount++;
            }
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

        for (int i = 0; i < studioPreferencesCount; i++)
        {
            group = 30;
            save_studio(studioPreferences, i);
        }

        for (int i = 0; i < groupPreferencesCount; i++)
        {
            group = 31;
            save_group(groupPreferences, i);
        }

        //If all the preferences are selected
        label = all(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        age_course_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        age_gender_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        age_nationality_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        course_gender_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        course_nationality_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        dont_mind_class(preferencesCount, preferences);
        gender_nationality_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        label = "";

        rooms_allocation(userCount);

        DataView DataViewForRestUsers = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForRestUsers in DataViewForRestUsers)
        {
            if (DataRowViewForRestUsers["PhoneNumber"].ToString() != null)
            {
                print_data[print_data_count, 0] = DataRowViewForRestUsers["User_ID"].ToString();
                print_data[print_data_count, 4] = DataRowViewForRestUsers["PhoneNumber"].ToString();
                print_data_count++;
            }
        }

        DataView DataViewForAllUsers = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForAllUsers in DataViewForAllUsers)
        {
            for (int i = 0; i < print_data_count; i++)
            {
                if (print_data[i, 0] == DataRowViewForAllUsers["User_ID"].ToString())
                {
                    print_data[i, 1] = DataRowViewForAllUsers["FirstName"].ToString();
                    print_data[i, 2] = DataRowViewForAllUsers["LastName"].ToString();
                    print_data[i, 3] = DataRowViewForAllUsers["Email"].ToString();
                }
            }

        }

        for (int i = 0; i < userCount; i++)
        {
            for (int j = 0; j < print_data_count; j++)
            {
                if (users[i, 0] == print_data[j, 0])
                {
                    print_data[j, 5] = users[i, 2];
                    print_data[j, 6] = users[i, 3];
                    print_data[j, 7] = users[i, 4];
                }
            }
        }

        //creating dataTable   
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "Users";
        dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
        dt.Columns.Add(new DataColumn("LastName", typeof(string)));
        dt.Columns.Add(new DataColumn("Email", typeof(string)));
        dt.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("FlatNo", typeof(string)));
        dt.Columns.Add(new DataColumn("RoomNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Studio", typeof(string)));
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate   
        ViewState["Users"] = dt;

        for (int i = 0; i < print_data_count; i++)
        {
            printToGrid(i);
        }

        btn_ensuite.Visible = false;
        btn_generate.Visible = false;
        btn_studios.Visible = false;
        btn_unbook.Visible = false;
        btn_back.Visible = true;

    }

    public void printToGrid(int j)
    {
        if (ViewState["Users"] != null)
        {
            //get datatable from view state   
            DataTable dtCurrentTable = (DataTable)ViewState["Users"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //add each row into data table  
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["FirstName"] = print_data[j, 1];
                    drCurrentRow["LastName"] = print_data[j, 2];
                    drCurrentRow["Email"] = print_data[j, 3];
                    drCurrentRow["PhoneNumber"] = print_data[j, 4];
                    drCurrentRow["FlatNo"] = print_data[j, 5];
                    drCurrentRow["RoomNo"] = print_data[j, 6];
                    drCurrentRow["Studio"] = print_data[j, 7];
                }
                //Remove initial blank row  
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();

                }

                //add created Rows into dataTable  
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Save Data table into view state after creating each row  
                ViewState["Users"] = dtCurrentTable;
                //Bind Gridview with latest Row  
                GridView1.DataSource = dtCurrentTable;
                GridView1.DataBind();
            }
        }

    }

    public void rooms_allocation(int lastUserID)
    {

        int flatid = 0;
        int num = 1;
        int j = 1;
        for (int i = 0; i < userCount; i++)
        {
            if (users[i, 1] != users[j, 1])
            {
                flatid = flatid + 6;
                num = 1;
                j = i;
            }
            if (num <= 6)
            {
                if (users[i, 2] == null)
                {
                    users[i, 2] = roomsArray[flatid, 1];
                    users[i, 3] = num.ToString();
                    if (users[i, 4] == null)
                    {
                        users[i, 4] = "En-Suite";
                    }
                    num++;
                }
            }
            else
            {
                flatid++;
                if (users[i, 2] == null)
                {
                    users[i, 2] = roomsArray[flatid, 1];
                    users[i, 3] = num.ToString();
                    if (users[i, 4] == null)
                    {
                        users[i, 4] = "En-Suite";
                    }
                    num++;
                }
            }
        }

    }

    public void age_nationality_class(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
       
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {

                if (((Convert.ToInt32(preferences[i, 2]) == 5) && (Convert.ToInt32(preferences[j, 2]) == 5)) && ((Convert.ToInt32(preferences[i, 3]) == 1) && (Convert.ToInt32(preferences[j, 3]) == 1)) && (Convert.ToInt32(preferences[i, 1]) == Convert.ToInt32(preferences[j, 1])) && (Convert.ToInt32(preferences[i, 4]) == Convert.ToInt32(preferences[j, 4])))
                {
                    if (nationality_UserID[i, 1].Trim() == nationality_UserID[j, 1].Trim())
                    {
                        if ((preferences[j, 1] == "3") && (((Convert.ToInt32(DoF_UserId[i, 1]) < 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 20))))
                        {
                            group = 9;
                            save(preferences, i, j);
                        }
                        else if ((preferences[i, 1] == "4") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 20) && (Convert.ToInt32(DoF_UserId[i, 1]) < 25)) && (((Convert.ToInt32(DoF_UserId[j, 1]) > 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 25)))))
                        {
                            group = 10;
                            save(preferences, i, j);
                        }
                        else if ((preferences[i, 1] == "5") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35)) && ((Convert.ToInt32(DoF_UserId[j, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35))))
                        {
                            group = 11;
                            save(preferences, i, j);
                        }
                        else if ((preferences[i, 1] == "6") && ((Convert.ToInt32(DoF_UserId[i, 1]) > 35) && (Convert.ToInt32(DoF_UserId[j, 1]) > 35)))
                        {
                            group = 12;
                            save(preferences, i, j);
                        }

                    }
                }
            }
        }
    }

    public void course_gender_class(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {
                if (((Convert.ToInt32(preferences[i, 4]) == 1) && (Convert.ToInt32(preferences[j, 4]) == 1)) && ((Convert.ToInt32(preferences[i, 1]) == 1) && (Convert.ToInt32(preferences[j, 1]) == 1)) && (Convert.ToInt32(preferences[i, 2]) == Convert.ToInt32(preferences[j, 2])) && (Convert.ToInt32(preferences[i, 3]) == Convert.ToInt32(preferences[j, 3])))
                {
                    if (course_UserID[i, 1].Trim() == course_UserID[j, 1].Trim())
                    {
                        if (Convert.ToInt32(preferences[i, 3]) == 2)
                        {
                            if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                            {

                                group = 25;
                                save(preferences, i, j);
                            }
                            else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                            {
                                group = 26;
                                save(preferences, i, j);
                            }
                        }
                    }

                }
            }
        }
    }

    public void gender_nationality_class(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {
                if (((Convert.ToInt32(preferences[i, 2]) == 5) && (Convert.ToInt32(preferences[j, 2]) == 5)) && ((Convert.ToInt32(preferences[i, 1]) == 1) && (Convert.ToInt32(preferences[j, 1]) == 1)) && (Convert.ToInt32(preferences[i, 4]) == Convert.ToInt32(preferences[j, 4])) && (Convert.ToInt32(preferences[i, 3]) == Convert.ToInt32(preferences[j, 3])))
                {
                    if (nationality_UserID[i, 1].Trim() == nationality_UserID[j, 1].Trim())
                    {
                        if (Convert.ToInt32(preferences[i, 3]) == 2)
                        {
                            if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                            {

                                group = 28;
                                save(preferences, i, j);
                            }
                            else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                            {
                                group = 29;
                                save(preferences, i, j);
                            }
                        }
                    }

                }
            }
        }
    }

    public void dont_mind_class(int preferencesCount, string[,] preferences)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            bool male = false;
            for (int m = 0; m < userCount; m++)
            {
                if ((users[m, 0] == preferences[i, 0]))
                {
                    male = true;
                }
            }
            if (male == false)
            {
                users[userCount, 0] = preferences[i, 0];
                users[userCount, 1] = "30";
                userCount++;
            }
        }
    }

    public void course_nationality_class(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {
                if (((Convert.ToInt32(preferences[i, 3]) == 1) && (Convert.ToInt32(preferences[j, 3]) == 1)) && ((Convert.ToInt32(preferences[i, 1]) == 1) && (Convert.ToInt32(preferences[j, 1]) == 1)) && (Convert.ToInt32(preferences[i, 2]) == Convert.ToInt32(preferences[j, 2])) && (Convert.ToInt32(preferences[i, 4]) == Convert.ToInt32(preferences[j, 4])))
                {
                    if (course_UserID[i, 1].Trim() == course_UserID[j, 1].Trim())
                    {
                        if (nationality_UserID[i, 1].Trim() == nationality_UserID[j, 1].Trim())
                        {
                            group = 27;
                            save(preferences, i, j);
                        }
                    }

                }
            }
        }
    }
    
    public void age_gender_class(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {
                if (((Convert.ToInt32(preferences[i, 4]) == 1) && (Convert.ToInt32(preferences[j, 4]) == 1)) && ((Convert.ToInt32(preferences[i, 2]) == 3) && (Convert.ToInt32(preferences[j, 2]) == 3)) && (Convert.ToInt32(preferences[i, 1]) == Convert.ToInt32(preferences[j, 1])) && (Convert.ToInt32(preferences[i, 3]) == Convert.ToInt32(preferences[j, 3])))
                {
                    if ((preferences[j, 1] == "3") && (((Convert.ToInt32(DoF_UserId[i, 1]) < 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 20))))
                    {
                        if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                        {
                            group = 17;
                            save(preferences, i, j);
                        }
                        else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                        {
                            group = 18;
                            save(preferences, i, j);
                        }

                    }
                    else if ((preferences[i, 1] == "4") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 20) && (Convert.ToInt32(DoF_UserId[i, 1]) < 25)) && (((Convert.ToInt32(DoF_UserId[j, 1]) > 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 25)))))
                    {
                        if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                        {
                            group = 19;
                            save(preferences, i, j);
                        }
                        else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                        {
                            group = 20;
                            save(preferences, i, j);
                        }

                    }
                    else if ((preferences[i, 1] == "5") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35)) && ((Convert.ToInt32(DoF_UserId[j, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35))))
                    {
                        if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                        {
                            group = 21;
                            save(preferences, i, j);
                        }
                        else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                        {
                            group = 22;
                            save(preferences, i, j);
                        }

                    }
                    else if ((preferences[i, 1] == "6") && ((Convert.ToInt32(DoF_UserId[i, 1]) > 35) && (Convert.ToInt32(DoF_UserId[j, 1]) > 35)))
                    {
                        if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                        {
                            group = 23;
                            save(preferences, i, j);
                        }
                        else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                        {
                            group = 24;
                            save(preferences, i, j);
                        }

                    }

                }

            }
        }
    }

    public void age_course_class(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i + 1; j < preferencesCount; j++)
            {
                if (((Convert.ToInt32(preferences[i, 4]) == 1) && (Convert.ToInt32(preferences[j, 4]) == 1)) && ((Convert.ToInt32(preferences[i, 3]) == 1) && (Convert.ToInt32(preferences[j, 3]) == 1)) && (Convert.ToInt32(preferences[i, 1]) == Convert.ToInt32(preferences[j, 1])) && (Convert.ToInt32(preferences[i, 2]) == Convert.ToInt32(preferences[j, 2])))
                {
                    if (course_UserID[i, 1].Trim() == course_UserID[j, 1].Trim())
                    {
                        if ((preferences[j, 1] == "3") && (((Convert.ToInt32(DoF_UserId[i, 1]) < 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 20))))
                        {
                            group = 13;
                            save(preferences, i, j);
                        }
                        else if ((preferences[i, 1] == "4") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 20) && (Convert.ToInt32(DoF_UserId[i, 1]) < 25)) && (((Convert.ToInt32(DoF_UserId[j, 1]) > 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 25)))))
                        {
                            group = 14;
                            save(preferences, i, j);
                        }
                        else if ((preferences[i, 1] == "5") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35)) && ((Convert.ToInt32(DoF_UserId[j, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35))))
                        {
                            group = 15;
                            save(preferences, i, j);
                        }
                        else if ((preferences[i, 1] == "6") && ((Convert.ToInt32(DoF_UserId[i, 1]) > 35) && (Convert.ToInt32(DoF_UserId[j, 1]) > 35)))
                        {
                            group = 16;
                            save(preferences, i, j);
                        }

                    }
                }
            }
        }
    }

    public string all(int preferencesCount, string[,] preferences, string[,] course_UserID, string[,] gender_UserID, string[,] nationality_UserID, string[,] DoF_UserId, int course_UserID_count, int gender_UserID_count, int nationality_UserID_count, int DoF_UserId_count)
    {
        string stringlabel ="";
        for (int i = 0; i < preferencesCount; i++)
        {
            for (int j = i+ 1; j < preferencesCount; j++)
            {
                if ((Convert.ToInt32(preferences[i, 1]) == Convert.ToInt32(preferences[j, 1])) && (Convert.ToInt32(preferences[i, 2]) == Convert.ToInt32(preferences[j, 2])) && (Convert.ToInt32(preferences[i, 3]) == Convert.ToInt32(preferences[j, 3])) &&(Convert.ToInt32(preferences[i, 4]) == Convert.ToInt32(preferences[j, 4])))
                {
                    if ((course_UserID[i, 1].Trim() == course_UserID[j, 1].Trim()) && (nationality_UserID[i, 1].Trim() == nationality_UserID[j, 1].Trim()))
                    {
                         if ((preferences[j, 1] == "3") && (((Convert.ToInt32(DoF_UserId[i, 1]) < 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 20))))
                         {

                               if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                               {
                                   group = 1;
                                   save(preferences, i, j);

                               }
                               else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                               {

                                   group = 2;
                                   save(preferences, i, j);
                               }
                                
                        }

                        else if ((preferences[i, 1] == "4") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 20) && (Convert.ToInt32(DoF_UserId[i, 1]) < 25)) && (((Convert.ToInt32(DoF_UserId[j, 1]) > 20) && (Convert.ToInt32(DoF_UserId[j, 1]) < 25)))))
                        {

                                if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                {
                                    group = 3;
                                    save(preferences, i, j);
                                 }
                                if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    group = 4;
                                    save(preferences, i, j);
                                    
                                }
                            
                        }
                        else if ((preferences[i, 1] == "5") && (((Convert.ToInt32(DoF_UserId[i, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35)) && ((Convert.ToInt32(DoF_UserId[j, 1]) > 25) && (Convert.ToInt32(DoF_UserId[j, 1]) < 35))))
                        {

                                if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                {
                                    group = 5;
                                    save(preferences, i, j);
                                    
                                }
                                else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    group = 6;
                                    save(preferences, i, j);
                                    
                                }
                            
                        }
                        else if ((preferences[i, 1] == "6") && ((Convert.ToInt32(DoF_UserId[i, 1]) > 35) && (Convert.ToInt32(DoF_UserId[j, 1]) > 35)))
                        {
                            
                                if (((gender_UserID[j, 1]).Trim() == "male") && (gender_UserID[i, 1].Trim() == "male"))
                                {
                                    group = 7;
                                    save(preferences, i, j);
                                    
                                }
                                else if (((gender_UserID[j, 1]).Trim() == "female") && (gender_UserID[i, 1].Trim() == "female"))
                                {
                                    group = 8;
                                    save(preferences, i, j);
                                }
                            

                        }
                    }
                }
                
            }
        }

        return stringlabel;
    }

    public void save_studio(string[,] Studio_preferences, int i)
    {
        string id = Studio_preferences[i,0];
        
        users[userCount, 0] = id;
        users[userCount, 1] = group.ToString();
        users[userCount, 4] = "Studio";
        userCount++;
            
    }

    public void save_group(string[,] group_preferences, int i)
    {
        string id = group_preferences[i, 0];

        users[userCount, 0] = id;
        users[userCount, 1] = group.ToString();
        users[userCount, 4] = "En-Suite";
        userCount++;

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

    protected void btn_studios_Click(object sender, EventArgs e)
    {
        emptyTables();
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        connect.Open();
        string lastQuery = "select max(User_ID) from Users";
        SqlCommand lastCommand = new SqlCommand(lastQuery, connect);
        string last = lastCommand.ExecuteScalar().ToString();
        last = last.Trim();
        int lastUserID = Convert.ToInt32(last);

        string[,] studioPreferences = new string[lastUserID, 2];
        int studioPreferencesCount = 0;

        DataView DataViewForPreferences = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForPreferences in DataViewForPreferences)
        {
            if (DataRowViewForPreferences["isStudioSelected"].ToString() == "1")
            {
                studioPreferences[studioPreferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
                studioPreferencesCount++;
            }
        }

        for (int i = 0; i < studioPreferencesCount; i++)
        {
            group = 30;
            save_studio(studioPreferences, i);
        }
        rooms_allocation(userCount);

        DataView DataViewForRestUsers = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForRestUsers in DataViewForRestUsers)
        {
            if (DataRowViewForRestUsers["isStudioSelected"].ToString() == "1")
            {
                print_data[print_data_count, 0] = DataRowViewForRestUsers["User_ID"].ToString();
                print_data[print_data_count, 4] = DataRowViewForRestUsers["PhoneNumber"].ToString();
                print_data_count++;
            }
        }

        DataView DataViewForAllUsers = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForAllUsers in DataViewForAllUsers)
        {
            for (int i = 0; i < print_data_count; i++)
            {
                if (print_data[i, 0] == DataRowViewForAllUsers["User_ID"].ToString())
                {
                    print_data[i, 1] = DataRowViewForAllUsers["FirstName"].ToString();
                    print_data[i, 2] = DataRowViewForAllUsers["LastName"].ToString();
                    print_data[i, 3] = DataRowViewForAllUsers["Email"].ToString();
                }
            }

        }

        for (int i = 0; i < userCount; i++)
        {
            for (int j = 0; j < print_data_count; j++)
            {
                if (users[i, 0] == print_data[j, 0])
                {
                    print_data[j, 5] = users[i, 2];
                    print_data[j, 6] = users[i, 3];
                    print_data[j, 7] = users[i, 4];
                }
            }
        }

        //creating dataTable   
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "Users";
        dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
        dt.Columns.Add(new DataColumn("LastName", typeof(string)));
        dt.Columns.Add(new DataColumn("Email", typeof(string)));
        dt.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("FlatNo", typeof(string)));
        dt.Columns.Add(new DataColumn("RoomNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Studio", typeof(string)));
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate   
        ViewState["Users"] = dt;

        for (int i = 0; i < print_data_count; i++)
        {
            printToGrid(i);
        }
        btn_ensuite.Visible = false;
        btn_generate.Visible = false;
        btn_studios.Visible = false;
        btn_unbook.Visible = false;
        btn_back.Visible = true;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminView.aspx");
    }

    protected void btn_ensuite_Click(object sender, EventArgs e)
    {
        emptyTables();
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
        //string[,] allSelected = new string[lastUserID,2];
        //string[,] AllDontMind = new string[lastUserID, 2];
        //string[,] age_course = new string[lastUserID, 2];
        //string[,] age_gender = new string[lastUserID, 2];
        //string[,] age_nationality = new string[lastUserID, 2];
        //string[,] course_gender = new string[lastUserID, 2];
        //string[,] course_Nationality = new string[lastUserID, 2];
        //string[,] gender_Nationality = new string[lastUserID, 2];

        string[,] course_UserID = new string[lastUserID, 2];
        int course_UserID_count = 0;
        string[,] gender_UserID = new string[lastUserID, 2];
        int gender_UserID_count = 0;
        string[,] nationality_UserID = new string[lastUserID, 2];
        int nationality_UserID_count = 0;
        string[,] DoF_UserId = new string[lastUserID, 3];
        int DoF_UserId_count = 0;
        string[,] preferences = new string[lastUserID, 5];
        int preferencesCount = 0;
        string[,] groupPreferences = new string[lastUserID, 5];
        int groupPreferencesCount = 0;

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
            if (DataRowViewForPreferences["isStudioSelected"].ToString().Trim() == "0")
            {
                if (!string.IsNullOrEmpty(DataRowViewForPreferences["groupID"].ToString()))
                {
                    groupPreferences[groupPreferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
                    groupPreferencesCount++;

                }
                else
                {
                    preferences[preferencesCount, 0] = DataRowViewForPreferences["User_ID"].ToString();
                    preferences[preferencesCount, 1] = DataRowViewForPreferences["age_preference_id"].ToString();
                    preferences[preferencesCount, 2] = DataRowViewForPreferences["course_preference_id"].ToString();
                    preferences[preferencesCount, 3] = DataRowViewForPreferences["gender_preference_id"].ToString();
                    preferences[preferencesCount, 4] = DataRowViewForPreferences["nationality_preference_id"].ToString();
                    //label += preferences[preferencesCount, 0] + "    " + preferences[preferencesCount, 1] + "   " + preferences[preferencesCount, 2] + "   " + preferences[preferencesCount, 3] + "    " + preferences[preferencesCount, 4] + "@";
                    preferencesCount++;
                }
            }

        }

        DataView DataViewForRooms = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForRooms in DataViewForRooms)
        {
            if (DataRowViewForRooms["isStudio"].ToString().Trim() == "0")
            {
                roomsArray[roomsArrayCount, 0] = DataRowViewForRooms["Room_id"].ToString();
                roomsArray[roomsArrayCount, 1] = DataRowViewForRooms["Flat_id"].ToString();
                roomsArray[roomsArrayCount, 2] = DataRowViewForRooms["Room_num"].ToString();
                roomsArray[roomsArrayCount, 3] = DataRowViewForRooms["Available"].ToString();
                //label += preferences[preferencesCount, 0] + "    " + preferences[preferencesCount, 1] + "   " + preferences[preferencesCount, 2] + "   " + preferences[preferencesCount, 3] + "    " + preferences[preferencesCount, 4] + "@";
                roomsArrayCount++;
            }
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

        for (int i = 0; i < groupPreferencesCount; i++)
        {
            group = 31;
            save_group(groupPreferences, i);
        }

        //If all the preferences are selected
        label = all(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        age_course_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        age_gender_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        age_nationality_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        course_gender_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        course_nationality_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        dont_mind_class(preferencesCount, preferences);
        gender_nationality_class(preferencesCount, preferences, course_UserID, gender_UserID, nationality_UserID, DoF_UserId, course_UserID_count, gender_UserID_count, nationality_UserID_count, DoF_UserId_count);
        label = "";



        rooms_allocation(userCount);

        DataView DataViewForRestUsers = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForRestUsers in DataViewForRestUsers)
        {
            if ((DataRowViewForRestUsers["PhoneNumber"].ToString() != null) && (DataRowViewForRestUsers["isStudioSelected"].ToString().Trim() == "0"))
            {
                print_data[print_data_count, 0] = DataRowViewForRestUsers["User_ID"].ToString();
                print_data[print_data_count, 4] = DataRowViewForRestUsers["PhoneNumber"].ToString();
                print_data_count++;
            }
        }

        DataView DataViewForAllUsers = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForAllUsers in DataViewForAllUsers)
        {
            for (int i = 0; i < print_data_count; i++)
            {
                if (print_data[i, 0] == DataRowViewForAllUsers["User_ID"].ToString())
                {
                    print_data[i, 1] = DataRowViewForAllUsers["FirstName"].ToString();
                    print_data[i, 2] = DataRowViewForAllUsers["LastName"].ToString();
                    print_data[i, 3] = DataRowViewForAllUsers["Email"].ToString();
                }
            }

        }

        for (int i = 0; i < userCount; i++)
        {
            for (int j = 0; j < print_data_count; j++)
            {
                if (users[i, 0] == print_data[j, 0])
                {
                    print_data[j, 5] = users[i, 2];
                    print_data[j, 6] = users[i, 3];
                    print_data[j, 7] = users[i, 4];
                }
            }
        }

        //creating dataTable   
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "Users";
        dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
        dt.Columns.Add(new DataColumn("LastName", typeof(string)));
        dt.Columns.Add(new DataColumn("Email", typeof(string)));
        dt.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("FlatNo", typeof(string)));
        dt.Columns.Add(new DataColumn("RoomNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Studio", typeof(string)));
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate   
        ViewState["Users"] = dt;

        for (int i = 0; i < print_data_count; i++)
        {
            printToGrid(i);
        }

        btn_ensuite.Visible = false;
        btn_generate.Visible = false;
        btn_studios.Visible = false;
        btn_unbook.Visible = false;
        btn_back.Visible = true;

    }

    protected void btn_unbook_Click(object sender, EventArgs e)
    {
        emptyTables();
        lbl_Message.Text = "";
        //Connection with the Internal server
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        connect.Open();
        string lastQuery = "select max(User_ID) from Users";
        SqlCommand lastCommand = new SqlCommand(lastQuery, connect);
        string last = lastCommand.ExecuteScalar().ToString();
        last = last.Trim();
        int lastUserID = Convert.ToInt32(last);

        //string label = "";

       
            DataView DataViewForAllUsers = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);

            foreach (DataRowView DataRowViewForAllUsers in DataViewForAllUsers)
            {
                
                    if (DataRowViewForAllUsers["state"].ToString() == "0")
                    {
                        print_data[print_data_count, 1] = DataRowViewForAllUsers["FirstName"].ToString();
                        print_data[print_data_count, 2] = DataRowViewForAllUsers["LastName"].ToString();
                        print_data[print_data_count, 3] = DataRowViewForAllUsers["Email"].ToString();
                        print_data_count++;
                    }
            

            }

            
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "Users";
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["Users"] = dt;

            for (int j = 0; j < print_data_count; j++)
            {
                if (ViewState["Users"] != null)
                {
                    //get datatable from view state   
                    DataTable dtCurrentTable = (DataTable)ViewState["Users"];
                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {

                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //add each row into data table  
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["FirstName"] = print_data[j, 1];
                            drCurrentRow["LastName"] = print_data[j, 2];
                            drCurrentRow["Email"] = print_data[j, 3];
                        }
                        //Remove initial blank row  
                        if (dtCurrentTable.Rows[0][0].ToString() == "")
                        {
                            dtCurrentTable.Rows[0].Delete();
                            dtCurrentTable.AcceptChanges();

                        }

                        //add created Rows into dataTable  
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        //Save Data table into view state after creating each row  
                        ViewState["Users"] = dtCurrentTable;
                        //Bind Gridview with latest Row  
                        GridView1.DataSource = dtCurrentTable;
                        GridView1.DataBind();
                    }
                }
            }

            btn_ensuite.Visible = false;
            btn_generate.Visible = false;
            btn_studios.Visible = false;
            btn_unbook.Visible = false;
            btn_back.Visible = true;

    }
}