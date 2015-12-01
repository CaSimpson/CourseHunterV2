<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="ReadMail.aspx.cs" Inherits="ReadMail" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="PanelConversation" runat="Server" ScrollBars="Auto">
        <asp:PlaceHolder ID="conversationLogPlaceHolder" runat="server"></asp:PlaceHolder>
    </asp:Panel>

    <div id="DivMessage" runat="server" visible="true">
        <!--a box to enter a message to send to the User-->
        <asp:TextBox ID="messageBox" runat="server" Width="617px" Height="183px" Columns="10" Rows="10" TextMode="MultiLine"></asp:TextBox>
         <br />
        <!--a button to send a message to the user whos profile was selected -->
        <asp:Button ID="btnSend" Text="Reply" OnClick="Send_Click" runat="server"></asp:Button>
    </div>



</asp:Content>