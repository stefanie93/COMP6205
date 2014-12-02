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
                        <asp:Label ID="Label1" runat="server" Text="Flatemate preference based on Age"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_agePref" runat="server" Width="800px">
                            <asp:ListItem Selected="True">Please select...</asp:ListItem>
                            <asp:ListItem>under 19</asp:ListItem>
                            <asp:ListItem>18-21</asp:ListItem>
                            <asp:ListItem>20-25</asp:ListItem>
                            <asp:ListItem>25-35</asp:ListItem>
                            <asp:ListItem>above 35</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" 
                            Text="Flatemate preference based on Gender"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_genderPref" runat="server" Width="800px">
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
                            <asp:RadioButton ID="rb_yesNationPref" runat="server" Text="Yes" 
                                Width="100px" />
                            <asp:RadioButton ID="rb_noNationPref" runat="server" Text="No" Width="100px" />
                        </asp:Panel>
                        <br />
                        <asp:Label ID="Label4" runat="server" 
                            Text="Flatemate preference based on your Course"></asp:Label>
                        <br />
                        <asp:Panel ID="Panel3" runat="server">
                            <asp:RadioButton ID="rb_yesCoursePref" runat="server" Text="Yes" 
                                Width="100px" />
                            <asp:RadioButton ID="rb_noCoursePref" runat="server" Text="No" Width="100px" />
                        </asp:Panel>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="cmd_confirmation" runat="server" onclick="Button1_Click" 
                            Text="Next - Confirmation" />
                    </asp:Panel>

                    </div>
                </div>
            </div>
            <footer>
            </footer>
        </div>
    </form>
</body>
</html>
