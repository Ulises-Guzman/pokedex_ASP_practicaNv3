<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EnvioEmail.aspx.cs" Inherits="pokedex_webapp.EnvioEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="mt-3">
                <h1>Enviar Email</h1>
                <hr />
            </div>
            <div class="mt-5 mb-3">
                <label for="txtEmail" class="form-label">Dirección Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="nombre@ejemplo.com" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Asunto</label>
                <asp:TextBox ID="txtAsunto" CssClass="form-control" placeholder="Asunto..." runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtMensaje" class="form-label">Mensaje</label>
                <asp:TextBox ID="txtMensaje" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnEnviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" runat="server" Text="Enviar" />
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
