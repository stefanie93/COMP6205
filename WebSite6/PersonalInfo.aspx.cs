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
        txt_PIvalueForm.Text = "d";
        string user_id;
        System.Collections.Specialized.NameValueCollection previuseFormCollection = Request.Form;


        if (previuseFormCollection["txt_Home_valueForm"] != "d")
        {
            if (previuseFormCollection["txt_home_login"] == "d")
            {
                Server.Transfer("~/Form_Login.aspx", true);
            }
            else
            {
                user_id = previuseFormCollection["txt_Home_userID"];
            }
        }
        else
        {
            user_id = previuseFormCollection["txt_Login_userID"];
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
        
    }

   public string endl { get; set; }
   protected void FemaleRButton_CheckedChanged(object sender, EventArgs e)
   {
       if (FemaleRButton.Checked == true)
       {
           MaleRButton.Checked = false;
       }
   }
   protected void MaleRButton_CheckedChanged(object sender, EventArgs e)
   {
       if (MaleRButton.Checked == true)
       {
           FemaleRButton.Checked = false;
       }
   }
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
}