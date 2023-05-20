<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManagerRegPage.aspx.cs" Inherits="WebApplication2.StadiumManagerRegPage" %>

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
            <asp:TextBox ID= "SM_name" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Username"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "SM_username" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Password"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "SM_password" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Stadium Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "SM_stadiumName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="stadiumManagerReg" runat="server" OnClick="SMReg" Text="Register"></asp:Button>
        </div>
         <div>
            <asp:Label  ID="SMRegError" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
