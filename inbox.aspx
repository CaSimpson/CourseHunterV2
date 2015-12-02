<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="inbox.aspx.cs" Inherits="inbox" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<div ID="divInInbox">
    <h3>Inbox</h3>

   <asp:Label ID="DoYouHaveMessages" runat="server" Text="" Font-Size="Large" BackColor="#99FF66" Visible="False"></asp:Label>

    <table ID="tableInInbox">       
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <tr>
                    <td>
                        <strong>Sender</strong>
                    </td>
                    <td>
                        <strong>Message</strong>
                    </td>
                    <td>
                        <strong>Date</strong>
                    </td>
                    <td>
                        <strong>Read/Unread</strong>
                    </td>
                </tr>
            </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td>
            <asp:Label ID="lblSender" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.UserName")%>'></asp:Label>
        </td>
        <td >
            <asp:HyperLink ID="hprSubject" runat="server"  NavigateUrl='<%#DataBinder.Eval(Container, "DataItem.MessageID", "ReadMail.aspx?id={0}")%>'><%#DataBinder.Eval(Container,"DataItem.body")%></asp:HyperLink>
        </td>
        <td >
            <asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.datentime")%>'></asp:Label>
        </td>
        <td>
        <strong><asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.status")%>'></asp:Label></strong>
        </td>
        </tr>
        </ItemTemplate>      
       
        
        </asp:Repeater>
    </table>
</div>
</asp:Content>

