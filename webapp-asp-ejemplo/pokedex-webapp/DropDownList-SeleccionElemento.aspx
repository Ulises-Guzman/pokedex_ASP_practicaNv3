<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DropDownList-SeleccionElemento.aspx.cs" Inherits="pokedex_webapp.DropDownList_SeleccionElemento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h4>Selección de Elemento</h4>
    <div class="mb-3 row">
        <asp:Label Text="ID" CssClass="col-sm-1 col-form-label" runat="server" />
        <div class="col-sm-5">
            <asp:TextBox ID="txtIdTipo" CssClass="form-control" runat="server" />
        </div>
        <div class="col">
            <asp:Label Text="Tipo Preseleccionado" class="form-label" runat="server" />
            <asp:DropDownList ID="ddlTipoPreseleccionado" CssClass="btn btn-outline-dark dropdown-toogle" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="mb-3 row">
        <div class="col">
            <asp:Button ID="btnSelecionar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnSelecionar_Click" runat="server" />
        </div>
    </div>
    <hr />

    <hr />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mb-3 row">
                <div class="col">
                    <asp:TextBox ID="txtUrlImagen" CssClass="form-control" runat="server" />
                    <%--<%--AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />--%>
                </div>

                <div class="col">
                    <asp:Button ID="btnCargar" Text="Cargar" CssClass="btn btn-primary" OnClick="btnCargar_Click" runat="server" />
                </div>
            </div>

            <div class="mb-3 row">
                <div class="col">
                    <img src="<% = urlImagen %>" alt="Alternate Text" with="25%" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
</asp:Content>
