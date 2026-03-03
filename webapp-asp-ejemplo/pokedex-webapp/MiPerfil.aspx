<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="pokedex_webapp.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>
    <%--<script>
        function validar() {
            'use strict'
            // Capturar el control
            var ban = false;
            const txtNombre = document.getElementById("txtNombre");
            const txtApellido = document.getElementById("txtApellido");


            if (txtNombre.value == "") {
                txtNombre.classList.remove("is-valid");
                txtNombre.classList.add("is-invalid");
                ban = true;
            } else {
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
            }

            if (txtApellido.value == "") {
                txtApellido.classList.remove("is-valid");
                txtApellido.classList.add("is-invalid");
                ban = true;
            } else {
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
            }

            txtNombre.classList.add("was-validated");
            txtApellido.classList.add("was-validated");


            if (ban) {
                return false;
            }
            return true;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <hr />
    <div class="row">
        <!-- aqui deberia usar la clase needs-validation y la propiedad novalidate -->
        <div class="col-md-1"></div>
        <div class="col-md-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Dirección Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <div class="invalid-feedback">Por favor, ingresa un nombre.</div>
                <div class="valid-feedback">!Se ve bien!</div>
                <%--<asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido" ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <div class="invalid-feedback">Por favor, ingrese un apellido.</div>
                <div class="valid-feedback">!Se ve bien!</div>
                <%--<asp:RequiredFieldValidator CssClass="validacion"  ControlToValidate="txtApellido" ErrorMessage="Campo requerido" runat="server" />--%>
                <%--<asp:RangeValidator CssClass="validacion" ErrorMessage="Valor fuera de rango" ControlToValidate="txtApellido" Type="Integer" MinimumValue="1" MaximumValue="10" runat="server" />--%>
                <%--<asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Ingrese solo números" ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server" />--%>
                <%--<asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="No es válido como email" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label for="txtFechaNac" class="form-label">Fecha de nacimiento</label>
                <asp:TextBox ID="txtFechaNac" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary me-2" Text="Guardar" OnClientClick="return validar()" OnClick="btnGuardar_Click" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn btn-secondary" Text="< Regresar" runat="server" />
            </div>
        </div>
        <div class="col-md-5 ms-5">
            <div class="mb-3">
                <label for="txtImagenPerfil" class="form-label">Imagen de perfil</label>
                <input id="txtImagenPerfil" class="form-control" type="file" runat="server">
                <%--<asp:FileUpload ID="fupImagenPerfil" CssClass="form-control" AutoPostBack="true" On runat="server" />--%>
            </div>
            <div class="mb-3">
                <asp:Image ID="imgImagenPerfil" ImageUrl="https://cdn-icons-png.flaticon.com/512/17003/17003579.png" Height="256px" Width="256px" runat="server" />
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>

    <script>
        // Refactoring //
        'use strict'

        // 1. Capturar los controles fuera de la función para que sean globales en el script
        const txtNombre = document.getElementById("txtNombre");
        const txtApellido = document.getElementById("txtApellido");

        // 2. Crear una función genérica que valide un solo campo a la vez
        function validarCampo(campo) {
            if (campo.value.trim() === "") {
                campo.classList.remove("is-valid");
                campo.classList.add("is-invalid");
                return false; // Retorna falso si hay error
            } else {
                campo.classList.remove("is-invalid");
                campo.classList.add("is-valid");
                return true; // Retorna verdadero si está todo bien
            }
        }

        // 3. Escuchar en "tiempo de ejecución", cuando el cliente tipea
        txtNombre.addEventListener('input', () => validarCampo(txtNombre));
        txtApellido.addEventListener('input', () => validarCampo(txtApellido));

        // 4. Función principal para llamarla cuando se hace click en el botón "Guardar""
        function validar() {
            // Valido todos los campos
            const nombreValido = validarCampo(txtNombre);
            const apellidoValido = validarCampo(txtApellido);

            // Si alguno es falso la validación general falla
            if (!nombreValido || !apellidoValido) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
