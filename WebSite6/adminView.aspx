<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminView.aspx.cs" Inherits="adminView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

        <asp:Button ID="btn_generate" runat="server" onclick="btn_generate_Click" 
            Text="See All Room Allocation" Width="465px" />
        <br />
        <asp:Button ID="btn_back" runat="server" onclick="btn_back_Click" Text="Back" 
            Visible="False" />
        <br />
        <asp:Button ID="btn_studios" runat="server" 
            Text="See the allocation only for Studios" Width="465px" 
            onclick="btn_studios_Click" />
        <br />
        <br />
        <asp:Button ID="btn_ensuite" runat="server" 
            Text="See the allocation only for En-Suite" Width="465px" />
        <br />
        <br />
        <asp:Button ID="btn_unbook" runat="server" 
            Text="See all the registered users that didn't book any room" 
            Width="465px" />
        <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" DatasourceMode="DataSet"
            ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>" 
            onselecting="SqlDataSource1_Selecting" 
            SelectCommand="SELECT * FROM [PersonalData]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" DatasourceMode="DataSet"
            ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>" 
            onselecting="SqlDataSource1_Selecting" 
            SelectCommand="SELECT * FROM [Rooms]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" DatasourceMode="DataSet"
            ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>" 
            onselecting="SqlDataSource1_Selecting" 
            SelectCommand="SELECT * FROM [Flats]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" DatasourceMode="DataSet"
            ConnectionString="<%$ ConnectionStrings:PersonalData_ConnectionString %>" 
            onselecting="SqlDataSource1_Selecting" 
            SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>

        <br />
        <br />

        <br />
        <asp:Label ID="lbl_Message" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
