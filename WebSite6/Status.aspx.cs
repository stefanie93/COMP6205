using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int user_id = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["User_ID_Home"]))
        {
            user_id = Convert.ToInt32(Request.QueryString["User_ID_Home"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["User_ID_login"]))
        {
            user_id = Convert.ToInt32(Request.QueryString["User_ID_login"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["User_ID_PI"]))
        {
            user_id = Convert.ToInt32(Request.QueryString["User_ID_PI"]);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["User_ID_Pref"]))
        {
            user_id = Convert.ToInt32(Request.QueryString["User_ID_Pref"]);
        }

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonalData_ConnectionString"].ConnectionString);
        connect.Open();
        int studio = 3;

        DataView DataViewForUsers = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForUsers in DataViewForUsers)
        {
            if (Convert.ToInt32(DataRowViewForUsers["User_ID"].ToString()) == user_id)
            {
                lbl_name.Text = DataRowViewForUsers["FirstName"].ToString();
                lbl_surname.Text = DataRowViewForUsers["LastName"].ToString();
            }
        }

        DataView DataViewForPersonal = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView DataRowViewForPersonal in DataViewForPersonal)
        {
            if (Convert.ToInt32(DataRowViewForPersonal["User_ID"].ToString()) == user_id)
            {
                studio = Convert.ToInt32(DataRowViewForPersonal["isStudioSelected"].ToString());
            }
        }
        if (studio == 0)
        {
            Lbl_roomType.Text = "En-Suite";
            lbl_pricePW.Text = "£100";
            lbl_priceTotal.Text = "£5,610";
        }
        else
        {
            Lbl_roomType.Text = "Studio";
            lbl_pricePW.Text = "£150";
            lbl_priceTotal.Text = "£7,650";           
        }
        connect.Close();
    }
}