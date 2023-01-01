<%@ Page Title="Check In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="ParkingManager.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="jumbotron">
        <h1>Check In</h1>
        <table style='font-size:90%; width: 502px; height: 95px; margin-left: 0px; text-align: center;'>
            <tr>
                <td class="modal-sm" style="width: 215px; height: 57px;">Enter License plate ID:</td>
                <td style="height: 57px; width: 200px;">
                    <asp:TextBox ID="IdTextBox" runat="server" style="margin-right: 50%"></asp:TextBox>
                    
                </td>
                <td>
                    
                <asp:Button ID="Button1" runat="server" Text="Enter"  Style="margin-right:30%; display:inline-flex;" OnClick="Button1_Click1" Height="23px" />

                </td>
            </tr>
            </table>

        <br />
        
        <asp:GridView ID="GridView1" runat="server" style="margin-left: 133px" Width="369px">
        </asp:GridView>

        
        </div>

</asp:Content>
