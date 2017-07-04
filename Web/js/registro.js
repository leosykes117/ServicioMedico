$(document).ready(function () {
    //EVENTOS DEL TEXT BOX Contraseña
    $("#txtContraseña").click(function () {
        $("#especificacion").slideDown();

    }).focus(function () {
        $("#especificacion").slideDown();

    }).focusout(function () {
        if ($("#txtContraseña").val() == "") {

            $("#especificacion").css("color","red");

        } else {
            
            $("#especificacion").slideUp();
        }
    });//FIN DE LOS EVENTOS DEL TEXT BOX Contraseña
});