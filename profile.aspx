<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

        <div>
            Select Image:<asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?UserId=" + Eval("UserId") %>' Height="150px" Width="150px" />

          
            <asp:Label ID="Label2" runat="server" Text="label"></asp:Label> 
        </div>  
            <br />  
           <!--the user`s username stored in Users table in database -->
            <h3>username:</h3> <asp:Label ID="usernameLabel" runat="server" Text="username" Font-Size="Large" BackColor="#99FF66"></asp:Label>
            <!--the actual name of the user stored in the student table -->
           <h3>Full Name:</h3><asp:Label ID="studentNameLabel" runat="server" Text="name" BackColor="#99FF66" Font-Size="Large"></asp:Label>
            <br />
            <!--a box so the the user can enter a new name if they wish to change -->
            <asp:TextBox ID="actualNameBox" runat="server"  Width="290px" Text=""></asp:TextBox>
            <br />
            <!--the user`s major stored in major table in the database -->
            <h3>major:</h3> <asp:Label ID="majorNameLabel" runat="server" Text="major" BackColor="#99FF66" Font-Size="Large"></asp:Label>
             <br />
            <!-- a dropdown menu of all majors stored in the major stable in the database-->
            <asp:DropDownList  ID="majorsDropDown" runat="server" > </asp:DropDownList>
            <br />
            <br />
             <!--a box so the user can enter something about themselves -->
             <h3>A little about you:</h3><asp:TextBox ID="aboutMeBox" runat="server" Text="something about you" Width="617px" Height="183px" Columns="10" Rows="5" TextMode="MultiLine" MaxLength="300"></asp:TextBox>
            <br />
            <br />

            <!--a button to retrive data entered and store in database -->            
            <asp:Button id="btnUpdate" Text="Update profile" OnClick="Update_Click" runat="server"> </asp:Button>      




</asp:Content>