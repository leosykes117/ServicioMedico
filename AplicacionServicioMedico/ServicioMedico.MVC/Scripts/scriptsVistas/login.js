$("#mensajes").hide();
var usu;
var pass;
$(document).ready(function () {
    $("#btnIniciar").click(function () {
        usu = $("#txtUsuario").val();
        pass = $("#txtContraseña").val();
        if (usu != "" && pass != "") {
            $(location).attr("href", "Doctores/Index");
        } else {
            $("#mensajes").show();
            $("#textoError").html("Ingrese su Usuario y contraseña");
        }
    });

    $(".close").click(function () {
        $("#mensajes").hide();
    });
});