<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_webapp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Página Principal [Home]</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%-- <% foreach (dominio.Pokemon poke in ListaPokemon)
            {
        %>
            <div class="col">
                <div class="card">
                    <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: poke.Nombre %></h5>
                        <p class="card-text"><%: poke.Descripcion %></p>
                        <a href="DetallePokemon.aspx?Id=<%: poke.Id %>">Ver detalle</a>
                    </div>
                </div>
            </div>
        <%  
            }
        %>--%>

        <% //Con repeater %>
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <a href="DetallePokemon.aspx?Id=<%# Eval("Id") %>">Ver detalle</a>
                            <asp:Button ID="btnEjemplo" Text="Ejemplo" CssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' CommandName="pokemonId" OnClick="btnEjemplo_Click" runat="server"  />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
