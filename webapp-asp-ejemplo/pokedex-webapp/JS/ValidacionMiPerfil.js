'use strict'

// Declaro las variables fuera para que toda la página las pueda usar
let txtNombre;
let txtApellido;
let txtFechaNac

// 1. Esperar a que el HTML (DOM) cargue completamente
document.addEventListener("DOMContentLoaded", function () {

    // Ahora es seguro capturar los controles porque sabemos que ya existen en la página
    // Gracias a ClientIDMode="Static", los IDs son exactamente los mismos
    txtNombre = document.getElementById("txtNombre");
    txtApellido = document.getElementById("txtApellido");
    txtFechaNac = document.getElementById("txtFechaNac");

    // Asignar el evento 'input' para que valide en tiempo real mientras el usuario escribe
    if (txtNombre) {
        txtNombre.addEventListener('input', () => validarCampo(txtNombre));
    }
    if (txtApellido) {
        txtApellido.addEventListener('input', () => validarCampo(txtApellido));
    }
    if (txtFechaNac) {
        txtFechaNac.addEventListener('input', () => validarCampo(txtFechaNac));
    }
})


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


// 4. Función principal para llamarla cuando se hace click en el botón "Guardar""
function validar() {
    // Valido todos los campos
    const nombreValido = validarCampo(txtNombre);
    const apellidoValido = validarCampo(txtApellido);
    const fechaNacValido = validarCampo(txtFechaNac);

    // Si alguno es falso la validación general falla
    if (!nombreValido || !apellidoValido || !fechaNacValido) {
        return false;
    }
    return true;
}