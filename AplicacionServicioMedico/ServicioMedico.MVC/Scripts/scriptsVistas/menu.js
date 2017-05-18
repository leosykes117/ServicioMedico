$(document).ready(function () {
    $("#Nombre").append(" Leonardo");
    $("#cmbTipo").change(function () {
        var cmbtipo = $(this).val()
        if (cmbtipo == 1) {
            $("#datosPersonal").slideUp("slow");
            $("#datosAlumno").slideDown("slow");
        } else if (cmbtipo == 2 || cmbtipo == 3) {
            $("#datosAlumno").slideUp("slow");
            $("#datosPersonal").slideDown("slow");
        } else {
            $("#datosAlumno").slideUp("slow");
            $("#datosPersonal").slideUp("slow");
        }
    });
});