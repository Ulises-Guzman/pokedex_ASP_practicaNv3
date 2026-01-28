<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_webapp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-5 justify-content-center align-items-center">
        <div class="col-4 bg-body rounded-4">
        <h4 class="mt-5 mb-3 ms-3 me-3">Por favor, inicie sesión</h4>
            <div class="mb-3 ms-3 me-3">
                <asp:TextBox
                    ID="txtUsuario"
                    CssClass="form-control"
                    PlaceHolder="Nombre de usuario..."
                    runat="server">
                </asp:TextBox>
            </div>
            <div class="mb-4 ms-3 me-3">
                <asp:TextBox
                    ID="txtContrasena"
                    CssClass="form-control"
                    PlaceHolder="Contraseña..."
                    Type="password"
                    runat="server">
                </asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnIniciarSesion" CssClass="mb-5 ms-3 me-3 btn btn-primary we" style="width: 91%;" Text="Iniciar sesión" OnClick="btnIniciarSesion_Click" runat="server" />
            </div>
        </div>

    </div>
</asp:Content>
