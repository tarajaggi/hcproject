<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecuredUser.aspx.cs" Inherits="WebApplication3.SecuredUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label_Welcome" runat="server" Text="Welcome "></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLinkDept" runat="server" NavigateUrl="~/Department.aspx">Register Department Here!!</asp:HyperLink>
            <br />
            <br />
            <asp:Button ID="Btn_logout" runat="server" OnClick="Btn_logout_Click" Text="Logout" />
        </div>
    </form>
</body>
</html>
