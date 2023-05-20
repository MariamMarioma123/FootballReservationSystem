<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SportsAssociationManagerPage.aspx.cs" Inherits="WebApplication2.SportsAssociationManagerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label runat="server" ID="usernameSAM" Text=""></asp:Label>
        </div>
        <br />
         <div>
             <asp:Label runat="server" Text="Add or Delete a Match "></asp:Label>
        </div>
        <br />
         <div>
             <asp:Label runat="server" Text="Host Club Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "host_name" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Guest Club Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "guest_name" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="Start time"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "start_time" Text="yyyy-mm-dd hh:mm:ss" runat="server"></asp:TextBox>
        </div>
        <div>
             <asp:Label runat="server" Text="End time"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="end_time" Text="yyyy-mm-dd hh:mm:ss" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="add_match" runat="server" OnClick="AddMatch" Text="Add match"></asp:Button><asp:Button ID="deleteMatch" runat="server" OnClick="DeleteMatch" Text="Delete Match"></asp:Button>
        </div>
         <div>
            <asp:Label  ID="addMatchError" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:Label  ID="Grid" runat="server" Text="Upcoming Matches: "></asp:Label> 
        </div>
        <div>
        <asp:GridView runat="server" ID="upcomingMatches"></asp:GridView>
        </div>
         <div>
            <asp:Label  ID="None" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
        <div> <asp:Label  ID="Grid2" runat="server" Text="Already Played Matches: "></asp:Label> </div>
        <div>
        <asp:GridView runat="server" ID="alreadyPlayed"></asp:GridView>
        </div>
         <div>
            <asp:Label  ID="None2" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
        <div> <asp:Label  ID="Never" runat="server" Text="Pair of clubs who never played against each other: "></asp:Label> </div>
        <div>
        <asp:GridView runat="server" ID="NeverClubs"></asp:GridView>
        </div>
         <div>
            <asp:Label  ID="neverClubs2" runat="server" Text=""></asp:Label> 
        </div>
          <br />
        <br />
        <div><asp:Button ID="Button28347" runat="server" OnClick="BackToLogi" Text="Log Out"></asp:Button></div>

    </form>
</body>
</html>
