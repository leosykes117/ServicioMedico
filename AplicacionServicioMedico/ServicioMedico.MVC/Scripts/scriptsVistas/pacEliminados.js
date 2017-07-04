$(document).ready(function () {
    MostrarTabla($("#cmbTipoBuscar").val());
});

$("#cmbTipoBuscar").change(function () {
    MostrarTabla($(this).val());
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

$("#frmEliminarPaciente").on("submit", function (event) {
    event.preventDefault();
    var pacEliminar = $(this).serializeFormJSON();
    $.ajax({
        url: "/Pacientes/EliminarPaciente",
        method: "POST",
        data: pacEliminar,
        cache: false,
        beforeSend: function () {
            $("#btnEliminarPaciente").html("Eliminando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
        }
    }).done(function (data) {
        $("#modalBorrar").modal("hide");
        $("#snackbar").html(data);
    }).fail(manejarErrorAjax).always(function () {
        $("#btnEliminarPaciente").html("Eliminar").attr('disabled', false);
        mostrarSnack();
        setTimeout("location.reload()", 3000);
    });
});

var listarAlumnos = function () {
    var tablaAluCompleta = $("#tbAlumnos").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 1, estatus: 0 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Boleta" },
            { "data": "Grupo" },
            { "data": "Carrera" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_recuperar("#tbAlumnos tbody", tablaAluCompleta);
    obtener_borrar("#tbAlumnos tbody", tablaAluCompleta);
}

var listarDoc = function () {
    var tablaDocCompleta = $("#tbDocentes").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 2, estatus: 0 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Num_Empleado" },
            { "data": "RFC" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_recuperar("#tbDocentes tbody", tablaDocCompleta)
    obtener_borrar("#tbDocentes tbody", tablaDocCompleta);
}

var listarPaae = function () {
    var tablaPaaeCompleta = $("#tbPaaes").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 3, estatus: 0 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Num_Empleado" },
            { "data": "RFC" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_recuperar("#tbPaaes tbody", tablaPaaeCompleta);
    obtener_borrar("#tbPaaes tbody", tablaPaaeCompleta);
}

var listarExternos = function () {
    var tablaExtCompleta = $("#tbExternos").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Pacientes/ListadoGeneral",
            "data": { tipo: 4, estatus: 0 },
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "CURP" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_recuperar("#tbExternos tbody", tablaExtCompleta);
    obtener_borrar("#tbExternos tbody", tablaExtCompleta);   
}

function obtener_recuperar(tbody, table) {
    $(tbody).on("click", "button.recuperar", function () {
        var data = table.row($(this).parents("tr")).data();
        var pacRecuperar = { "IdPaciente": data.Clave, "EstatusPaciente": 1 };
        $.ajax({
            url: "/Pacientes/ActualizarEstatus",
            method: "POST",
            data: pacRecuperar,
            cache: false,
            beforeSend: function () {
                $("#btnEliminarPaciente").html("Eliminando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
            }
        }).done(function (data) {
            $("#modalBorrar").modal("hide");
            $("#snackbar").html(data);
        }).fail(manejarErrorAjax).always(function () {
            $("#btnEliminarPaciente").html("Eliminar").attr('disabled', false);
            mostrarSnack();
            setTimeout("location.reload()", 3000);
        });
    });
}

function obtener_borrar(tbody, table) {
    $(tbody).on("click", "button.eliminar", function () {
        var data = table.row($(this).parents("tr")).data();
        $("#txtidEnviar").val(data.Clave);
        $("#nomEnviar").html((data.Nombre + " " + data.Apellidos));
        $("#modalBorrar").modal("show");
    });
}

(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);

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