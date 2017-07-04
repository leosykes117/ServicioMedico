$(document).ready(function () {
    MostrarTabla($("#cmbTipoBuscar").val());
});

$("#cmbTipoBuscar").change(function () {
    MostrarTabla($(this).val());
});

$("#cmbTipo").change(function () {
    var cmbtipo = $(this).val()
    if (cmbtipo == 1) {
        $("#datosPersonal").slideUp("slow", function () {
            $("#datosAlumno").slideDown("slow");
        });
        $("#txtBoleta").attr("required");
        $("#txtGrupo").attr("required");

    } else if (cmbtipo == 2 || cmbtipo == 3) {
        $("#datosAlumno").slideUp("slow", function () {
            $("#datosPersonal").slideDown("slow");
        });
        $("#txtBoleta").removeAttr("required").val(null);
        $("#txtGrupo").removeAttr("required").val(null);
        $("#cmbCarrera").val(1);

    } else {
        $("#datosAlumno").slideUp("slow", function () {
            $("#datosPersonal").slideUp("slow");
        });
        $("#txtBoleta").removeAttr("required").val(null);
        $("#txtGrupo").removeAttr("required").val(null);
        $("#cmbCarrera").val(1);
    }
});

$('#dtpFechaNac').datetimepicker({
    format: 'YYYY-MM-DD',
    locale: "es",
    extraFormats: ['YYYY-MM-DD']
});

$("#dtpFechaNac").focusout(function () {
    var nacimiento = moment($(this).val());
    if(nacimiento == null) {
        var hoy = moment();
        var edad = hoy.diff(nacimiento, "years");
        $("#txtEdad").val(edad);
    }
    else{
        $("#txtEdad").val(null);
    }
});

$("#frmAgregarPaciente").on("submit", function (event) {
    event.preventDefault();
    var nuevoPaciente = $(this).serializeFormJSON();
    if (nuevoPaciente.tipoPaciente == 1) {

        $.ajax({
            url: "/Pacientes/AgregarAlumno",
            method: "POST",
            data: nuevoPaciente,
            cache: false,
            beforeSend: function () {
                $("#btnAgregarPaciente").html("Agregando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr("disabled","true");
            }
        }).done(function (data) {
            if (data[0] == "Registrado") {
                $("#txtidEnviar").val(data[1]);
                $("#txtnomEnviar").val(data[2]);
                $("#txtedadEnviar").val(data[3]);
                $("#txtgeneroEnviar").val(data[4]);
                $("#modalDatos").modal("hide");
                $("#modalConsulta").modal("show");
            } else {
                $("#mensajeError").html(data);
            }
        }).fail(manejarErrorAjax).always(function () {
            $("#btnAgregarPaciente").html("Agregar Paciente").removeAttr("disabled");
        });

    } else if (nuevoPaciente.tipoPaciente == 2 || nuevoPaciente.tipoPaciente == 3) {

        $.ajax({
            url: "/Pacientes/AgregarPersonal",
            method: "POST",
            data: nuevoPaciente,
            cache: false,
            beforeSend: function () {
                $("#btnAgregarPaciente").html("Agregando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr("disabled","true");
            }
        }).done(function (data) {

            if (data[0] == "Registrado") {
                $("#txtidEnviar").val(data[1]);
                $("#txtnomEnviar").val(data[2]);
                $("#txtedadEnviar").val(data[3]);
                $("#txtgeneroEnviar").val(data[4]);
                $("#modalDatos").modal("hide");
                $("#modalConsulta").modal("show");
            } else {
                $("#mensajeError").html(data);
            }
        }).fail(manejarErrorAjax).always(function () {
            $("#btnAgregarPaciente").html("Agregar Paciente").removeAttr("disabled");
        });

    } else {

        $.ajax({
            url: "/Pacientes/AgregarExterno",
            method: "POST",
            data: nuevoPaciente,
            cache: false,
            beforeSend: function () {
                $("#btnAgregarPaciente").html("Agregando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr("disabled","true");
            }
        }).done(function (data) {

            if (data[0] == "Registrado") {
                $("#txtidEnviar").val(data[1]);
                $("#txtnomEnviar").val(data[2]);
                $("#txtedadEnviar").val(data[3]);
                $("#txtgeneroEnviar").val(data[4]);
                $("#modalDatos").modal("hide");
                $("#modalConsulta").modal("show");
            } else {
                $("#mensajeError").html(data);
            }
        }).fail(manejarErrorAjax).always(function () {
            $("#btnAgregarPaciente").html("Agregar Paciente").removeAttr("disabled");
        });

    }
});

$(".recargartb").click(function () {
    if ($("#cmbTipoBuscar").val() == 1) {
        listarAlumnos();
    } else if ($("#cmbTipoBuscar").val() == 2) {
        listarDoc();
    } else if ($("#cmbTipoBuscar").val() == 3) {
        listarPaae();
    } else {
        listarExternos();
    }
});


function MostrarTabla(tipo) {
    if (tipo == 1) {
        if ($("#tbAlumnos tbody tr").children().length < 1) {
            listarAlumnos();
            $("#Alumnos").show();
            $("#Docentes").hide();
            $("#Paaes").hide();
            $("#Externos").hide();
        } else {
            $("#Alumnos").show();
            $("#Docentes").hide();
            $("#Paaes").hide();
            $("#Externos").hide();
        }
    } else if (tipo == 2) {
        if ($("#tbDocentes tbody tr").children().length < 1) {
            listarDoc();
            $("#Docentes").show();
            $("#Alumnos").hide();
            $("#Paaes").hide();
            $("#Externos").hide();
        } else {
            $("#Docentes").show();
            $("#Alumnos").hide();
            $("#Paaes").hide();
            $("#Externos").hide();
        } 
    } else if (tipo == 3) {
        if ($("#tbPaaes tbody tr").children().length < 1) {
            listarPaae();
            $("#Paaes").show();
            $("#Alumnos").hide();
            $("#Docentes").hide();
            $("#Externos").hide();
        } else {
            $("#Paaes").show();
            $("#Alumnos").hide();
            $("#Docentes").hide();
            $("#Externos").hide();
        }
    } else {
        if ($("#tbExternos tbody tr").children().length < 1) {
            listarExternos();
            $("#Externos").show();
            $("#Alumnos").hide();
            $("#Docentes").hide();
            $("#Paaes").hide();
        } else {
            $("#Externos").show();
            $("#Alumnos").hide();
            $("#Docentes").hide();
            $("#Paaes").hide();
        }
    }
}

var listarAlumnos = function () {
    var tablaAlu = $("#tbAlumnos").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 1, estatus: 1 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Boleta" },
            { "defaultContent": "<button type='button' class='btn btn-primario btn-block consulta' data-toggle='tooltip' data-placement='top' title='Haz click para pasarme a consulta'><i class='fa fa-stethoscope fa-lg' aria-hidden='true'></i></button>" }

        ],
        "language": idioma_español
    });
    obtener_consulta("#tbAlumnos tbody", tablaAlu);
}

