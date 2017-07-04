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
    locale: "es",
    extraFormats: ['YYYY-MM-DD']
});

$("#dtpFechaNac").focusout(function () {
    var nacimiento = moment($(this).val());
    var hoy = moment();
    var edad = hoy.diff(nacimiento, "years");
    $("#txtEdad").val(edad);
});

$("#btnAgregarPaciente").click(function () {
    var nombre = $("#txtNombre").val();
    var apellidos = $("#txtApellidos").val();
    var genero = $("#cmbGenero").val();
    var fecha = $("#dtpFechaNac").val();
    var edad = $("#txtEdad").val();
    var curp = $("#txtCurp").val();
    var calle = $("#txtCalle").val();
    var nInt = $("#txtInt").val();
    var nExt = $("#txtExt").val();
    var col = $("#txtColonia").val();
    var codigop = $("#txtCP").val();
    var mun = $("#cmbMunicipio").val();
    var est = $("#cmbEstado").val();
    var cel = $("#txtCelular").val();
    var tel = $("#txtTelefono").val();
    var correo = $("#txtCorreo").val();
    var tipo = $("#cmbTipo").val();

    if (tipo == 1) {
        var bol = $("#txtBoleta").val();
        var grp = $("#txtGrupo").val();
        var carr = $("#cmbCarrera").val();
        if (nombre != "" && apellidos != "") {

            var alumno = {
                "IdPaciente": null,
                "NombrePaciente": nombre,
                "ApellidosPaciente": apellidos,
                "GeneroPaciente": genero,
                "FechaNac": fecha,
                "EdadPaciente": edad,
                "Curp": curp,
                "Calle": calle,
                "NumInt": nInt,
                "NumExt": nExt,
                "Colonia": col,
                "Cp": codigop,
                "DelMun": mun,
                "Estado": est,
                "Celular": cel,
                "Telefono": tel,
                "CorreoElectronico": correo,
                "TipoPaciente": tipo,
                "Boleta": bol,
                "Grupo": grp,
                "Carrera": carr
            };
            $.ajax({
                url: "/Pacientes/AgregarAlumno",
                method: "POST",
                data: alumno,
                cache: false,
                beforeSend: function () {
                    $("#btnAgregarPaciente").html("Agregando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
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
                $("#btnAgregarPaciente").html("Agregar Paciente").attr('disabled', false);
            });
        } else {
            $("#mensajeError").html("Faltan Campos por Llenar");
            $("#btnAgregarPaciente").html("Agregar Paciente").attr('disabled', false);
        }

    } else if (tipo == 2 || tipo == 3) {
        var numE = $("#txtNumEmp").val();
        var rfc = $("#txtRFC").val();
        if (nombre != "" && apellidos != "") {
            var personal = {
                "IdPaciente": null,
                "NombrePaciente": nombre,
                "ApellidosPaciente": apellidos,
                "GeneroPaciente": genero,
                "FechaNac": fecha,
                "EdadPaciente": edad,
                "Curp": curp,
                "Calle": calle,
                "NumInt": nInt,
                "NumExt": nExt,
                "Colonia": col,
                "Cp": codigop,
                "DelMun": mun,
                "Estado": est,
                "Celular": cel,
                "Telefono": tel,
                "CorreoElectronico": correo,
                "TipoPaciente": tipo,
                "NumEmpleado": numE,
                "Rfc": rfc
            };
            $.ajax({
                url: "/Pacientes/AgregarPersonal",
                method: "POST",
                data: personal,
                cache: false,
                beforeSend: function () {
                    $("#btnAgregarPaciente").html("Agregando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
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
                $("#btnAgregarPaciente").html("Agregar Paciente").attr('disabled', false);
            });


        } else {
            $("#mensajeError").html("Faltan Campos por Llenar");
            $("#btnAgregarPaciente").html("Agregar Paciente").attr('disabled', false);
        }
    } else {
        if (nombre != "" && apellidos != "") {
            var pExterno = {
                "IdPaciente": null,
                "NombrePaciente": nombre,
                "ApellidosPaciente": apellidos,
                "GeneroPaciente": genero,
                "FechaNac": fecha,
                "EdadPaciente": edad,
                "Curp": curp,
                "Calle": calle,
                "NumInt": nInt,
                "NumExt": nExt,
                "Colonia": col,
                "Cp": codigop,
                "DelMun": mun,
                "Estado": est,
                "Celular": cel,
                "Telefono": tel,
                "CorreoElectronico": correo,
                "TipoPaciente": tipo,
            };
            $.ajax({
                url: "/Pacientes/AgregarExterno",
                method: "POST",
                data: pExterno,
                cache: false,
                beforeSend: function () {
                    $("#btnAgregarPaciente").html("Agregando...<i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
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
                $("#btnAgregarPaciente").html("Agregar Paciente").attr('disabled', false);
            });


        } else {
            $("#mensajeError").html("Faltan Campos por Llenar");
            $("#btnAgregarPaciente").html("Agregar Paciente").attr('disabled', false);
        }
    }
});

$("#frmEditarPaciente").on("submit", function (e) {
    e.preventDefault();
    var tPaciente = $("#cmbTipo").val();
    if (tPaciente == 1) {
        var aluActualizar = $(this).serializeFormJSON();
        console.log(aluActualizar);
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
                $("#snackbar").html(data);
            } else {
                $("#snackbar").html("Ocurrio un error inesperado");
            }
        }).fail(manejarErrorAjax).always(function () {
            $("#modalEditar").modal("hide");
            $("#btnEditar").html("Editar Datos").attr('disabled', false);
            mostrarSnack();
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
                $("#snackbar").html(data);
            } else {
                $("#snackbar").html("Ocurrio un error inesperado");
            }
        }).fail(manejarErrorAjax).always(function () {
            $("#modalEditar").modal("hide");
            $("#btnEditar").html("Editar Datos").attr('disabled', false);
            mostrarSnack();
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
                $("#snackbar").html(data);
            } else {
                $("#snackbar").html("Ocurrio un error inesperado");
            }
        }).fail(manejarErrorAjax).always(function () {
            $("#modalEditar").modal("hide");
            $("#btnEditar").html("Editar Datos").attr('disabled', false);
            mostrarSnack();
            setTimeout("location.reload()", 3000);
        });
    }
});

$("#btnEliminarPaciente").click(function () {
    var pacEliminar = { "IdPaciente": $("#txtidEnviar").val(), EstatusPaciente: 0 }
    $.ajax({
        url: "/Pacientes/ActualizarEstatus",
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

var listarAlumnos = function(){
    var tablaAlu = $("#tbAlumnos").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbAlumnos tbody", tablaAlu);
}

var listarDoc = function(){
    var tablaDoc = $("#tbDocentes").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbDocentes tbody", tablaDoc);
}

var listarPaae = function () {
    var tablaPaae = $("#tbPaaes").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbPaaes tbody", tablaPaae);
}

var listarExternos = function(){
    var tablaExt = $("#tbExternos").DataTable({
        "destroy":true,
        "language": idioma_español
    });
    obtener_editar("#tbExternos tbody", tablaExt);
}

var obtener_editar = function (tbody, table){
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