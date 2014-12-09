<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminView.aspx.cs" Inherits="adminView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="~/Css/Login.css" />
<script language="javascript" type="text/javascript">
<!--


// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page_wrapper">
        <header>
            <div id="banner">
                <div id="navigation">
                    <ul id="nav">
                        <li>                        
                            <asp:Button ID="Btn_home" runat="server" OnClick="Button1_Click" Text="Home"
                                Height="30px" Width="150px" BackColor="#C3C3C3" BorderColor="#C3C3C3" BorderStyle="None"
                                BorderWidth="0px" Font-Bold="True" Font-Underline="True" 
                                ForeColor="#333399" />
                        </li>
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
        <div class="wrapper_admin">
            <div>
            <section class="grid"></section>
                <asp:GridView horizontalalign="Center" ID="GridView1" runat="server">
                </asp:GridView></section>
                <ul>
                <li><input type="button" ID="btn_generate" class="wrap_box" runat="server"  Style="height: 50px"
                     value="See All Room Allocation" onserverclick="btn_generate_Click" /></li>     
                <li><input type="button" ID="btn_back" runat="server" onserverclick="btn_back_Click" value="Back" Style="height: 50px"
                   Visible="False" /></li>
                <li><input type="button" ID="btn_studios" class="wrap_box" runat="server" Style="height:50px"
                    value="See the allocation only for Studios" onserverclick="btn_studios_Click"/></li>
                <li><input type="button" ID="btn_ensuite" class="wrap_box" runat="server" Style="height:50px" 
                    value="See the allocation only for En-Suite" onserverclick="btn_ensuite_Click" /></li>
                <li><input type="button" ID="btn_unbook"  class="wrap_box" runat="server" Style="height:50px"
                    value="See all the registered users that didn't book any room" onserverclick="btn_unbook_Click" /></li>
                </ul>
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
