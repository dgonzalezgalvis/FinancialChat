<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="webapp1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Chat</h3>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Timer id="Timer2" runat="server"
                  Interval="1000" 
                  OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:ListBox ID="ListBox1" runat="server" Height="182px" Width="856px" Font-Italic="True" Font-Size="Small" Rows="20" AppendDataBoundItems="True"></asp:ListBox>
                <div id="mydiv" runat="server"></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    <p>
        <asp:TextBox ID="TextBoxMessage" runat="server" Height="20px" Width="742px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Height="23px" OnClick="SendMessage" Text="Enviar" Width="102px" />
    </p>
    <asp:Timer ID="Timer1" runat="server"></asp:Timer>

</asp:Content>
