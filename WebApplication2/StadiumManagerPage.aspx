<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManagerPage.aspx.cs" Inherits="WebApplication2.StadiumManagerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label  ID="Labelxxx" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
         <div>
            <asp:Label  ID="Label200" runat="server" Text="-Stadium you're managing:"></asp:Label> 
        </div>
        <div>
        <asp:GridView runat="server" ID="StadiumManaged"></asp:GridView>
        </div>
        <br />
        <br />
        <br />
         <div>
            <asp:Label  ID="label2000" runat="server" Text="-Requests:"></asp:Label> 
        </div>
        <div>
        <asp:GridView runat="server" ID="RequestTable"></asp:GridView>
        </div>
        <div>
            <asp:Label  ID="noRequests" runat="server" Text=""></asp:Label> 
        </div>
        <br />
        <br />
        <br />
         <div>
            <asp:Label  ID="Label2345" runat="server" Text="-Enter details of request to handle: "></asp:Label> 
        </div>
        <br />
         <div>
            <asp:Label  ID="Label234" runat="server" Text="Host Club Name"></asp:Label> 
        </div>
        <div>
            <asp:TextBox ID= "hostcName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label  ID="label2032" runat="server" Text="Guest Club Name "></asp:Label> 
        </div>
        <div>
           <asp:TextBox ID= "guestcName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label  ID="startTimeReq" runat="server" Text="Start Time  "></asp:Label> 
        </div>
        <div>
           <asp:TextBox  ID= "matchTime" runat="server"></asp:TextBox>
        </div>
         <div> <asp:Button ID="acceptRequest2" runat="server" OnClick="AcceptRequest2" Text="Accept" ></asp:Button> <asp:Button ID="rejRequest2" runat="server" OnClick="RejectRequest2" Text="Reject" ></asp:Button></div>
         <div>
            <asp:Label  ID="ErrorMsgDisplay2" ForeColor="Red" runat="server" Text=""></asp:Label> 
        </div>
          <br />
        <br />
        <div><asp:Button ID="Button283486" runat="server" OnClick="BackTologin" Text="Log Out"></asp:Button></div>
    </form>
</body>
</html>
