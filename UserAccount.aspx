<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="UserAccount.aspx.cs" Inherits="UserAccount" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent"> 

    <link href="Content/bootstrap.css" rel="stylesheet" />

    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                
                <h2>User Account Page : Click a button to manage account</h2>
            </hgroup>
            <p>
                <asp:Button ID="btnAddCourse" runat="server" Text="Add / Remove Courses" OnClick="btnAddCourse_Click" CssClass =" btn btn-success" />
                <asp:Button ID="btnStatus" runat="server" Text="Status / Progress page" OnClick="btnStatus_Click" CssClass =" btn btn-success"/>
                <asp:Button ID="btnShowRecommended" runat="server" Text="Recommended / Possible courses" OnClick="btnShowRecommended_Click" CssClass =" btn btn-success"/>
            </p>
        </div>
    </section>
  

    </asp:Content>
