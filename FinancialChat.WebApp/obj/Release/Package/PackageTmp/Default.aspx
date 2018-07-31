<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webapp1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>
            <asp:Label ID="Label1" runat="server" Text=" User: "></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            &nbsp;&nbsp;</p>
        <p>
            Password:
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LabelResult" runat="server" ForeColor="Red" Text=""></asp:Label>
        </p>
        <p>
            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log In" />
        </p>
        <p>
            <a runat="server" href="~/Pages/Signup">Create Profile</a>
        </p>
    </div>

    <div class="row">
    </div>

</asp:Content>
