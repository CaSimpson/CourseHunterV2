<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Results.aspx.cs" Inherits="Results" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                
            </hgroup>
            <p>
                
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="appBody" ContentPlaceHolderID="MainContent">

    <p>
    </p>
    <p>
        <br />
        <br />
        <asp:Label ID="reclbl" runat="server" Text="Label">Recommended Courses</asp:Label>
        &nbsp&nbsp&nbsp&nbsp
       <asp:Label ID="poslbl" runat="server" Text="Label">All Possible Courses</asp:Label>
        
        
        
    </p>
    <p>
        <asp:Label ID="rec1" runat="server" Text="Label"></asp:Label>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:ListBox ID="allPosListBox" runat="server"></asp:ListBox><asp:ListBox ID="testList" runat="server"></asp:ListBox>
    </p>
    <p>
        <asp:Label ID="rec2" runat="server" Text="Label1"></asp:Label>
    </p>
    <p>
        <asp:Label ID="rec3" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="rec4" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="rec5" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        
        


        
    </p>

  
         


    </asp:Content>
    
