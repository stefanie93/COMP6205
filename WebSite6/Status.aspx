<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Status.aspx.cs" Inherits="Status" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="Css/Details.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page_wrapper">
        <header>
            <div id="banner">
                <div id="navigation">
                    <ul id="nav">
                        <li><asp:Button ID="Btn_home" runat="server" OnClick="Button1_Click" Text="Home"
                                Height="30px" Width="150px" BackColor="#dedede" BorderColor="#dedede" BorderStyle="None"
                                BorderWidth="0px" Font-Bold="True" Font-Underline="True" 
                                ForeColor="#333399" /></li>
                    </ul>
                </div>
            </div>
            <div>
                <img class="img_title" src="./images/soton-bridge.jpg" alt="bridge" />
            </div>
        </header>
        <div id="wrapper">
            <div class="wrap_title">
                <h1>
                    Status</h1>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>"
                    SelectCommand="SELECT * FROM [PersonalData]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Registration_ConnectionString %>"
                    SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                <br />
            </div>
            <div class="content_area">
                <div class="content_wrap">
                    <asp:Label ID="Label1" runat="server" Text="Name: " Width="100px"></asp:Label>
                    <asp:Label ID="lbl_name" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt"
                        Width="200px"></asp:Label>
                    <asp:Label ID="lbl_surname" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt"
                        Width="200px"></asp:Label>
                    <br />
                    <br />
                    <section>
                        <h2>
                            Room Booked</h2>
                        <asp:Panel ID="Panel1" runat="server">
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Room Type:" Width="150px"></asp:Label>
                            <asp:Label ID="Lbl_roomType" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt"
                                Width="200px"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Price Per Week:" Width="150px"></asp:Label>
                            <asp:Label ID="lbl_pricePW" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="15pt"
                                Width="200px"></asp:Label>
                                <br />
                                <br />
                            <asp:Label ID="Label6" runat="server" Text="Total Price:" Width="150px"></asp:Label>
                            <asp:Label ID="lbl_priceTotal" runat="server" Font-Bold="True" Font-Italic="True"
                                Font-Size="15pt" Width="200px"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label7" runat="server" Text="Contract Duration:" Width="150px"></asp:Label>
                            <asp:Label ID="lbl_contract" runat="server" Text="51 weeks" Font-Bold="True" Font-Italic="True"
                                Font-Size="15pt" Width="200px"></asp:Label>
                                <br />
                                <br />
                            <asp:Label ID="Label8" runat="server" Text="Start date:" Width="150px"></asp:Label>
                            <asp:Label ID="Label9" runat="server" Text="05/09/2015" Font-Italic="True" Font-Size="15pt"
                                Width="200px" Font-Bold="True"></asp:Label>
                            <br />
                            <br />
                        </asp:Panel>
                        <br />
                        <br />
                        <asp:Label ID="Label10" runat="server" Font-Underline="True" Text="Status :" Width="200px"></asp:Label>
                        <asp:Label ID="Label11" runat="server" BackColor="#FFCC00" Font-Bold="True" Font-Names="center"
                            Font-Size="20pt" Height="30px" Text="Pending" Width="110px"></asp:Label>
                        <br />
                    </section>
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
