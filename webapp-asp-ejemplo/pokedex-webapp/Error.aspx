<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="pokedex_webapp.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un prolema...</h1>
    <asp:Label ID="lblMensaje" Text="Label" runat="server" ></asp:Label>
    <% if (Session["usuario"] == null)%>
    <% { %> 
        <asp:LinkButton ID="btnIniciarSesion" CssClass="ms-2" OnClick="btnIniciarSesion_Click" runat="server">Iniciar Sesión</asp:LinkButton>
    <% } %>
</asp:Content>
