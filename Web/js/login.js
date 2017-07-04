
$(document).ready(function() {
    $("#frmLogin").on("submit", function (e) {
        e.preventDefault();
        var usu = $("#txtUsuario").val();
        var pass = $("#txtContraseña").val();
        Logeo(usu, pass);
    });

    $(".close").click(function () {
        $("#mensajes").slideUp();
    });
});

function Logeo(usu, pass){
    if(usu != "" && pass != "") {
        $(location).attr("href","MenuPrincipal.html");
    } else {
        $("#mensajes strong").html("<i class='fa fa-exclamation-triangle' aria-hidden='true'></i> Advertencia");
        $("#mensajes #textoMsm").html("Ingrese Usuario y Contraseña");
        $("#mensajes").slideDown();
    }
}