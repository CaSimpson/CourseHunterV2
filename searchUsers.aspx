<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeFile="searchUsers.aspx.cs" Inherits="searchUsers" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    
     <div class="allUSers" id="seachAllUSers" runat="server">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
     </div>


    <div class="container-fluid">
        <div class="row">

            <div class="col-md-8">
                <h2>Enter a username to search</h2>
                <asp:TextBox ID="searchBox" runat="server" ></asp:TextBox>
                 <asp:Label ID="userFoundLabel" runat="server" Text="is user founnd" Font-Size="Large" BackColor="#99FF66"></asp:Label>
                <asp:Button id="btn_OneUser" class="btn btn-default" Text="Search" OnClick="search_Click" runat="server"> </asp:Button>
             <asp:Button id="btn_allUSers" class="btn btn-default" Text="All users" OnClick="allUSers_Click" runat="server"> </asp:Button>

            </div>

            <div class="col-md-4">.col-md-4</div>

        </div>
    </div>



</asp:Content>