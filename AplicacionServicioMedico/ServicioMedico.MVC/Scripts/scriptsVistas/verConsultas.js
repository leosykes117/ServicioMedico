$(document).ready(function () {
    $("ul#consulta").addClass("in");
    $("li#linkInicio").removeClass("activado");
    $("a#linkConsultas").addClass("activado");
    var tipoPaciente = $("#cmbTipoPaciente").val();
    var estatus = $("#Estatus").val();
    MostrarTabla(tipoPaciente, estatus);
});

$("#cmbTipoPaciente").change(function () {
    var tipoPaciente = $(this).val();
    var estatus = $("#Estatus").val();
    MostrarTabla(tipoPaciente, estatus);
});

$("#frmCambiarEstatus").on("submit", function (event) {
    var actualizar = false;
    event.preventDefault();
    var data = { consulta: $("#txtConsultaDelete").val(), estatusCon: 0 };
    $.ajax({
        url: $(this).attr("action"),
        method: $(this).attr("method"),
        data: data,
        cache: false,
        beforeSend: function () {
            $("#btnEliminarConsulta").html("Eliminando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr("disabled", "true");
        }
    }).done(function (data) {
        if (data == "Actualizo") {
            actualizar = true;
            $("#snackbar").html("La consulta se elimino con exito");
        } else {
            actualizar = false;
            $("#snackbar").html("La consulta medica no se pudo eliminar");
        }
    }).fail(function (jqXHR, textStatus) {
        actualizar = false;
        $("#snackbar").html(textStatus);
    }).always(function () {
        $("#btnEliminarConsulta").html("Eliminar").removeAttr("disabled");
        $("#modalEliminar").modal("hide");
        mostrarSnack();
        if (actualizar) {
            recargarTabla($("#cmbTipoPaciente").val());
        }
    });
});

$("#frmEliminarConsulta").on("submit", function (event) {
    var actualizar = false;
    var data = { consulta: $("#txtConsultaDelete").val() };
    event.preventDefault();
    $.ajax({
        url: $(this).attr("action"),
        method: $(this).attr("method"),
        data: data,
        cache: false,
        beforeSend: function () {
            $("#btnEliminarConsulta").html("Eliminando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr("disabled", "true");
        }
    }).done(function (data) {
        if (data == "Eliminada") {
            actualizar = true;
            $("#snackbar").html("La consulta se elimino con exito");
        } else {
            actualizar = false;
            $("#snackbar").html("La consulta medica no se pudo eliminar");
        }
    }).fail(function (jqXHR, textStatus) {
        actualizar = false;
        $("#snackbar").html(textStatus);
    }).always(function () {
        $("#btnEliminarConsulta").html("Eliminar").removeAttr("disabled");
        $("#modalEliminar").modal("hide");
        mostrarSnack();
        if (actualizar) {
            recargarTabla($("#cmbTipoPaciente").val());
        }
    });
});

$(document).on("click", "#recargartb", function () {
    recargarTabla($("#cmbTipoPaciente").val());
});

function MostrarTabla(tipo, estatusCon) {
    if (tipo == 1) {
        if ($("#tbAlumnos tbody tr").children().length < 1) {
            listarAlumnos(tipo, estatusCon);
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
            listarDoc(tipo, estatusCon);
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
            listarPaae(tipo, estatusCon);
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
            listarExternos(tipo, estatusCon);
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

var listarAlumnos = function (cmbTipo, est) {
    var data = { t: cmbTipo, estatus: est};
    var tablaAlu = $("#tbAlumnos").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Consultas/ListarConsultas",
            "data": data,
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Generos" },
            { "data": "Atendio" },
            { "data": "Diagnostico" },
            { "data": "FechaConsulta" },
            { "data": "HoraEntrada" },
            { "data": "HoraSalida" },
            { "data": "DuracionConsulta" },
            { "data": "Temperatura" },
            { "data": "TA" },
            { "data": "FC" },
            { "data": "FR" },
            {
                sortable: false,
                "render": function () {
                    var botones;
                    if ($("#Estatus").val() == 1) {
                        botones = "<button type='button' class='btn btn-success btn-block editar'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    } else {
                        botones = "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    }
                    return botones;
                }
            }
        ],
        "columnDefs": [
            {
                "targets": 4,
                "data": "FechaConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    moment.locale("es");
                    return moment(data).format("LL");
                },
                "width": "80px"
            },
            {
                "targets": [5, 6],
                "data": "HoraEntrada, HoraSalida",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("h:mm:ss a");
                },
                "width": "70px"
            },
            {
                "targets": 7,
                "data": "DuracionConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("HH:mm:ss");
                }
            }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbAlumnos tbody", tablaAlu);
    obtener_eliminar("#tbAlumnos tbody", tablaAlu);
    obtener_recuperar("#tbAlumnos tbody", tablaAlu);
}

var listarDoc = function (cmbTipo, est) {
    var data = { t: cmbTipo, estatus: est };
    var tablaDoc = $("#tbDocentes").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Consultas/ListarConsultas",
            "data": data,
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Generos" },
            { "data": "Atendio" },
            { "data": "Diagnostico" },
            { "data": "FechaConsulta" },
            { "data": "HoraEntrada" },
            { "data": "HoraSalida" },
            { "data": "DuracionConsulta" },
            { "data": "Temperatura" },
            { "data": "TA" },
            { "data": "FC" },
            { "data": "FR" },
            {
                sortable: false,
                "render": function () {
                    var botones;
                    if ($("#Estatus").val() == 1) {
                        botones = "<button type='button' class='btn btn-success btn-block editar'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    } else {
                        botones = "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    }
                    return botones;
                }
            }
        ],
        "columnDefs": [
            {
                "targets": 4,
                "data": "FechaConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    moment.locale("es");
                    return moment(data).format("LL");
                },
                "width": "80px"
            },
            {
                "targets": [5, 6],
                "data": "HoraEntrada, HoraSalida",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("h:mm:ss a");
                },
                "width": "70px"
            },
            {
                "targets": 7,
                "data": "DuracionConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("HH:mm:ss");
                }
            }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbDocentes tbody", tablaDoc);
    obtener_eliminar("#tbDocentes tbody", tablaDoc);
    obtener_recuperar("#tbDocentes tbody", tablaDoc);
}

var listarPaae = function (cmbTipo, est) {
    var data = { t: cmbTipo, estatus: est };
    var tablaPaae = $("#tbPaaes").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Consultas/ListarConsultas",
            "data": data,
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Generos" },
            { "data": "Atendio" },
            { "data": "Diagnostico" },
            { "data": "FechaConsulta" },
            { "data": "HoraEntrada" },
            { "data": "HoraSalida" },
            { "data": "DuracionConsulta" },
            { "data": "Temperatura" },
            { "data": "TA" },
            { "data": "FC" },
            { "data": "FR" },
            {
                sortable: false,
                "render": function () {
                    var botones;
                    if ($("#Estatus").val() == 1) {
                        botones = "<button type='button' class='btn btn-success btn-block editar'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    } else {
                        botones = "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    }
                    return botones;
                }
            }
        ],
        "columnDefs": [
            {
                "targets": 4,
                "data": "FechaConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    moment.locale("es");
                    return moment(data).format("LL");
                },
                "width": "80px"
            },
            {
                "targets": [5, 6],
                "data": "HoraEntrada, HoraSalida",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("h:mm:ss a");
                },
                "width": "70px"
            },
            {
                "targets": 7,
                "data": "DuracionConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("HH:mm:ss");
                }
            }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbPaaes tbody", tablaPaae);
    obtener_eliminar("#tbPaaes tbody", tablaPaae);
    obtener_recuperar("#tbPaaes tbody", tablaPaae);
}

