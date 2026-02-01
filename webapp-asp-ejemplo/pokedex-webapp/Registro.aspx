<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="pokedex_webapp.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Crea tu perfil trainee</h1>
    <hr />
    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-4">
            <div class="mt-3 mb-3">
                <label for="txtEmail" class="form-label">Dirección Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" PlaceHolder="ejemplo@ejemplo.com" aria-describedby="emailHelp" runat="server"></asp:TextBox>
                <div id="emailHelp" class="form-text">Nunca compartiremos su correo electrónico.</div>
            </div>
            <div class="mb-4">
                <label for="txtContrasena" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" Text="Registrar" runat="server" />
            <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Text="Cancelar" runat="server" />
        </div>
        <div class="col-lg-4"></div>
    </div>
</asp:Content>
