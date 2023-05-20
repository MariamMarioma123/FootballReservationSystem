<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SAMRegisterPage.aspx.cs" Inherits="WebApplication2.SAMRegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
             <asp:Label runat="server" Text="Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "Sam_Name" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Username"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "Sam_username" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Password"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "Sam_password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="samReg" runat="server" OnClick="SamReg" Text="Register"></asp:Button>
        </div>
         <div>
            <asp:Label  ID="SamRegError" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
