<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanPage.aspx.cs" Inherits="WebApplication2.FanPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:Label  id="fanUser" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
     <div>
            <asp:Label  ID="Label111" runat="server" Text="-Preview available matches: "></asp:Label> 
        </div>
           <br />
         <div>
            <asp:Label  ID="availableForPreview" runat="server" Text="Start time "></asp:Label> 
        </div>
        <div><asp:TextBox ID="timeMatchStart" runat="server"></asp:TextBox></div>
        <div><asp:Button ID="timeCheck" runat="server" OnClick="CheckTime" Text="Search"></asp:Button></div>
        <div>
            <asp:Label  ID="error1" ForeColor="Red" runat="server" Text=""></asp:Label> 
        </div><br />
        <div>
            <asp:Label  ID="searchRes" runat="server" Text="Search results: "></asp:Label> 
        </div>
        <div>
        <asp:GridView runat="server" ID="searchResu"></asp:GridView>
        </div>
        <div>
            <asp:Label  ID="nullCase" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
       <div>
            <asp:Label  ID="Label123" runat="server" Text="-Purchase ticket:  "></asp:Label> 
        </div>
        <br />
         <div>
            <asp:Label  ID="Label145" runat="server" Text="Host club name  "></asp:Label> 
        </div>
        <div><asp:TextBox ID="host_names" runat="server"></asp:TextBox></div>
        <div>
            <asp:Label  ID="Label44" runat="server" Text="Guest club name  "></asp:Label> 
        </div>
        <div><asp:TextBox ID="guest_names" runat="server"></asp:TextBox></div>
         <div>
            <asp:Label  ID="Label55" runat="server" Text="Start time"></asp:Label> 
        </div>
        <div><asp:TextBox ID="time_ss"  Text="yyyy-mm-dd hh:mm:ss" runat="server"></asp:TextBox></div>
         <div><asp:Button ID="Buttone" runat="server" OnClick="ReservePlace" Text="Purchase"></asp:Button></div>
        <div>
            <asp:Label  ID="purchaseStatus" ForeColor="Red" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <div><asp:Button ID="Button28" runat="server" OnClick="BackTo" Text="Log Out"></asp:Button></div>
    </form>
</body>
</html>
