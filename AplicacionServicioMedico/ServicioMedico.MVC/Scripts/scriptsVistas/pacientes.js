$(document).ready(function () {
    $("li#linkInicio").removeClass("activado");
    $("ul#pacientes").addClass("in");
    $("a#linkPacientes").addClass("activado");
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
        $("#txtBoleta").removeAttr("required");
        $("#txtGrupo").removeAttr("required");

    } else {
        $("#datosAlumno").slideUp("slow", function () {
            $("#datosPersonal").slideUp("slow");
        });
        $("#txtBoleta").removeAttr("required");
        $("#txtGrupo").removeAttr("required");
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

$("#frmEditarPaciente").on("submit", function (e) {
    var actualizar;
    e.preventDefault();
    var tPaciente = $("#cmbTipo").val();
    if (tPaciente == 1) {
        var aluActualizar = $(this).serializeFormJSON();
        $.ajax({
            url: "/Pacientes/ActualizarAlumno",
            method: "POST",
            data: aluActualizar,
            cache: false,
            beforeSend: function () {
                $("#btnEditar").html("Editando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
            }
        }).done(function (data) {
            if (data == "Alumno Actualizado con Exito") {
                actualizar = true;
                $("#snackbar").html(data);
            } else {
                actualizar = false;
                $("#snackbar").html("Ocurrio un error inesperado");
            }
        }).fail(function (jqXHR, err) {
            actualizar = false;
            $("#snackbar").html(err);
        }).always(function () {
            $("#modalEditar").modal("hide");
            $("#btnEditar").html("Editar Datos").removeAttr('disabled');
            mostrarSnack();
            if (actualizar) {
                recargarTabla(aluActualizar.TipoPaciente);
            }
        });

    } else if (tPaciente == 2 || tPaciente == 3) {
        var personalActualizar = $(this).serializeFormJSON();
        $.ajax({
            url: "/Pacientes/ActualizarPersonalE",
            method: "POST",
            data: personalActualizar,
            cache: false,
            beforeSend: function () {
                $("#btnEditar").html("Editando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
            }
        }).done(function (data) {
            if (data == "Personal Escolar Actualizado con Exito") {
                actualizar = true;
                $("#snackbar").html(data);
            } else {
                actualizar = false;
                $("#snackbar").html("Ocurrio un error inesperado");
            }
        }).fail(function (jqXHR, err) {
            actualizar = false;
            $("#snackbar").html(err);
        }).always(function () {
            $("#modalEditar").modal("hide");
            $("#btnEditar").html("Editar Datos").removeAttr('disabled');
            mostrarSnack();
            if (actualizar) {
                recargarTabla(personalActualizar.TipoPaciente);
            }
        });

    } else {
        var extActualizar = $(this).serializeFormJSON();
        $.ajax({
            url: "/Pacientes/ActualizarExterno",
            method: "POST",
            data: extActualizar,
            cache: false,
            beforeSend: function () {
                $("#btnEditar").html("Editando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
            }
        }).done(function (data) {
            if (data == "Paciente Externo Actualizado con Exito") {
                actualizar = true;
                $("#snackbar").html(data);
            } else {
                actualizar = false;
                $("#snackbar").html("Ocurrio un error inesperado");
            }
        }).fail(function (jqXHR, err) {
            actualizar = false;
            $("#snackbar").html(err);
        }).always(function () {
            $("#modalEditar").modal("hide");
            $("#btnEditar").html("Editar Datos").removeAttr('disabled');
            mostrarSnack();
            if (actualizar) {
                recargarTabla(extActualizar.TipoPaciente);
            }
        });
    }
});

$("#frmActualizarEstatus").on("submit", function (e) {
    e.preventDefault();
    var actualizar;
    var tPaciente = $("#cmbTipoBuscar").val();
    var pacEliminar = $(this).serializeFormJSON();
    $.ajax({
        url: $(this).attr("action"),
        method: $(this).attr("method"),
        data: pacEliminar,
        cache: false,
        beforeSend: function () {
            $("#btnEliminarPaciente").html("Eliminando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
        }
    }).done(function (data) {
        if (data == "Paciente Eliminado con Exito") {
            actualizar = true;
        } else {
            actualizar = false;
        }
        $("#snackbar").html(data);
    }).fail(function (jqXHR, err) {
        actualizar = false;
        $("#snackbar").html(err);
    }).always(function () {
        $("#btnEliminarPaciente").html("Eliminar").removeAttr('disabled');
        $("#modalBorrar").modal("hide");
        mostrarSnack();
        if (actualizar) {
            recargarTabla(tPaciente);
        }
    });
});

$(document).on("click", "#recargartb", function () {
    recargarTabla($("#cmbTipoBuscar").val());
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
    var tablaAluCompleta = $("#tbAlumnos").DataTable({
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
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Boleta" },
            { "data": "Grupo" },
            { "data": "Carrera" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block editar' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbAlumnos tbody", tablaAluCompleta);
    obtener_borrar("#tbAlumnos tbody", tablaAluCompleta);
}

var listarDoc = function () {
    var tablaDocCompleta = $("#tbDocentes").DataTable({
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
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Num_Empleado" },
            { "data": "RFC"},
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block editar' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbDocentes tbody", tablaDocCompleta)
    obtener_borrar("#tbDocentes tbody", tablaDocCompleta);
}

var listarPaae = function () {
    var tablaPaaeCompleta = $("#tbPaaes").DataTable({
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
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Num_Empleado" },
            { "data": "RFC" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block editar' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbPaaes tbody", tablaPaaeCompleta);
    obtener_borrar("#tbPaaes tbody", tablaPaaeCompleta);
}

var listarExternos = function () {
    var tablaExtCompleta = $("#tbExternos").DataTable({
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
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "CURP" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block editar' data-toggle='tooltip' data-placement='top' title='Tooltip on left'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbExternos tbody", tablaExtCompleta);
    obtener_borrar("#tbExternos tbody", tablaExtCompleta);
}

function obtener_editar(tbody, table) {
    $(tbody).on("click", "button.editar", function () {
        var data = table.row($(this).parents("tr")).data();
        $("#cmbTipo").val(data.TipoPaciente);
        $("#txtIdPaciente").val(data.Clave);
        $("#txtNombre").val(data.Nombre);
        $("#txtApellidos").val(data.Apellidos);
        $("#cmbGenero").val(data.ClaveGenero);
        $("#dtpFechaNac").val(moment(data.Fecha).format("YYYY-MM-DD"));
        $("#txtEdad").val(data.Edad);
        $("#txtCurp").val(data.CURP);
        $("#cmbEstado").val(data.Estado);
        $("#cmbMunicipio").val(data.DelMun);
        $("#txtColonia").val(data.Colonia);
        $("#txtCP").val(data.CP);
        $("#txtCalle").val(data.Calle);
        $("#txtInt").val(data.Num_Int);
        $("#txtExt").val(data.Num_Ext);
        $("#txtCelular").val(data.Celular);
        $("#txtTelefono").val(data.Telefono);
        $("#txtCorreo").val(data.Correo);
        if (data.TipoPaciente == 1) {
            $("#datosPersonal").slideUp("slow", function () {
                $("#datosAlumno").slideDown("slow");
                $("#txtBoleta").val(data.Boleta).attr("required");
                $("#txtGrupo").val(data.Grupo).attr("required");
                $("#cmbCarrera").val(data.ClaveCarrera);
            });
        } else if (data.TipoPaciente == 2 || data.TipoPaciente == 3) {
            $("#datosAlumno").slideUp("slow", function () {
                $("#datosPersonal").slideDown("slow");
                $("#txtNumEmp").val(data.Num_Empleado);
                $("#txtRFC").val(data.RFC);
                $("#txtBoleta").removeAttr("required");
                $("#txtGrupo").removeAttr("required");
            });
        } else {
            $("#datosAlumno").slideUp("slow", function () {
                $("#datosPersonal").slideUp("slow");
                $("#txtBoleta").removeAttr("required");
                $("#txtGrupo").removeAttr("required");
            });
        }
        $("#modalEditar").modal("show");
    });
}

function obtener_borrar(tbody, table) {
    $(tbody).on("click", "button.eliminar", function () {
        var data = table.row( $(this).parents("tr") ).data();
        $("#txtidEnviar").val(data.Clave);
        $("#txtnomEnviar").html(data.Nombre + " " + data.Apellidos);
        $("#modalBorrar").modal("show");
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

function manejarErrorAjax(err) {
    console.log(err.responseText);
}