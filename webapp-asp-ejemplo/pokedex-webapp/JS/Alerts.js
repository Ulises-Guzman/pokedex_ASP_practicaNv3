'use strict'

// Espera a que el documento esté completamente cargado
document.addEventListener("DOMContentLoaded", function () {

    // Selecciona todas las alertas en la pantalla
    var alertas = document.querySelectorAll('.alert');

    alertas.forEach(function (alerta) {
        // Configura un temporizador de 4 segundos (4000 milisegundos)
        setTimeout(function () {
            // Instancia la alerta de Bootstrap y la cierra
            var bsAlert = new bootstrap.Alert(alerta);
            bsAlert.close();
        }, 4000); // Ajustar este número para dar más o menos tiempo
    });

});