<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepRegPage.aspx.cs" Inherits="WebApplication2.ClubRepRegPage" %>

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
            <asp:TextBox ID= "Rep_name" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Username"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "Rep_username" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Password"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "Rep_password" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Club Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "Rep_clubName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="clubRepReg" runat="server" OnClick="ClubRepReg" Text="Register"></asp:Button>
        </div>
         <div>
            <asp:Label  ID="RepRegError" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
