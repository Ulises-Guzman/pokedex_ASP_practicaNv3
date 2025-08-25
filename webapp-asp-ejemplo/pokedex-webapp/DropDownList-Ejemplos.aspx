<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DropDownList-Ejemplos.aspx.cs" Inherits="pokedex_webapp.DropDownList_Ejemplos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <hr />
                <h4>DropDownList Estático</h4>
                <label for="ddlTipo1" class="form-label">Tipo</label>
                <div>
                    <asp:DropDownList ID="ddlTipo1" CssClass="form-select" runat="server">
                        <asp:ListItem Text="Planta" />
                        <asp:ListItem Text="Fuego" />
                        <asp:ListItem Text="Agua" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="mb-3">
                <label for="ddlTipo2" class="form-label">Tipo</label>
                <div>
                    <asp:DropDownList ID="ddlTipo2" CssClass="btn btn-outline-dark dropdown-toogle" runat="server">
                        <asp:ListItem Text="Planta" />
                        <asp:ListItem Text="Fuego" />
                        <asp:ListItem Text="Agua" />
                    </asp:DropDownList>
                </div>
            </div>
            <hr />

            <div class="col-6">
                <div class="mb-3">
                    <h4>DropDrownList desde DB</h4>
                    <label for="" class="form-label">Nombres Poke</label>
                    <div>
                        <asp:DropDownList ID="ddlPokemons" CssClass="btn btn-outline-dark dropdown-toogle" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <!-- DropDrownList Enlazados -->
            <div class="row mb-3">
                <hr />
                <h4>DropDrownList Enlazados</h4>
                <div class="col-6">
                    <asp:DropDownList ID="ddlTipo3" CssClass="btn btn-outline-dark dropdown-toogle"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlTipo3_SelectedIndexChanged"
                        runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-6">
                    <asp:DropDownList ID="ddlPokeFiltrados" CssClass="btn btn-outline-dark dropdown-toogle" runat="server"></asp:DropDownList>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
