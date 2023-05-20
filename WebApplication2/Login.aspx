<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server"  Text="Please Login"></asp:Label>  
        </div>
      <br />
       <div>
             <asp:Label runat="server" Text="Username"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "username" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Password"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="signin" runat="server" OnClick="Login2" Text="Login"></asp:Button> <asp:Button ID="registerat" runat="server" OnClick="Register" Text="Register"></asp:Button>
        </div>
        <div>
            <asp:Label ID="errorMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
       
    </form>
</body>
</html>