var listarExternos = function (cmbTipo, est ) {
    var data = { t: cmbTipo, estatus: est };
    var tablaExt = $("#tbExternos").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Consultas/ListarConsultas",
            "data": data,
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Generos" },
            { "data": "Atendio" },
            { "data": "Diagnostico" },
            { "data": "FechaConsulta" },
            { "data": "HoraEntrada" },
            { "data": "HoraSalida" },
            { "data": "DuracionConsulta" },
            { "data": "Temperatura" },
            { "data": "TA" },
            { "data": "FC" },
            { "data": "FR" },
            {
                sortable: false,
                "render": function () {
                    var botones;
                    if ($("#Estatus").val() == 1) {
                        botones = "<button type='button' class='btn btn-success btn-block editar'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    } else {
                        botones = "<button type='button' class='btn btn-success btn-block recuperar'><i class='fa fa-recycle fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>";
                    }
                    return botones;
                }
            }
        ],
        "columnDefs": [
            {
                "targets": 4,
                "data": "FechaConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    moment.locale("es");
                    return moment(data).format("LL");
                },
                "width": "80px"
            },
            {
                "targets": [5, 6],
                "data": "HoraEntrada, HoraSalida",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("h:mm:ss a");
                },
                "width": "70px"
            },
            {
                "targets": 7,
                "data": "DuracionConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("HH:mm:ss");
                }
            }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbExternos tbody", tablaExt);
    obtener_eliminar("#tbExternos tbody", tablaExt);
    obtener_recuperar("#tbExternos tbody", tablaExt);
}

