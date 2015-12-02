<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="searchUsers.aspx.cs" Inherits="searchUsers" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="seachOneUser" runat="server">
        <!--a box so the the user can enter something about themselves -->
        <h3>Enter a username to search</h3>
        <asp:TextBox ID="searchBox" runat="server"></asp:TextBox>

        <!--the user`s username stored in Users table in database -->
        <asp:Label ID="userFoundLabel" runat="server" Text="is user founnd" Font-Size="Large" BackColor="#99FF66"></asp:Label>
        <br />

        <!--a button to send a message to the user whos profile was selected -->
        <asp:Button ID="btn_OneUser" Text="Search" OnClick="search_Click" runat="server"></asp:Button>
        <asp:Button ID="btn_allUSers" Text="All users" OnClick="allUSers_Click" runat="server"></asp:Button>

    </div>


    <div class="allUSers" id="seachAllUSers" runat="server">
        <%--<table class="table">--%>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <%--</table>--%>
    </div>



</asp:Content>
