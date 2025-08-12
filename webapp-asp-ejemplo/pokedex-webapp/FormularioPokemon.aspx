<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedex_webapp.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mt-3 mb-3 ">
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id</label>
                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtNumero" class="form-label">Número</label>
                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="ddlTipo" class="form-label">Tipo</label>
                    <div>
                        <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="ddlDebilidad" class="form-label">Debilidad</label>
                    <div>
                        <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="pt-5 d-grid gap-2 d-md-flex justify-content-md-end">
                    <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary me-md-2" OnClick="btnAceptar_Click" runat="server" />
                    <asp:Button ID="btnModificar" Text="Modificar" CssClass="btn btn-primary me-md-2" OnClick="btnModificar_Click" runat="server" />
                    <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" runat="server" />
                </div>

                <div class=" mt-3 mb-3 d-grid gap-2 d-md-flex justify-content-md-end">
                    <a href="ListaPokemon.aspx">Cancelar</a>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
