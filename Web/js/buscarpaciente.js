$(document).ready(function () {
    listarAlumnos();
    listarDoc();
    listarPaae();
    listarExternos();

    var tipoPac = $("#cmbTipoBuscar").val();
    MostrarTabla(tipoPac);

    $("#cmbTipoBuscar").change(function () {
        MostrarTabla($(this).val());
    });
});

$("#cmbTipo").change(function () {
    var cmbtipo = $(this).val()
    if (cmbtipo == 1) {
        $("#datosPersonal").slideUp("slow");
        $("#datosAlumno").show("slow");
    } else if (cmbtipo == 2 || cmbtipo == 3) {
        $("#datosAlumno").slideUp("slow");
        $("#datosPersonal").slideDown("slow");
    } else {
        $("#datosAlumno").slideUp("slow");
        $("#datosPersonal").slideUp("slow");
    }
});

$('#dtpFechaNac').datetimepicker({
    format: 'YYYY-MM-DD',
    //locale: "es",
    extraFormats: ['YYYY-MM-DD']
});

$("#dtpFechaNac").focusout(function () {
    var nacimiento = moment($(this).val());
    var hoy = moment();
    var edad = hoy.diff(nacimiento, "years");
    $("#txtEdad").val(edad);
});

$("#btnAgregarPaciente").click(function () {
    $("#modalDatos").modal("hide");
    $("#myModal").modal("show");
    /*$("#modalContent1").hide("slide", function () {
        $("#modalContent2").show("slide");
    });*/
});

/*$("#modalDatos").on("hide.bs.modal", function (e) {
    var value = $("input").val();
    console.log(value);
    var mensaje = confirm("Perderas el trabajo ya hecho ¿Deseas cancelar?");
    //Detectamos si el usuario acepto el mensaje
    if (mensaje) {
        
    }
    //Detectamos si el usuario denegó el mensaje
    else {
        e.preventDefault();
    }
});*/

function MostrarTabla(tipo) {
    if (tipo == 1) {
        $("#Alumnos").show();
        $("#Docentes").hide();
        $("#Paaes").hide();
        $("#Externos").hide();
    } else if (tipo == 2) {
        $("#Docentes").show();
        $("#Alumnos").hide();
        $("#Paaes").hide();
        $("#Externos").hide();
    } else if (tipo == 3) {
        $("#Paaes").show();
        $("#Alumnos").hide();
        $("#Docentes").hide();
        $("#Externos").hide();
    } else {
        $("#Externos").show();
        $("#Alumnos").hide();
        $("#Docentes").hide();
        $("#Paaes").hide();
    }
}

function listarAlumnos(){
    var tablaAlu = $("#tbAlumnos").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbAlumnos tbody", tablaAlu);
}

function listarDoc(){
    var tablaDoc = $("#tbDocentes").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbDocentes tbody", tablaDoc);
}

function listarPaae() {
    var tablaPaae = $("#tbPaaes").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbPaaes tbody", tablaPaae);
}

function listarExternos(){
    var tablaExt = $("#tbExternos").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbExternos tbody", tablaExt);
}

function obtener_editar(tbody, table){
    $(tbody).on("dblclick", "tr", function () {
        var data = table.row( $(this) ).data();
        console.log(data);
        $("#myModal").modal("show");
    });
}

var idioma_español = {
    "sProcessing":     "Procesando...",
    "sLengthMenu":     "Mostrar _MENU_ registros",
    "sZeroRecords":    "No se encontraron resultados",
    "sEmptyTable":     "Ningún dato disponible en esta tabla",
    "sInfo":           "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfoEmpty":      "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoFiltered":   "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix":    "",
    "sSearch":         "Buscar:",
    "sUrl":            "",
    "sInfoThousands":  ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst":    "Primero",
        "sLast":     "Último",
        "sNext":     "Siguiente",
        "sPrevious": "Anterior"
    },
    "oAria": {
        "sSortAscending":  ": Activar para ordenar la columna de manera ascendente",
        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    }
}