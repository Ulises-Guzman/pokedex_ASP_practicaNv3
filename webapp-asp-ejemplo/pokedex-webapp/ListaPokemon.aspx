<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="pokedex_webapp.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
        <h1>Lista de Pokemon's</h1>
    </div>
    <div class="row">
        <div class="col">
            <asp:GridView
             ID="gvPokemon" 
             CssClass="table table-striped table-hover" 
             AutoGenerateColumns="false" 
             DataKeyNames="Id"
             OnSelectedIndexChanged="gvPokemon_SelectedIndexChanged"
             OnPageIndexChanging="gvPokemon_PageIndexChanging"
             AllowPaging="true" PageSize="5"
             runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Tipo" Datafield="Tipo.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="btnAgregar" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
        </div>
    </div>
</asp:Content>
