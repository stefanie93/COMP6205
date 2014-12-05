<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Status.aspx.cs" Inherits="Status" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
                        <li><a href="#">Home</a></li>
                    </ul>
            </div>
            <div>
                <img class="img_title" src="./images/soton-bridge.jpg" alt="bridge" />
            </div>
        </header>
        <div id="wrapper">
            <div class="wrap_title">
                <h1>
                    Status</h1>
                      <br />
            </div>
            <div class="content_area">
                <div class="content_wrap">

                    <asp:Label ID="Label1" runat="server" Text="Name: " Width="100px"></asp:Label>
                    <asp:Label ID="lbl_name" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="15pt" Width="200px"></asp:Label>
                    <asp:Label ID="lbl_surname" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="15pt" Width="200px"></asp:Label>
                    <br />
                    <br />
                    <section>
                    <h4> Room Booked</h4>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="Label2" runat="server" Text="Room Type:" Width="150px"></asp:Label>
                        <asp:Label ID="Lbl_roomType" runat="server"  Font-Bold="True" Font-Italic="True" 
                        Font-Size="15pt" Width="200px"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Price Per Week:" Width="150px"></asp:Label>
                        <asp:Label ID="lbl_pricePW" runat="server" Font-Bold="True" Font-Italic="True" 
                            Font-Size="15pt" Width="200px"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="Total Price:" Width="150px"></asp:Label>
                        <asp:Label ID="lbl_priceTotal" runat="server" Font-Bold="True" Font-Italic="True" 
                            Font-Size="15pt" Width="200px" ></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Contract Duration:" Width="150px"></asp:Label>
                        <asp:Label ID="lbl_contract" runat="server" Text="51 weeks" Font-Bold="True" Font-Italic="True" 
                            Font-Size="15pt" Width="200px"></asp:Label>
                        <asp:Label ID="Label8" runat="server" Text="Start date:" Width="150px"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Text="05/09/2015"  Font-Italic="True" 
                            Font-Size="15pt" Width="200px"></asp:Label>
                        <br />
                    </asp:Panel>
                 
                    </section>

                </div>
                </div>
                </div>
                </div>
    </form>
</body>
</html>