function obtener_editar(tbody, table) {
    $(tbody).on("click", "button.editar", function () {
        var data = table.row($(this).parents("tr")).data();
        console.log(data);
        $("#txtClave").val(data.IdConsulta);
        $("#txtNombre").val(data.Nombre);
        $("#txtEdad").val(data.EdadPaciente);
        $("#txtGenero").val(data.Generos);
        $("#txtDiagnostico").val(data.Diagnostico);
        $("#txtObservaciones").val(data.Observaciones);
        $("#txtCveDoctor").val(data.CveDoctor);
        $("#txtFecha").val(moment(data.FechaConsulta).format("L"));
        $("#txtHoraEntrada").val(moment(data.HoraEntrada).format("LTS"));
        $("#txtHoraSalida").val(moment(data.HoraSalida).format("LTS"));
        $("#txtTemperatura").val(data.Temperatura);
        $("#txtTA").val(data.TA);
        $("#txtFC").val(data.FC);
        $("#txtFR").val(data.FR);
        $("#modalConsultaEditar").modal("show");
    });
}

function obtener_eliminar(tbody, table) {
    $(tbody).on("click", "button.eliminar", function () {
        var datosConsulta = table.row($(this).parents("tr")).data();
        $("#txtConsultaDelete").val(datosConsulta.IdConsulta);
        $("#modalEliminar").modal("show");
    });
}

function obtener_recuperar(tbody, table) {
    $(tbody).on("click", "button.recuperar", function () {
        var actualizar = false;
        var consultaEliminada = table.row($(this).parents("tr")).data();
        var data = { consulta: consultaEliminada.IdConsulta, estatusCon: 1 };
        $.ajax({
            url: "/Consultas/CambiarEstatus",
            method: "POST",
            data: data,
            cache: false
        }).done(function (data) {
            if (data = "Actualizo") {
                actualizar = true;
                $("#snackbar").html("La consulta se recupero con exito");
            } else {
                $("#snackbar").html("La consulta medica no se pudo recuperar");
            }
        }).fail(function (jqXHR, textStatus) {
            $("#snackbar").html(textStatus);
        }).always(function () {
            mostrarSnack();
            if (actualizar) {
                recargarTabla($("#cmbTipoPaciente").val());
            }
        });
    });
}

function recargarTabla(tipo) {
    if (tipo == 1) {
        $('#tbAlumnos').DataTable().ajax.reload();
    } else if (tipo == 2) {
        $("#tbDocentes").DataTable().ajax.reload();
    } else if (tipo == 3) {
        $("#tbPaaes").DataTable().ajax.reload();
    } else {
        $("#tbExternos").DataTable().ajax.reload();
    }
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