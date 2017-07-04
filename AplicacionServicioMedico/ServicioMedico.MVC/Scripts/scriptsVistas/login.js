$(document).ready(function() {
    var usu = $("#txtUsuario").val();
    var pass = $("#txtContraseña").val();

    $("#btnIniciar").click(function() {
        Logeo(usu, pass);

    });

    $("#txtUsuario, #txtContraseña").keypress(function(e) {
        if(e.which == 13) {
            Logeo(usu, pass);
        }
    });

    $(".close").click(function () {
        $("#mensajes").hide();
    });
});

function Logeo(usu, pass){
    usu = $("#txtUsuario").val();
    pass = $("#txtContraseña").val();
    if(usu != "" && pass != "") {
        $(location).attr("href", "Doctores/Index");
    } else {
        $("#mensajes").show();
        $("#textoError").html("Ingrese su Usuario y contraseña");
    }
}