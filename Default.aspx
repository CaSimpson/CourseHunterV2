<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link href="Content/bootstrap.css" rel="stylesheet" />



    <div class="col-md-6">

        <h1 class="bg-success text-center">"Good planning is good for Graduation"</h1>
        <p class="text-right"> --Daniel Dingana(co-founder)</p>
        

    <ul class="lg-round">
        <li class="one">
            <asp:Label ID="lblVerify" runat="server" Text="Label" Visible="False">User Verified</asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            <h4>What our web application is trying to accomplish</h4>
            This project will be a web application that helps a student keep track of their academic progress  
            and creates a list of classes a student can choose from and register for that current semester.
        </li>
        <li class="two">
            <h4>Benefits this application</h4>
            The benefits of our application will make it easier for a both faculty(advisors specificly) 
            and students to see what classes are needed to continue toward a particular major.
             <mark>THIS SOFTWARE SHOULD ONLY BE A GUIDELINE.</mark> This software is just a tool to help. Please speak with
            your advisor before makeing any final decisions. 
        </li>
        <li class="three">
            <h4>Keep track of your progress</h4>
            Very often students try to sign up for classes that require prerequisites that the student does not meet.  
            The software will inform the student and not show the student those classes. 
             As a result the software will also help you avoid taking unnecessary classes and increase chance of graduating on-time.
        </li>
    </ul>

    </div>

    <div class="col-md-6">
        <img src="Images/Front_Catalog_Howle.png" alt="Course Catalog" class="img-rounded" style="width: 90%; height: 90%">
    </div>
        
</asp:Content>