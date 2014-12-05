<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Preferences.aspx.cs" Inherits="Preferences" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Css/Details.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page_wrapper">
        <div id="banner">
            <div id="navigation">
                <ul id="nav">
                    <li><a href="#">Home</a></li>
                </ul>
            </div>
        </div>
        <div>
            <img class="img_title" src="./images/soton-bridge.jpg" alt="bridge" />
        </div>
        <div class="main_title">
            <h1 id="top_title">
                Student Accommodation</h1>
        </div>
        <div id="wrapper">
            <div class="wrap_title">
                <h1>
                    Preferences</h1>
                <div class="content_area">
                    <div class="content_wrap">
                  
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="lbl_Message" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Age_Preferences_ConnectionString %>" 
                            SelectCommand="SELECT * FROM [Age_Preferences]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Course_Preferences_ConnectionString %>" 
                            SelectCommand="SELECT * FROM [Course_Preferences]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Gender_Preferences_ConnectionString %>" 
                            SelectCommand="SELECT * FROM [Gender_Preferences]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Nationality_Preferences_ConnectionString %>" 
                            SelectCommand="SELECT * FROM [Nationality_Preferences]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Registration_ConnectionString %>" 
                            SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>" 
                            SelectCommand="SELECT * FROM [PersonalData]"></asp:SqlDataSource>
                        <asp:Label ID="Label7" runat="server" 
                            Text="If you wish to stay with people you know please enter the group ID, so we are able to put you all together. If you do not have a Group ID, get one by clicking on the generate button below and share it with the people you wish to share the flat. Remember that only up to 6 people can enter the same ID. "></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Width="150px" Text="Enter Group ID"></asp:Label>
                        <asp:TextBox ID="txt_GroupID" runat="server"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" Text="OR"  Width="100px"></asp:Label>
                        <asp:Button ID="btn_generateID" runat="server" Style="height:30px; width:100px;
                            font-size:large" Text="Generate" />
                        <br />
                        <br />
                        <hr />
                        <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Otherwise"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Flatemate preference based on Age"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_agePref" runat="server" Width="800px" 
                            DataSourceID="SqlDataSource1" DataTextField="Year" DataValueField="Age_ID" 
                            onselectedindexchanged="dp_agePref_SelectedIndexChanged" 
                            DataMember="DefaultView">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" 
                            Text="Flatemate preference based on Gender"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_genderPref" runat="server" Width="800px" 
                            DataSourceID="SqlDataSource3" DataTextField="Gender" 
                            DataValueField="Gender_ID">
                            <asp:ListItem>Please select...</asp:ListItem>
                            <asp:ListItem>All females</asp:ListItem>
                            <asp:ListItem>All males</asp:ListItem>
                            <asp:ListItem>Mixed</asp:ListItem>
                            <asp:ListItem>I do not mind</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" 
                            Text="Flatemate preference based on your Nationality"></asp:Label>
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:RadioButton ID="rb_yesNationPref" runat="server" Text="Yes" GroupName = "a" Width="100px" />
                            <asp:RadioButton ID="rb_nationality_dontMind" runat="server" Text="I do not mind" GroupName = "a" Width="200px" />
                        </asp:Panel>
                        <br />
                        <asp:Label ID="Label4" runat="server" 
                            Text="Flatemate preference based on your Course"></asp:Label>
                        <br />
                        <asp:Panel ID="Panel3" runat="server">
                            <asp:RadioButton ID="rb_yesCoursePref" runat="server" Text="Yes" GroupName = "b" Width="100px" />
                            <asp:RadioButton ID="rb_course_dontMind" runat="server" Text="I do not mind" GroupName = "b" Width="200px" />
                        </asp:Panel>
                        <br />
                        <br />
                        <asp:Button ID="btn_Confirmation" runat="server" Text="BOOK" Style="height:50px; width:100px;
                            font-size:large"
                            onclick="btn_Confirmation_Click" />
                        <br />
                    </asp:Panel>

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
    </form>
</body>
</html>
