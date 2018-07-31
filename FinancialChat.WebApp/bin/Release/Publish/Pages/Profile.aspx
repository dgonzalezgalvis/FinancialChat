<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="webapp1.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Edit Profile</h3>
    <p>Username:<asp:TextBox ID="TextBoxUsername" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p>First Name:<asp:TextBox ID="TextBoxFirstname" runat="server"></asp:TextBox>
    </p>
    <p>Last Name:<asp:TextBox ID="TextBoxLastname" runat="server"></asp:TextBox>
    </p>
    <p>Password:<asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>Validate Password:
        <asp:TextBox ID="TextBoxPassword2" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    </p>
    <p>
        <h3>Chat History</h3>
    <asp:ListBox ID="ListBox1" runat="server" Enabled="False" Height="162px" Width="718px"></asp:ListBox>
    </p>

</asp:Content>
