<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="pokedex_webapp.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
        <h1>Lista de Pokemon's</h1>
    </div>
    <div class="row">
        <div class="col">
            <asp:GridView ID="gvPokemon" CssClass="table table-striped table-hover" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                </Columns>    
            </asp:GridView>
        </div>
    </div>
</asp:Content>
