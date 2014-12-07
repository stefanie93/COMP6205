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
                        <li><a href="frm_homepage.aspx">Home</a></li>
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
            <div class="wrap_title">
                <h1>
                    Details</h1>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>"
                    SelectCommand="SELECT * FROM [PersonalData]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Registration_ConnectionString %>"
                    SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                <asp:TextBox ID="txt_PIvalueForm" runat="server" Visible="False"></asp:TextBox>
                <br />
            </div>
            <div class="content_area">
                <div class="content_wrap">
                    <asp:Label ID="lbl_Message" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="What will be the year of study? *"></asp:Label>
                    <br />
                    <asp:DropDownList ID="dp_StudyYear" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Width="1000px">
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
                    <asp:RadioButton ID="MaleRButton" runat="server" GroupName="a" Text="Male" Width="100px"
                        OnCheckedChanged="MaleRButton_CheckedChanged" />
                    <asp:RadioButton ID="FemaleRButton" runat="server" GroupName="a" Text="Female" Width="100px"
                        OnCheckedChanged="FemaleRButton_CheckedChanged" />
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Are you a smoker? *"></asp:Label>
                    <br />
                    <asp:RadioButton ID="smokerNo" runat="server" Text="No" GroupName="b" Width="100px"
                        OnCheckedChanged="smokerNo_CheckedChanged" />
                    <asp:RadioButton ID="smokerYes" runat="server" Text="Yes" GroupName="b" Width="100px"
                        OnCheckedChanged="smokerYes_CheckedChanged" />
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Please note that all our properties are non-smoking."></asp:Label>
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
                    <asp:DropDownList ID="dp_nationalityList" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        Width="1000px">
                        <asp:ListItem Selected="True">Please Select...</asp:ListItem>
                        <asp:ListItem>Afgan</asp:ListItem>
                        <asp:ListItem>Albanian</asp:ListItem>
                        <asp:ListItem>Algerian</asp:ListItem>
                        <asp:ListItem>Andorran</asp:ListItem>
                        <asp:ListItem>Angolan</asp:ListItem>
                        <asp:ListItem>Argentinian</asp:ListItem>
                        <asp:ListItem>American</asp:ListItem>
                        <asp:ListItem>Australian</asp:ListItem>
                        <asp:ListItem>Austrian</asp:ListItem>
                        <asp:ListItem>Azerbaijani</asp:ListItem>
                        <asp:ListItem>Bahamian</asp:ListItem>
                        <asp:ListItem>Bahraini</asp:ListItem>
                        <asp:ListItem Value="Bangladeshi"></asp:ListItem>
                        <asp:ListItem>Barbadian</asp:ListItem>
                        <asp:ListItem>Belarusian</asp:ListItem>
                        <asp:ListItem Value="Belgian"></asp:ListItem>
                        <asp:ListItem>Belizean</asp:ListItem>
                        <asp:ListItem>Beninese</asp:ListItem>
                        <asp:ListItem Value="Bhutanese"></asp:ListItem>
                        <asp:ListItem>Bolivian</asp:ListItem>
                        <asp:ListItem>Bosnian</asp:ListItem>
                        <asp:ListItem Value="Brazilian"></asp:ListItem>
                        <asp:ListItem Value="British"></asp:ListItem>
                        <asp:ListItem Value="Bulgarian"></asp:ListItem>
                        <asp:ListItem Value="Canadian"></asp:ListItem>
                        <asp:ListItem Value="Chinese"></asp:ListItem>
                        <asp:ListItem Value="Colombian"></asp:ListItem>
                        <asp:ListItem Value="Costa Rican"></asp:ListItem>
                        <asp:ListItem>Croatian</asp:ListItem>
                        <asp:ListItem>Cuban</asp:ListItem>
                        <asp:ListItem Value="cypriot">Cypriot</asp:ListItem>
                        <asp:ListItem Value="Czech"></asp:ListItem>
                        <asp:ListItem>Danish</asp:ListItem>
                        <asp:ListItem>Dominican</asp:ListItem>
                        <asp:ListItem Value="Egyptian"></asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                        <asp:ListItem>Esthonian</asp:ListItem>
                        <asp:ListItem>Finnish</asp:ListItem>
                        <asp:ListItem>French</asp:ListItem>
                        <asp:ListItem>Georgian</asp:ListItem>
                        <asp:ListItem Value="German"></asp:ListItem>
                        <asp:ListItem Value="Greek"></asp:ListItem>
                        <asp:ListItem>Dutch</asp:ListItem>
                        <asp:ListItem Value="Icelandic"></asp:ListItem>
                        <asp:ListItem Value="Indian"></asp:ListItem>
                        <asp:ListItem Value="Irish"></asp:ListItem>
                        <asp:ListItem>Italian</asp:ListItem>
                        <asp:ListItem>Kenyan</asp:ListItem>
                        <asp:ListItem>Latvian</asp:ListItem>
                        <asp:ListItem>Lebanese</asp:ListItem>
                        <asp:ListItem>Lithuanian</asp:ListItem>
                        <asp:ListItem Value="Malaysian"></asp:ListItem>
                        <asp:ListItem Value="Mexican"></asp:ListItem>
                        <asp:ListItem Value="Norwegian"></asp:ListItem>
                        <asp:ListItem>Pakistani</asp:ListItem>
                        <asp:ListItem Value="Philippine"></asp:ListItem>
                        <asp:ListItem Value="Portuguese"></asp:ListItem>
                        <asp:ListItem Value="Scottish"></asp:ListItem>
                        <asp:ListItem>Singaporean</asp:ListItem>
                        <asp:ListItem>Slovak</asp:ListItem>
                        <asp:ListItem Value="South African"></asp:ListItem>
                        <asp:ListItem>South Korean</asp:ListItem>
                        <asp:ListItem Value="Spanish"></asp:ListItem>
                        <asp:ListItem Value="Swedish"></asp:ListItem>
                        <asp:ListItem>Syrian</asp:ListItem>
                        <asp:ListItem Value="Thai"></asp:ListItem>
                        <asp:ListItem Value="Turkish"></asp:ListItem>
                        <asp:ListItem Value="Ukrainian"></asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Phone number *"></asp:Label>
                    <br />
                    <asp:TextBox ID="CountryCodeTBox" runat="server" MaxLength="6" Width="37px" Enabled="False"
                        OnTextChanged="CountryCodeTBox_TextChanged">+44</asp:TextBox>
                    <asp:TextBox ID="telephoneTBox" runat="server" MaxLength="20"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    Home Address<br />
                    <asp:Panel ID="Panel1" runat="server" Height="524px">
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
                        <br />
                        <br />
                        <asp:Button ID="btn_next" runat="server" OnClick="btn_next_Click" Style="height: 50px;
                            font-size= large" Text="Next - Preferences" />
                        <br />
                        <br />
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
