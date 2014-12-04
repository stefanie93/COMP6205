<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminView.aspx.cs" Inherits="adminView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btn_generate" runat="server" onclick="btn_generate_Click" 
            Text="Generate" />
        <br />
        <br />
        <asp:Label ID="lbl_Message" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
