using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_homepage : System.Web.UI.Page
{
    bool logedin = false;
    string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection previuseFormCollection = Request.Form;
        if (previuseFormCollection["txt_userID"] != "")
        {
            Response.Write("<script language=javascript>alert('ERROR');</script>");
            logedin = true;
            userid = previuseFormCollection["txt_userID"];
        }
        txt_valueForm.Text = "true";
        if (logedin == true)
        {
            txt_login.Text = "y";
            txt_userID.Text = userid;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Server.Transfer("~/Form_Login.aspx", true);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (logedin == true)
        {
            Server.Transfer("~/PersonalInfo.aspx", true);
        }
        else
        {
            Server.Transfer("~/Form_Login.aspx", true);
        }
    }
}