var listarDoc = function () {
    var tablaDoc = $("#tbDocentes").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 2, estatus: 1 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Num_Empleado" },
            { "defaultContent": "<button type='button' class='btn btn-primario btn-block consulta' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-stethoscope fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_consulta("#tbDocentes tbody", tablaDoc);
}

var listarPaae = function () {
    var tablaPaae = $("#tbPaaes").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 3, estatus: 1 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Num_Empleado" },
            { "defaultContent": "<button type='button' class='btn btn-primario btn-block consulta' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-stethoscope fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_consulta("#tbPaaes tbody", tablaPaae);
}

var listarExternos = function () {
    var tablaExt = $("#tbExternos").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 4, estatus: 1 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "defaultContent": "<button type='button' class='btn btn-primario btn-block consulta' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-stethoscope fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_consulta("#tbExternos tbody", tablaExt);
}

function obtener_consulta(tbody, table) {
    $(tbody).on("click", "button.consulta", function () {
        var data = table.row( $(this).parents("tr") ).data();
        $("#txtidEnviar").val(data.Clave);
        $("#txtnomEnviar").val(data.Nombre + " " + data.Apellidos).focus();
        $("#txtedadEnviar").val(data.Edad);
        $("#txtgeneroEnviar").val(data.ClaveGenero);
        $("#modalConsulta").modal("show");
    });
}

var idioma_español = {
    "sProcessing": "Procesando...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "No se encontraron resultados",
    "sEmptyTable": "Ningún dato disponible en esta tabla",
    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix": "",
    "sSearch": "Buscar:",
    "sUrl": "",
    "sInfoThousands": ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst": "Primero",
        "sLast": "Último",
        "sNext": "Siguiente",
        "sPrevious": "Anterior"
    },
    "oAria": {
        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    }
}

function manejarErrorAjax(err) {
    console.log(err.responseText);
}