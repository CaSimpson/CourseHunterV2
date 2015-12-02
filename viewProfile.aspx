<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeFile="viewProfile.aspx.cs" Inherits="viewProfile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <!--the user`s username stored in Users table in database -->
        <h3>username:</h3>
        <asp:Label ID="usernameLabel" runat="server" Text="username" Font-Size="Large" BackColor="#99FF66"></asp:Label>
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?UserId=" + Eval("UserId") %>' Height="150px" Width="150px" />
        <br />
        <!--the actual name of the user stored in the student table -->
        <h3>Name:</h3>
        <asp:Label ID="studentNameLabel" runat="server" Text="name" BackColor="#99FF66" Font-Size="Large"></asp:Label>
        
        <br />
        <!--the user`s major stored in major table in the database -->
        <h3>major:</h3>
        <asp:Label ID="majorNameLabel" runat="server" Text="major" BackColor="#99FF66" Font-Size="Large"></asp:Label>
        <br />
        <h3>My self-summary</h3>
        <asp:TextBox ID="summaryLabelBox" runat="server" Text="about you" Width="617px"
            TextMode="MultiLine" ReadOnly="True" BackColor="#99FF66"></asp:TextBox>
        <br />
        <asp:Button ID="btnSendMessage" Text="Message" OnClick="Message_Click" runat="server"></asp:Button>
        <asp:Button ID="btnAddFriend" Text="Add Friend" OnClick="addFriend_Click" runat="server"></asp:Button>
        

        <div id="DivMessage" runat="server" visible="false">
            <!--a box to enter a message to send to the User-->
            <h3 id="messageh3" runat="server" text="Message"></h3>
            <asp:TextBox ID="messageBox" runat="server" Width="617px" Height="183px" Columns="10" Rows="10" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="btnCancel" Text="Cancel" OnClick="Cancel_Click" runat="server"></asp:Button>
            <!--a button to send a message to the user whos profile was selected -->
            <asp:Button ID="btnSend" Text="Send" OnClick="Send_Click" runat="server"></asp:Button>
        </div>

    </div>




</asp:Content>