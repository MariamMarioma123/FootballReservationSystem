<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentativePage.aspx.cs" Inherits="WebApplication2.ClubRepresentativePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div> <asp:Label  ID="clubRepresented" runat="server" Text="- Information of club : "></asp:Label> </div>
        <div>
        <asp:GridView runat="server" ID="ClubRepresentedGrid"></asp:GridView>
        </div>
         <div>
            <asp:Label  ID="NoClub" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
        <div> <asp:Label  ID="upcomingMatchesForClub" runat="server" Text="-All upcoming matches for your club: "></asp:Label> </div>
        <div>
        <asp:GridView runat="server" ID="upComingClubMatches"></asp:GridView>
        </div>
         <div>
            <asp:Label  ID="noMatchesClub" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
        <div> <asp:Label  ID="availableStad" runat="server" Text="-Time you want available stadiums: "></asp:Label> </div>
        <div>
           <input type="datetime" id="time" name="time" />
        </div>
         <div> <asp:Button ID="timeStad" runat="server" OnClick="TimeStad" Text="Search"></asp:Button> </div>
        <div>
            <asp:Label  ID="searchResults" runat="server" Text="Available stadiums: "></asp:Label> 
        </div>
        <div>
        <asp:GridView runat="server" ID="AllAvailableFinds"></asp:GridView>
        </div>
         <div>
            <asp:Label  ID="noStad" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
        <div> <asp:Label  ID="requestsLabel" runat="server" Text="-Request stadium manager to host match: "></asp:Label> </div>
     <br />
        <div>
            <asp:Label  ID="newLabel" runat="server" Text="Stadium Name"></asp:Label> 
        </div>
        <div>
            <asp:TextBox ID= "stadiumName" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label  ID="startTime2" runat="server" Text="Requested Time"></asp:Label> 
        </div>
        <div>
           <asp:TextBox ID= "timeBox" runat="server"></asp:TextBox>
        </div>
        
         <div> <asp:Button ID="Button23" runat="server" OnClick="RequestSM" Text="Request" ></asp:Button> </div>
         <div>
            <asp:Label  ID="ErrorMsgDisplay" ForeColor="Red" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <div><asp:Button ID="Button283" runat="server" OnClick="BackToLo" Text="Log Out"></asp:Button></div>
    </form>
</body>
</html>
