<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanRegPage.aspx.cs" Inherits="WebApplication2.FanRegPage" %>

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
            <asp:TextBox ID= "fan_name" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Username"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "fan_username" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Password"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "fan_password" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="National ID"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "fan_nid" runat="server"></asp:TextBox>
        </div>
          <div>
             <asp:Label runat="server" Text="Phone number"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "fan_number" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Birth date"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "fan_birthdate" Text="yyyy-mm-dd" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Address"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "fan_address" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="fanRegister" runat="server" OnClick="FanRegister" Text="Register"></asp:Button>
        </div>
         <div>
            <asp:Label  ID="FanRegError" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
