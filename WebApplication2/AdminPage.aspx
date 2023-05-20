<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplication2.SystemAdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Add club"></asp:Label> </div>
         <br />
        <div><asp:Label runat="server" Text="Name"></asp:Label></div>
        <div>
            <asp:TextBox ID= "Name" runat="server"></asp:TextBox>
        </div>
         <div><asp:Label runat="server" Text="Location"></asp:Label></div>
        <div>
            <asp:TextBox ID= "Location" runat="server"></asp:TextBox>
        </div>
         <div>
            <asp:Button ID="addClub" runat="server" OnClick="AddClub" Text="Add Club"></asp:Button> 
         </div>
        <div>
            <asp:Label ID="alreadyExists" ForeColor="Red" runat="server"></asp:Label>
        </div>
        <br />
        <br />
         <br />
        <div>
       <asp:Label runat="server" Text="Delete Club"></asp:Label>
    </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "DeleteName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="removeClub" runat="server" OnClick="RemoveClub" Text="Delete Club"></asp:Button> 
        </div>
        <div>
            <asp:Label  ID="ClubNotExist" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
         <br />
        <div>
       <asp:Label runat="server" Text="Add Stadium"></asp:Label>
    </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "StadiumName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Location"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "StadiumLocation" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Capacity"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "StadiumCapacity" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="addNewStad" runat="server" OnClick="AddNewStadium" Text="Add Stadium"></asp:Button> 
        </div>
        <div>
            <asp:Label  ID="DisplayErrorStad"  ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
          <br />
        <br />
         <br />
        <div>
       <asp:Label runat="server" Text="Delete Stadium"></asp:Label>
    </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Name"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "DeleteStadiumName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="deleteStadium" runat="server" OnClick="DeleteStadium" Text="Delete Stadium"></asp:Button> 
        </div>
        <div>
            <asp:Label  ID="StadiumErrorMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
         <br />
        <br />
         <br />
        <div>
       <asp:Label runat="server" Text="Block Fan"></asp:Label>
    </div>
        <br />
        <div>
            <asp:Label runat="server" Text="National ID"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID= "nID" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="blockFan" runat="server" OnClick="BlockFan" Text="Block"></asp:Button> 
        </div>
        <div>
            <asp:Label  ID="BlockFanDisplay" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
        <div><asp:Button ID="Button2834" runat="server" OnClick="BackToLog" Text="Log Out"></asp:Button></div>
    </form>
</body>
</html>
