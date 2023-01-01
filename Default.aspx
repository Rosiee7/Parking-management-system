<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ParkingManager._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>New User</h1>
            <div align="center">
                <table class="nav-justified" align="center" style="margin-right: 0px">
            <tr>
                <td style="width: 169px">Name</td>
                <td style="width: 92px">
                    <asp:TextBox ID="Name" runat="server" Width="92px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">License plate ID</td>
                <td style="width: 92px">
                    <asp:TextBox ID="Id" runat="server" Width="92px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">Phone</td>
                <td style="width: 92px">
                    <asp:TextBox ID="Phone" runat="server" Width="92px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">Ticket type</td>
                <td style="width: 92px">
                    <asp:DropDownList ID="Ticket" runat="server">
                        <asp:ListItem>VIP</asp:ListItem>
                        <asp:ListItem>Value</asp:ListItem>
                        <asp:ListItem>Regular</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">Type</td>
                <td style="width: 92px">
                    <asp:DropDownList ID="Type" runat="server">
                        <asp:ListItem>Motorcycle</asp:ListItem>
                        <asp:ListItem>Private</asp:ListItem>
                        <asp:ListItem>Crossover</asp:ListItem>
                        <asp:ListItem>SUV</asp:ListItem>
                        <asp:ListItem>Van</asp:ListItem>
                        <asp:ListItem>Truck</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">Height</td>
                <td style="width: 92px">
                    <asp:TextBox ID="Height" runat="server" Width="92px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">Width</td>
                <td style="width: 92px">
                    <asp:TextBox ID="Width" runat="server" Width="92px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 169px">Length</td>
                <td style="width: 92px">
                    <asp:TextBox ID="Length" runat="server" Width="92px"></asp:TextBox>
                </td>
                <td><asp:Button ID="add" runat="server" Text="ADD" Style=" margin-left: 13px; display:block;" OnClick="Button1_Click" /></td>
            </tr>
            </table>
               
               
                
            </div>



    </div>
</asp:Content>
