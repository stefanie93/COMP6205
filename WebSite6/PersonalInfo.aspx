<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInfo.aspx.cs" Inherits="PersonalInfo" %>

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
                    <h1 id="top_title">
                        Book Room</h1>
                </div>
            </div>
            <div>
                <img class="img_title" src="./images/soton-bridge.jpg" alt="bridge" />
            </div>
        </header>
        <div id="wrapper">
            <div class="wrap_title" id="rooms">
                    
                <h1>
                    Details</h1>
               
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>" 
                    SelectCommand="SELECT * FROM [PersonalData]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Registration_ConnectionString %>" 
                    SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                <asp:TextBox ID="txt_PIvalueForm" runat="server" Visible="False"></asp:TextBox>
                <br />
               
                <div class="content_area">
                    <div class="content_wrap">
                        
                        <asp:Label ID="lbl_Message" runat="server"></asp:Label>
                        <br />
                        
                        <asp:Label ID="Label1" runat="server" Text="What will be the year of study? *"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_StudyYear" runat="server" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="1000px">
                            <asp:ListItem Selected="True">Please Select...</asp:ListItem>
                            <asp:ListItem Value="Applicant">Applicant</asp:ListItem>
                            <asp:ListItem>2nd Year</asp:ListItem>
                            <asp:ListItem Value="3rd Year"></asp:ListItem>
                            <asp:ListItem Value="4th Year"></asp:ListItem>
                            <asp:ListItem>Postgraduate</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Course type * "></asp:Label>
                        <br />
                        <asp:TextBox ID="CourseTextBox" runat="server" Width="1000px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Your Gender *"></asp:Label>
                        <br />
                        <asp:RadioButton ID="MaleRButton" runat="server" Text="Male" Width="100px" 
                            oncheckedchanged="MaleRButton_CheckedChanged" />
                        <asp:RadioButton ID="FemaleRButton" runat="server" Text="Female" 
                            Width="100px" oncheckedchanged="FemaleRButton_CheckedChanged" />
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Are you a smoker? *"></asp:Label>
                        <br />
                        <asp:RadioButton ID="smokerNo" runat="server" Text="No" Width="100px" 
                            oncheckedchanged="smokerNo_CheckedChanged" />
                        <asp:RadioButton ID="smokerYes" runat="server" Text="Yes" Width="100px" 
                            oncheckedchanged="smokerYes_CheckedChanged" />
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" 
                            Text="Please note that all our properties are non-smoking."></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Date of birth *"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_Day" runat="server">
                        </asp:DropDownList>
&nbsp;
                        <asp:DropDownList ID="dp_month" runat="server">
                        </asp:DropDownList>
&nbsp;
                        <asp:DropDownList ID="dp_year" runat="server">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Nationality *"></asp:Label>
                        <br />
                        <asp:DropDownList ID="dp_nationalityList" runat="server" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged" Width="1000px">
                            <asp:ListItem Selected="True">Please Select...</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        
                        <asp:Label ID="Label8" runat="server" Text="Phone number *"></asp:Label>
                        <br />
                        <asp:TextBox ID="CountryCodeTBox" runat="server" MaxLength="6" Width="70px"></asp:TextBox>
                        <asp:TextBox ID="telephoneTBox" runat="server" MaxLength="20"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        Home Address<br />
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:Label ID="Label9" runat="server" Text="Address line 1 *"></asp:Label>
                            <br />
                            <asp:TextBox ID="AddressTBox1" runat="server" Width="1000px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label10" runat="server" Text="Address line 2"></asp:Label>
                            <br />
                            <asp:TextBox ID="AddressTBox2" runat="server" Width="1000px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label11" runat="server" Text="Address line 3"></asp:Label>
                            <br />
                            <asp:TextBox ID="AddressTBox3" runat="server" Width="1000px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label12" runat="server" Text="Address line 4"></asp:Label>
                            <br />
                            <asp:TextBox ID="AddressTBox4" runat="server" Width="1000px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label13" runat="server" Text="City/Country *"></asp:Label>
                            <br />
                            <asp:TextBox ID="CountryTBox" runat="server" Height="25px" Width="1000px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Label14" runat="server" Text="Postcode *"></asp:Label>
                            <br />
                            <asp:TextBox ID="PostcodeTBox" runat="server" Width="1000px"></asp:TextBox>
                            <br />
                            <asp:Button ID="btn_next" runat="server" onclick="btn_next_Click" 
                                style="height: 26px" Text="Next" />
                        </asp:Panel>
                        
                    </div>
                </div>
                
            </div>
        </div>
        <footer>
        </footer>
    </div>
    </form>
</body>
</html>
