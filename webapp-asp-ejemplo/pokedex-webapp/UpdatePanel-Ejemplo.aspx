<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePanel-Ejemplo.aspx.cs" Inherits="pokedex_webapp.UpdatePanel_Ejemplo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Pagina con UpdatePanel -->
    <%-- Requerido para UpdatePanel--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <hr />

    <div class="mb-3">
        <h3>UpdatePanel</h3>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label Text="text" ID="lblNombre" runat="server" />
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtNombre" CssClass="form-control" OnTextChanged="txtNombre_TextChanged" AutoPostBack="true" runat="server" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="form-control" OnClick="btnAceptar_Click" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
</asp:Content>
