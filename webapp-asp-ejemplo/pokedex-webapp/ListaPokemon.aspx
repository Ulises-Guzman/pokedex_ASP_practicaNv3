<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="pokedex_webapp.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
        <h1>Lista de Pokemon's</h1>
        <div class="row">
            <div class="col-4">
                <%--<div class="mt-3 mb-3">
                    <label class=" mb-1 form-label">Criterio de Filtro</label>

                    <div class="mb-3 form-check">
                        <asp:RadioButton ID="rdbTodos" GroupName="Estado" Checked="true" runat="server" />
                        <label class="pe-3 form-check-label" for="rdbActivo">Todos</label>

                        <asp:RadioButton ID="rdbActivo" GroupName="Estado" runat="server" />
                        <label class="pe-3 form-check-label" for="rdbActivo">Activo</label>

                        <asp:RadioButton ID="rdbInactivo" GroupName="Estado" runat="server" />
                        <label class="form-check-label" for="rdbInactivo">Inactivo</label>
                    </div>
                </div>--%>

                <div class="mb-3 ">
                    <label for="txtFiltro" class="form-label">Filtrar</label>
                    <asp:TextBox ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" runat="server" />
                </div>
            </div>

            <div class="col position-relative">
                <!-- style="display:flex; flex-direction: column; justify-content: flex-end" -->
                <div class="mb-3 position-absolute bottom-0 start-0">
                    <asp:CheckBox ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
                    <label for="chkFiltroAvanzado">Filtro avanzado</label>
                </div>
                <div class="mb-3 position-absolute bottom-0 end-0">
                    <asp:Button ID="btnLimpiar" CssClass="btn btn-secondary" Text="Limpiar" OnClick="btnLimpiar_Click" runat="server"  />
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!-- Menu filtro avanzado -->
                    <% if (chkFiltroAvanzado.Checked)%>
                    <% { %>

                    <div class="row">
                        <div class="col-3">
                            <div class="mb-3">
                                <label class="form-label">Campo</label>
                                <asp:DropDownList ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Text="Nombre" />
                                    <asp:ListItem Text="Tipo" />
                                    <asp:ListItem Text="Número" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <label class="form-label">Criterio</label>
                                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" OnInit="ddlCriterio_Init" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <label class="form-label">Palabra clave</label>
                                <asp:TextBox ID="txtFiltrar" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <label class="form-label">Estado</label>
                                <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Todos" />
                                    <asp:ListItem Text="Activo" />
                                    <asp:ListItem Text="Inactivo" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                    <% } %>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="row">
        <div class="col">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
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
                            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
                <asp:Button ID="btnAgregar" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
