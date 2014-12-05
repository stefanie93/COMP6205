<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_homepage.aspx.cs" Inherits="frm_homepage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Student Accommodation</title>
    
    <script src="JScript_1.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="~/Css/StyleSheet.css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="page_wrapper">
        <div id="banner">
            <div id="navigation">
                <ul id="nav">
                    <li><a href="#up">Up</a></li>
                    <li><a href="#rooms">Rooms</a></li>
                    <li><a href="#facilities">Facilities</a></li>
                    <li class="last"><a href="#about">About Us</a></li>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                </ul>
            </div>
        </div>
        <div>
            <img class="img_title" id="up" src="./images/soton-nature.jpg" alt="narure" />
        </div>
        <div class="main_title">
            <h1 id="top_title">
                Student Accommodation</h1>
            <div class="content_wrap1">
                <asp:TextBox ID="txt_Home_valueForm" runat="server" OnTextChanged="txt_Home_valueForm_TextChanged"
                    Visible="False"></asp:TextBox>
                <asp:TextBox ID="txt_Home_userID" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txt_home_login" runat="server" OnTextChanged="txt_home_login_TextChanged"
                    Visible="False"></asp:TextBox>
            </div>
        </div>
        <div class="wrapper_1">
            <div class="content_rooms">
                <div class="wrap_title" id="rooms">
                    <h1>
                        Rooms</h1>
                </div>
                <div class="content_area">
                    <div class="tab_header">
                        <h2>
                            EN-SUITE <span class="tab_remainRooms">(Rooms Available)</span>
                        </h2>
                    </div>
                    <div class="tab_content">
                        <div class="tab_info_title">
                            <h3>
                                Duration:
                            </h3>
                            <hr />
                            <h3>
                                Price:</h3>
                            <hr />
                            <h3>
                                Total Cost:</h3>
                            <hr />
                            <h3>
                                Start:</h3>
                        </div>
                        <div class="tab_info_details">
                            <h3>
                                51 weeks</h3>
                            <hr />
                            <h3>
                                £100 per week</h3>
                            <hr />
                            <h3>
                                £5,610
                            </h3>
                            <hr />
                            <h3>
                                05/09/2015
                            </h3>
                        </div>
                    </div>
                    <div class="wrap_box">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="BOOK NOW" 
                            BackColor="#FF3300" Font-Bold="True" Font-Size="Larger"
                            Height="40px" Width="200px" />
                    </div>
                </div>
                <div>
            <img class="img_room" src="./images/en-suite.jpg" alt="en-suite" />
        </div>
                </div>
                 <div class="content_rooms">
                <div class="content_area">
                    <div class="tab_header">
                        <h2>
                            STUDIO <span class="tab_remainRooms">(Rooms Available)</span>
                        </h2>
                    </div>
                    <div class="tab_content">
                        <div class="tab_info_title">
                            <h3>
                                Duration:
                            </h3>
                            <hr />
                            <h3>
                                Price:</h3>
                            <hr />
                            <h3>
                                Total Cost:</h3>
                            <hr />
                            <h3>
                                Start:</h3>
                        </div>
                        <div class="tab_info_details">
                            <h3>
                                51 weeks</h3>
                            <hr />
                            <h3>
                                £150 per week</h3>
                            <hr />
                            <h3>
                                £7,650
                            </h3>
                            <hr />
                            <h3>
                                05/09/2015
                            </h3>
                        </div>
                        
                    </div>
                <div class="wrap_box">
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="BOOK NOW"
                     BackColor="#FF3300" Font-Bold="True" Font-Size="Larger"
                            Height="40px" Width="200px" />
                </div>
                </div>
                <div>
            <img  class="img_room" src="./images/studio.jpg" alt="studio" />
        </div>
            </div>
            </div>

        <div class="wrapper">
            <div id="content_facilities">
                <div class="wrap_title" id="facilities">
                    <h1>
                        Facilities</h1>
                </div>
                <div class="content_area2">
                    <h4>
                        All our student properties come with everything to make your stay with us really
                        comfortable. We’ve thought long and hard about every detail to make sure we’ve created
                        a space that works for you.</h4>
                    <div class="content_wrap">
                        <div class="facil_col1">
                            <h3>
                                All bills included
                            </h3>
                            <br />
                            <h3>
                                WiFi</h3>
                            <br />
                            <h3>
                                24/7 Secutity</h3>
                            <br />
                            <h3>
                                CCTV security monitoring</h3>
                            <br />
                            <h3>
                                Emergency</h3>
                        </div>
                        <div class="facil_col2">
                            <h3>
                                Laundry and cleaning facilities</h3>
                            <br />
                            <h3>
                                Furnished</h3>
                            <br />
                            <h3>
                                En-suite shower, toilet and washbasin</h3>
                            <br />
                            <h3>
                                Well equipped kitchen area
                            </h3>
                            <br />
                            <h3>
                                Free Gym
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="wrapper">
            <div id="content_about">
                <div class="wrap_title" id="about">
                    <h1>
                        About Us</h1>
                </div>
                <div class="content_area3">
                    <div class="content_wrap">
                        <h3>
                            All our student properties come with everything to make your stay with us really
                            comfortable. We’ve thought long and hard about every detail to make sure we’ve created
                            a space that works for you.</h3>
                        <br />
                        <h3>
                            Contact Us:
                        </h3>
                        <div>
                            telephone number: (+44) 02380 000000<br />
                            email: <a href="mailto:studentaccommodation@yahoo.com">studentaccommodation@yahoo.com</a><br />
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
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Registration_ConnectionString %>"
        SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    </form>
</body>
</html>
