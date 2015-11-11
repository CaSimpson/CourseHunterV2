<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Progress.aspx.cs" Inherits="Progress" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent"> 

    <br />
    <br />
    <br />
    <br />
    <br />


   
    <section class="featured">
        <div class="content-wrapper">
            
               
                <h1 style="margin-left:auto; margin-right:auto; text-align: center;">
                    <asp:Label ID="lblStudentName" runat="server" Text=""></asp:Label></h1>
            <br />    

                <h2 style="margin-left:auto; margin-right:auto; text-align: center;">Overall Progress</h2>
                
                    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
                    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
                    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
                
                     <div id="progressbar" style="width:75%; margin:0 auto;"></div>   
                 
                  
                      <script type="text/jscript">
                          var myProg;
                          myProg = <%=myProg%>;
                         jQuery(document).ready(function () {
                             jQuery("#progressbar").progressbar({ value: myProg }).append("<div class='caption'>20%</div>");
                             jQuery("#progressbar").css({ 'background': 'url(images/white-40x100.png) #ffffff repeat-x 50% 50%;' });
                             jQuery("#pbar1 > div").css({ 'background': 'url(images/lime-1x100.png) #cccccc repeat-x 50% 50%;' });
                         });
                        </script>     
                        
           
            
            
            <br />
            <br />

            
            <p style="margin-left:auto; margin-right:auto; text-align: center;">
                                
                
           

            </p>
            
            <table style="width: 75%;">
                <tr>
                    <td rowspan="6" align="center">&nbsp;
                        <h3 style="margin-left:auto; margin-right:auto; text-align: center;">
                Courses Complete
                
            </h3>
                        <asp:ListBox ID="completeListBox" runat="server"></asp:ListBox>
                    </td>
                    <td>&nbsp;Courses</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Complete:</td>
                    <td>&nbsp;<asp:Label ID="lblCourseComplete" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Remaining:</td>
                    <td>&nbsp;<asp:Label ID="lblCourseRemaining" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Credits</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Complete:</td>
                    <td>&nbsp;<asp:Label ID="lblCreditComplete" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Remaining</td>
                    <td>&nbsp;<asp:Label ID="lblCreditRemaining" runat="server" Text=""></asp:Label></td>
                </tr>
                </table>

        </div>
    </section>
    

    </asp:Content>