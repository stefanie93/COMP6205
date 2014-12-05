<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form_Login.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="~/Css/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page_wrapper">
        <header>
            <div id="banner">
                <div id="navigation">
                    <ul id="nav">
                        <li><a href="frm_homepage.aspx">Home</a></li>
                    </ul>
                </div>
            </div>
            <div class="empty">
            </div>
            <div class="main_title">
                <h1 id="top_title">
                    Student Accommodation</h1>
            </div>
        </header>
        <div class="wrapper">
            <div class="content_area_log">
                <div class="tab_header_log">
                    <h2>
                        LOG IN
                    </h2>
                </div>
                <div class="tab_content">
                <asp:Label ID="lbl_Message" runat="server" ></asp:Label>
                <asp:TextBox ID="txt_Login_userID" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <div class="content_area">
                    
                    
                        <asp:Label ID="lbl_email" runat="server" Height="20px" Text="Email address *" AssociatedControlID="btn_login"></asp:Label>
                        <br />
                        <asp:TextBox ID="txt_email" runat="server" Height="30px" Width="180px"></asp:TextBox>
                        <br /> <br />
                        <asp:Label ID="PasswordLabel" runat="server" Height="20px" Text="Password *" AssociatedControlID="txt_Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="txt_Password" runat="server" Height="30px" Width="180px" TextMode="Password"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="btn_login" runat="server" Height="30px" Width="180px" onclick="btn_login_Click" Text="Log In" />
                    </div>
                </div>
            </div>
            <div class="content_area_register">
                <div class="tab_header_reg">
                    <h2>
                        REGISTER
                    </h2>
                </div>

                <div class="tab_content">
                    <div class="content_area_r">
                    <asp:Label ID="lbl_Name0" runat="server" 
        AssociatedControlID="btn_login" Height="10px" Width="20px"></asp:Label> 
        <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="Mr"></asp:ListItem>
        <asp:ListItem Value="Miss"></asp:ListItem>
        <asp:ListItem Value="Mrs"></asp:ListItem>
        <asp:ListItem Value="Ms"></asp:ListItem>
    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lbl_Name" runat="server" Height="10px" AssociatedControlID="btn_login" Text="Name *"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_Name" runat="server" Height="20px" Width="200px" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl_Surame" runat="server" Height="10px" AssociatedControlID="btn_login" Text="Surname *"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_Surname" runat="server" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl_RegisterEmail" runat="server" Height="10px" AssociatedControlID="btn_login" Text="Email address *"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_RegisterEmail" runat="server" Height="20px" Width="200px" ontextchanged="txt_RegisterEmail_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl_RegisterEmail0" runat="server" Height="10px" AssociatedControlID="btn_login" Text="Re-Enter Email address*"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_RegisterEmailConfirmation"  runat="server" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl_RegisterPassword" runat="server" Height="10px" AssociatedControlID="txt_Password" Text="Password *"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_RegistrationPassword" runat="server" TextMode="Password" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbl_RegisterPasswordConfirmation" runat="server" Height="10px" AssociatedControlID="txt_Password" Text="Confirm Password *"></asp:Label>
                    <br />
                    <asp:TextBox ID="txt_RegisterPasswordConfirmation" runat="server" TextMode="Password" Height="20px" Width="200px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="cmd_Register" runat="server" Height="30px" Width="200px" onclick="cmd_Register_Click" Text="Register" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer>
                Company address
<br />

Suite 4, Blandel Bridge House
<br />
56 Sloane Square
<br />
London
<br />
SW1W 8AX
<br />
United Kingdom
<br />
<br />
Registered as a company in England & Wales
No. 7904120
© 2014 Unilife Ltd
                </footer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Registration_ConnectionString %>"
        SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    </form>
</body>
</html>
