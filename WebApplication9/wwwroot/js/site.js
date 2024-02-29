// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function caricamentoListPersone() {
    $.get({
        url: "/Home/_ListPersone",
        cache: false
    }).done(function (data) {
        $("#divListePersone").html(data);
    }).fail(function (data) {
        console.log("Errore");
    });
}

function caricamentoFormPersona() {
    $.get({
        url: "/Home/_FormPersona",
        cache: false
    }).done(function (data) {
        $("#divFormPersona").html(data);
    }).fail(function (data) {
        console.log("Errore");
    });
}