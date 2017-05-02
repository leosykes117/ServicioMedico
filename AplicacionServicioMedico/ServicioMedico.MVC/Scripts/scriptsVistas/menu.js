$(document).ready(function () {
    $("#Nombre").append(" Leonardo");
    $("#cmbTipo").change(function () {
        if ($("#cmbTipo").val() == 1) {
            $("#datosAlumno").slideDown();
        } else {
            $("#datosAlumno").slideUp();
        }
    });
});