using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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

        string userQuery = "";
        int[] customerID = new int[lastUserID];
        int customerIDcount = 0;
        for (int i = 0; i <= lastUserID; i++)
        {
            try
            {
                userQuery = "select customer_ID from PersonalData where User_ID='" + i + "'";
                SqlCommand customerCommand = new SqlCommand(userQuery, connect);

                string customer = customerCommand.ExecuteScalar().ToString();
                customer = customer.Trim();
                if (customer != "")
                {
                    customerID[customerIDcount] = Convert.ToInt32(customer);
                    label += customerID[customerIDcount];
                    customerIDcount++;
                }
            }
            catch (Exception ex)
            { 
            
            }

        }


        
    }
}