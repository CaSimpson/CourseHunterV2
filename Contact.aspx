<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">    
        <div class="jumbotron">
            <h1><%: Title %>.</h1>
            <h2>If you are having toruble with our site please feel free to contact any of the developers.</p>
            <p>You can see the contact information and bio for each developer below.</p>
        </div>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-4">
            <div class="well">
                <img class="img-circle center-block" src="Images/reid.jpg" width="140" height="140">
                <h2 class="text-center">Reid Mewborne</h2>
                <h4 class="text-center">Placeholder text: Bio</h4>
                <p class="text-center"><a href="mailto:mewborne@email.uscupstate.edu">mewborne@email.uscupstate.edu</a></p>
            </div>
        </div>

        <div class="col-md-4">
            <div class="well">
                <img class="img-circle center-block" src="Images/john.jpg" alt="Generic placeholder image" width="140" height="140">
                <h2 class="text-center">John Evans</h2>
                <h4 class="text-center">Placeholder text: Bio</h4>
                <p class="text-center"><a href="mailto:mewborne@email.uscupstate.edu">mewborne@email.uscupstate.edu</a></p>
            </div>
        </div>

        <div class="col-md-4">
            <div class="well">
                <img class="img-circle center-block" src="Images/daniel.jpg" alt="Generic placeholder image" width="140" height="140">
                <h2 class="text-center">Daniel Dingana</h2>
                <h4 class="text-center">Placeholder text: Bio</h4>
                <p class="text-center"><a href="mailto:mewborne@email.uscupstate.edu">mewborne@email.uscupstate.edu</a></p>
            </div>
        </div>

        <div class="col-md-6">
            <div class="well">
                <img class="img-circle center-block" src="Images/trey.jpg" alt="Generic placeholder image" width="140" height="140">
                <h2 class="text-center">Trey Howle</h2>
                <h4 class="text-center">Placeholder text: Bio</h4>
                <p class="text-center"><a href="mailto:howleg@email.uscupstate.edu">mewborne@email.uscupstate.edu</a></p>
            </div>
        </div>

        <div class="col-md-6">
            <div class="well">
                <img class="img-circle center-block" src="Images/corey.jpg" alt="Generic placeholder image" width="140" height="140">
                <h2 class="text-center">Corey Simpson</h2>
                <h4 class="text-center">Placeholder text: Bio</h4>
                <p class="text-center"><a href="mailto:mewborne@email.uscupstate.edu">mewborne@email.uscupstate.edu</a></p>
            </div>
        </div>
        <div class="hidden">
        <p>
            <span class="label">Game if your bored</span>
            <span>A spelling/animal identification game!</span>

            
            <object width="550" height="500">
                <param name="movie" value="hiddenpicture2.swf">
                <embed src="hiddenpicture2.swf" width="550" height="500">
                </embed>
            </object
        </p>
        </div>
    </div>
</asp:Content>

