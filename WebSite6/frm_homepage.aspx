<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_homepage.aspx.cs" Inherits="frm_homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Accommodation</title>
    <link rel="Stylesheet" type="text/css" href="Css/StyleSheet.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="page_wrapper">
        <div id="banner">
            <div id="navigation">
                <ul id="nav">
                    <li><a href="#nav">Up</a></li>
                    <li><a href="#rooms">Rooms</a></li>
                    <li><a href="#facilities">Facilities</a></li>
                    <li><a href="#about">About Us</a></li>
                    <li class="last"><a href="#contact">Contact Us</a></li>
                    <li><a href="Form_Login.aspx">Login</a></li>
                   
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Login" />
                   
                        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                            Text="book a room" />
                   
                </ul>
                <!--          
            <li id="nav_book"><a href="#">Book</a></li>

             <ul id="nav_login">
                <li><a href="#">Log In</a></li>
            </ul> 
 -->
            </div>
        </div>
        <div>
            <img class="img_title" src="./images/soton-nature.jpg" alt="narure" />
        </div>
        <div class="main_title">
            <h1 id="top_title">
                Student Accommodation</h1>
        </div>
        <div id="wrapper">
            <div class="wrap_title" id="rooms">
                <h1>
                    Rooms</h1>
                <div class="content_area">
                    <div class="content_wrap">
                        <asp:TextBox ID="txt_Home_valueForm" runat="server"></asp:TextBox>
                         <asp:TextBox ID="txt_Home_userID" runat="server"></asp:TextBox>
                         <asp:TextBox ID="txt_home_login" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="wrap_title" id="facilities">
                <h1>
                    Facilities</h1>
            </div>
            <br />
            <div class="content_wrap" id="about">
                <h1>
                    About Us</h1>
            </div>
            <br />
            <div class="content_wrap" id="contact">
                <h1>
                    Contact Us</h1>
            </div>
            <br />
        </div>
        <div id="footer">
        </div>
    </div>
    </div>
    </form>
</body>
</html>
