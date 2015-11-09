<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link href="Content/bootstrap.css" rel="stylesheet" />



    <div class="col-md-6">

        <h1 class="bg-success text-center">"Good planning is good for Graduation"</h1>

    <ol class="round">
        <li class="one">
            <asp:Label ID="lblVerify" runat="server" Text="Label" Visible="False">User Verified</asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            <h4>What our team is trying to accomplish</h4>
            This project will be a web application that helps a student keep track of their academic progress  
            and creates a list of classes a student can choose from and register for that current semester.
        </li>
        <li class="two">
            <h4>Benefits</h4>
            The benefits of our application will make it easier for a both faculty(advisors specificly) 
            and students to see what classes are needed to continue toward a particular major. 
        </li>
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>
    </ol>

    </div>

    <div class="col-md-6">
        <img src="Images/Front_Catalog_Howle.png" style="width: 90%; height: 90%"/>
    </div>
        
</asp:Content>