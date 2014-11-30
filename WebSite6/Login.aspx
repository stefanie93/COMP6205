<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" 
        onselecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Users]">
    </asp:SqlDataSource>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lbl_email" runat="server" 
        AssociatedControlID="btn_login">Email:</asp:Label>
                                &nbsp;
                                    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ErrorMessage="Please enter email" ControlToValidate="txt_email" 
                                        CssClass="style2"></asp:RequiredFieldValidator>
                                <br />
    <br />
&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="PasswordLabel" runat="server" 
        AssociatedControlID="txt_Password">Password:</asp:Label>
                                &nbsp;
                                    <asp:TextBox ID="txt_Password" runat="server" 
        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ErrorMessage="please enter password" ControlToValidate="txt_Password" 
                                        CssClass="style2"></asp:RequiredFieldValidator>
                                <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_login" runat="server" onclick="btn_login_Click" 
        Text="Log In" />
    <br />
    </form>
</body>
</html>
