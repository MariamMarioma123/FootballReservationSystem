<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="WebApplication2.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="choiceOfUser" Text="Who wants to register?"></asp:Label>
        </div>
        <br />
        <div>    
        <asp:Button runat="server" ID="regSAM" Width="175" OnClick="RegisterSAM" Text="Sport Association Manager"></asp:Button>
        </div>
        <br />
        <div>
         <asp:Button runat="server"  ID="clubRep" Width="175" OnClick="ClubRep" Text="Club Representative"></asp:Button>
        </div>
        <br />
        <div>
         <asp:Button runat="server" ID="stadiumMan" Width="175"  OnClick="StadiumManagerReg" Text="Stadium Manager"></asp:Button>
        </div>
        <br />
        <div>
         <asp:Button runat="server" ID="regFan" Width="175"  OnClick="RegFan" Text="Fan"></asp:Button>
        </div>
    </form>
</body>
</html>
