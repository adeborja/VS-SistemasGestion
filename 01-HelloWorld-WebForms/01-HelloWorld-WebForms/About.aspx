<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="_01_HelloWorld_WebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p>
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>    </p>
    <p>
        <asp:TextBox ID="TxbxNombre" runat="server"></asp:TextBox></p>
    <p>
        <asp:Button ID="btnSaludar" runat="server" Text="Saludar" OnClick="btnSaludar_Click" /></p>
    <p>
        <asp:Label ID="LblTextoVacio" runat="server" Text=""></asp:Label></p>
    <p>
        <asp:Button ID="btnSaludarClase" runat="server" Text="Saludar Clase" OnClick="btnSaludarClase_Click" /></p>
</asp:Content>
