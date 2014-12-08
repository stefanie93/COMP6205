<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminView.aspx.cs" Inherits="adminView" %>

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
            <div>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                <asp:Button ID="btn_generate" runat="server" OnClick="btn_generate_Click" Style="height: 50px;
                    font-size= large" Text="See All Room Allocation" Width="465px" />
                <br />
                <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" Style="height: 50px;
                    font-size= large" Visible="False" />
                <br />
                <asp:Button ID="btn_studios" runat="server" Style="height: 50px; font-size= large"
                    Text="See the allocation only for Studios" Width="465px" OnClick="btn_studios_Click" />
                <br />
                <br />
                <asp:Button ID="btn_ensuite" runat="server" Style="height: 50px; font-size= large"
                    Text="See the allocation only for En-Suite" Width="465px" OnClick="btn_ensuite_Click" />
                <br />
                <br />
                <asp:Button ID="btn_unbook" runat="server" Style="height: 50px; font-size= large"
                    Text="See all the registered users that didn't book any room" Width="465px" OnClick="btn_unbook_Click" />
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>"
                    OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [PersonalData]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>"
                    OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Rooms]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>"
                    OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Flats]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>"
                    OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Users]">
                </asp:SqlDataSource>
                <br />
                <br />
                <br />
                <asp:Label ID="lbl_Message" runat="server"></asp:Label>
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
    </form>
</body>
</html>
