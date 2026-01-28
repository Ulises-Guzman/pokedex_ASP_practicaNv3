<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="pokedex_webapp.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Menu Login</h1>
    <hr />
    <div class="row">
        <div class="col-12 mb-3">
            <label>Te logueaste correctamente</label>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Button ID="btnPagina1" CssClass="btn btn-primary" Text="Pagina 1" OnClick="btnPagina1_Click" runat="server" />
        </div>
        <div class="col-4">
            <!-- Este bloque tengo que factorizar en una funcion -->
            <%if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN) %>
            <% { %>
                <asp:Button ID="btnPagina2" CssClass="btn btn-secondary" Text="Pagina 2" OnClick="btnPagina2_Click" runat="server" />
                <p>Se requiere ser Admin..</p>
            <% } %>
        </div>
    </div>
</asp:Content>
