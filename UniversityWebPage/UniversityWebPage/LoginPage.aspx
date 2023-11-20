<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="UniversityWebPage.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
        <br />
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" Text="ID number:"></asp:Label>
            <asp:TextBox ID="txtLoginID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblErrorID" runat="server" Text="Incorrect ID. Please try again." Visible="False" ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtLoginPass" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblErrorPass" runat="server" Text="Incorrect password. Please try again." Visible="False" ></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnEnter" runat="server" Text="Enter" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
        
    </form>
</body>
</html>
