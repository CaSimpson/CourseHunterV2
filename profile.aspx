<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <br />
    <br />
    <br />

        <div>
           <!--the user`s username stored in Users table in database -->
            username:<br /> <asp:Label ID="usernameLabel" runat="server" Text="username"></asp:Label>

           <!--a box so the the user can enter a new username if they wish to change -->
            <asp:TextBox ID="boxEnterUsername" runat="server"  Width="256px"></asp:TextBox>
            <br />
            <br />
            <!--the actual name of the user stored in the student table -->
            Name:<br /> <asp:Label ID="studentNameLabel" runat="server" Text="name"></asp:Label>

            <!--a box so the the user can enter a new name of they wish to change -->
            <asp:TextBox ID="txtName" runat="server"  Width="290px" Text="txtName"></asp:TextBox>
            <br />
            <br />
            <!--the user`s major stored in major table in the database -->
            major:<br /> <asp:Label ID="majorNameLabel" runat="server" Text="major"></asp:Label>

            <!-- a dropdown menu of all majors stored in the major stable in the database-->
            <asp:DropDownList  ID="majorsDropDown" runat="server" >   
                <Items>
                   <asp:ListItem Text="Select major" Value="" />

                </Items>
            </asp:DropDownList>
            <br />
            <br />
            <br />
                 <!--the user`s major stored in major table in the database -->
            selected value:<br /> <asp:Label ID="selValue" runat="server" Text="selected value"></asp:Label>
            <br />
            <br />
          
             <!--a box so the the user can something about themselves -->
            A little about you:<br /><asp:TextBox ID="boxAboutYourselve" runat="server"  Width="617px" Height="34px"></asp:TextBox>
            <br />
            <br />

            <!--a button to retrive data entered and store in database -->            
            <asp:Button id="Button1" Text="Update profile" OnClick="Update_Click" runat="server"> </asp:Button>


        </div>




</asp:Content>