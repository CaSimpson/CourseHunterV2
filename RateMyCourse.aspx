<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="RateMyCourse.aspx.cs" Inherits="RateMyCourse" %>

<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <style type="text/css">
        .emptypng {
            background-image: url(/Images/ratingStarEmpty.png);
            width: 13px;
            height: 12px;
        }
        .smileypng {
            background-image: url(/Images/ratingStarFilled.png);
            width: 13px;
            height: 12px;
        }
        .donesmileypng {
            background-image: url(/Images/ratingStarSaved.png);
            width: 13px;
            height: 12px;
        }
</style>

<html>

<body>
    
    <table width="100%">
        <tr>
            <td align="right"> </td>
            <td align="left">
                <asp:Label ID="lblmessage" runat="server" style="color: #3366FF" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCourseDropBox" runat="server" AutoPostBack="True" Text="Please Select Course: "></asp:Label>
                <asp:DropDownList ID="courseDropBox" runat="server" OnSelectedIndexChanged="courseDropBox_SelectedIndexChanged" ></asp:DropDownList>

            </td>

        </tr>


        <tr>
            <td align="right">Rating
            </td>
            <td align="left">
                <ajaxToolkit:Rating ID="Rating1" runat="server" CurrentRating="0" MaxRating="5" 
                EmptyStarCssClass="emptypng" FilledStarCssClass="smileypng"
                 StarCssClass="smileypng" WaitingStarCssClass="donesmileypng"></ajaxToolkit:Rating>
                
            </td>
        </tr>

        <tr>
            <td align="right">Name
            </td>
            <td align="left">
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtName" ErrorMessage="Please enter name"
                    style="color: #FF0000"></asp:RequiredFieldValidator>
            </td>
            
            
        </tr>
        


        <tr>
            <td align="right">Comment
            </td>
            <td align="left">
                <asp:TextBox ID="txtComment" runat="server" Height="87px" TextMode="MultiLine"
                    Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtComment" ErrorMessage="Please enter some comment"
                    style="color: #FF0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                    onclick="btnSubmit_Click" />
                <asp:Button ID="Button2" CausesValidation="false" runat="server" Text="Update"
                    onClick="Button2_Click" />
                
            </td>
        </tr>
        <tr>
           



                     <td align="left" colspan="2">
                
                <asp:GridView ID="gdvUserComment" runat="server" AutoGenerateColumns="False"
                    ShowHeader="False" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table width="100%">
                                <tr>
                                <td align="left" style="width:20%"><b>Name :</b> <%#Eval("Name")%></td>
                                </tr>
                                <tr>
                                <td>
                                    
                                        <ItemTemplate>
                                            
                                <ContentTemplate>
                               <ajaxToolkit:Rating ID="RatingDone" runat="server" CurrentRating='<%#Eval("Rating")%>' ReadOnly="true" MinRating="0" MaxRating="5" 
                                 EmptyStarCssClass="emptypng" FilledStarCssClass="smileypng"
                                  StarCssClass="smileypng" WaitingStarCssClass="donesmileypng"></ajaxToolkit:Rating>
                                    </ContentTemplate>
                                               
                                            </ItemTemplate>
                                       

                                </td>
                                </tr>
                                <tr>
                                <td colspan="2"><%#Eval("Comment")%></td>
                                </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


            </td>
        </tr>
    </table>
    <br />
    
</body>
</html>
    </asp:Content>