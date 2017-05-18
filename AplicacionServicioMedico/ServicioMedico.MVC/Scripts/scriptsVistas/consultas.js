$(document).ready(function () {

    cargarTabla();

    $("#cmbTipoBuscar").change(function () {
        var tabla = $("#tbPacientes").dataTable().api();
        tabla.destroy();
        cargarTabla();
    });

    $("#btnAgregarPaciente").click(function ()  {
        //var urlPaciente = "/Pacientes/AgregarAlumno"
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
                    "Municipio": mun,
                    "Estado": est,
                    "Celular": cel,
                    "Telefono": tel,
                    "CorreoElectronico": correo,
                    "TipoPaciente":tipo,
                    "Boleta": bol,
                    "Grupo": grp,
                    "Carrera": carr
                };
                /*$.each(alumno, function (i, item) {
                    console.log(item);
                });*/
                $.ajax({
                    url: "/Pacientes/AgregarAlumno",
                    method: "POST",
                    data: alumno,
                    cache: false,
                    beforeSend: function () {
                        $('#btnAgregarPaciente').html("Enviando...").addClass("disabled").attr("disabled", true);
                    }
                }).done(function (data) {
                    if (data[0] == "Registrado") {
                        $("#txtidEnviar").val(data[1]);
                        $("#txtnomEnviar").val(data[2]);
                        $("#txtedadEnviar").val(data[3]);
                        $("#txtgeneroEnviar").val(data[4]);
                        $("#myModal").modal("hide");
                        $("#myModal2").modal("show");
                    } else {
                        $("#mensajeError").html(data);
                    }
                }).fail(manejarErrorAjax).always(function () {
                    $('#btnAgregarPaciente').html("Agregar Paciente").removeClass("disabled").attr("disabled", false);
                });
            } else {
                $("#mensajeError").html("Faltan Campos por Llenar");
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
                    "Municipio": mun,
                    "Estado": est,
                    "Celular": cel,
                    "Telefono": tel,
                    "CorreoElectronico": correo,
                    "TipoPaciente": tipo,
                    "NumEmpleado": numE,
                    "Rfc": rfc
                };
                /*$.each(personal, function (i, item) {
                    console.log(item);
                });*/
                $.ajax({
                    url: "/Pacientes/AgregarPersonal",
                    method: "POST",
                    data: personal,
                    cache: false,
                    beforeSend: function () {
                        $('#btnAgregarPaciente').html("Enviando...").addClass("disabled").attr("disabled", true);
                    }
                }).done(function (data) {

                    if (data[0] == "Registrado") {
                        $("#txtidEnviar").val(data[1]);
                        $("#txtnomEnviar").val(data[2]);
                        $("#txtedadEnviar").val(data[3]);
                        $("#txtgeneroEnviar").val(data[4]);
                        $("#myModal").modal("hide");
                        $("#myModal2").modal("show");
                    } else {
                        $("#mensajeError").html(data);
                    }
                }).fail(manejarErrorAjax).always(function () {
                    $('#btnAgregarPaciente').html("Agregar Paciente").removeClass("disabled").attr("disabled", false);
                });
               

            } else {
                $("#mensajeError").html("Faltan Campos por Llenar");
                $('#btnAgregarPaciente').html("Agregar Paciente").removeClass("disabled").attr("disabled", false);
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
                    "Municipio": mun,
                    "Estado": est,
                    "Celular": cel,
                    "Telefono": tel,
                    "CorreoElectronico": correo,
                    "TipoPaciente": tipo,
                };
                /*$.each(personal, function (i, item) {
                    console.log(item);
                });*/
                $.ajax({
                    url: "/Pacientes/AgregarExterno",
                    method: "POST",
                    data: pExterno,
                    cache: false,
                    beforeSend: function () {
                        $('#btnAgregarPaciente').html("Enviando...").addClass("disabled").attr("disabled", true);
                    }
                }).done(function (data) {

                    if (data[0] == "Registrado") {
                        $("#txtidEnviar").val(data[1]);
                        $("#txtnomEnviar").val(data[2]);
                        $("#txtedadEnviar").val(data[3]);
                        $("#txtgeneroEnviar").val(data[4]);
                        $("#myModal").modal("hide");
                        $("#myModal2").modal("show");
                    } else {
                        $("#mensajeError").html(data);
                    }
                }).fail(manejarErrorAjax).always(function () {
                    $('#btnAgregarPaciente').html("Agregar Paciente").removeClass("disabled").attr("disabled", false);
                });


            } else {
                $("#mensajeError").html("Faltan Campos por Llenar");
                $('#btnAgregarPaciente').html("Agregar Paciente").removeClass("disabled").attr("disabled", false);
            }
        }
    }); 

    $("#tbPacientes").on('dblclick', 'tbody tr', function (evt) {
        var fila = $("#tbPacientes tr").index(this);
        var columna = ($('#tbPacientes').find('tbody > tr')[fila-1]);
        var id = $(columna).children("td")[0];
        var nom = $(columna).children("td")[1];
        var ape = $(columna).children("td")[2];
        var e = $(columna).children("td")[3];
        var g = $(columna).children("td")[4];
        //var valor = $(id).html() + " " + $(nom).html() + " " + $(ape).html();
        //alert(valor);
        $("#txtidEnviar").val($(id).html());
        $("#txtnomEnviar").val($(nom).html() + " " + $(ape).html());
        $("#txtedadEnviar").val($(e).html());
        $("#txtgeneroEnviar").val($(g).html());
        $("#myModal2").modal("show");
    });

    $("#btnCancelarConsulta").click(function () {
        location.reload();
    });
});

function cargarTabla() {
    var t = $("#cmbTipoBuscar").val();
    var url = "/Pacientes/ListadoGeneral";
    var data = { tipo: t };
    $.post(url, data).done(function (data) {
        var encabezados = $("#tbPacientes thead");
        var filas = $("#tbPacientes tbody");
        var nuevosEncabezados;
        encabezados.html(""); filas.html("");

        if (t == 1) {
            nuevosEncabezados = "<tr> <th style='display:none;'>Clave</th> <th>Nombre</th> <th>Apellidos</th> <th style='display:none;'>Edad</th> <th style='display:none;'>Genero</th> <th>Boleta</th> </tr>"
            encabezados.append(nuevosEncabezados);
            $.each(data, function (key, val) {
                var nuevafila = "<tr data-toggle='tooltip' data-placement='top' title='Haz doble click para pasarme a consulta!'><td style='display:none;'>" +
                val.Clave + "</td><td>" +
                val.Nombre + "</td><td>" +
                val.Apellidos + "</td><td style='display:none;'>" +
                val.Edad + "</td><td style='display:none;'>" +
                val.Genero + "</td><td>" +
                val.Boleta + "</td></tr>";
                filas.append(nuevafila);
            });
        } else if(t == 2 || t == 3) {
            nuevosEncabezados = "<tr> <th style='display:none;'>Clave</th> <th>Nombre</th> <th>Apellidos</th> <th style='display:none;'>Edad</th> <th style='display:none;'>Genero</th> <th>Clave de Empleado</th> </tr>"
            encabezados.append(nuevosEncabezados);
            $.each(data, function (key, val) {
                var nuevafila = "<tr data-toggle=tooltip' data-placement='top' title='Haz doble click para pasarme a consulta'><td style='display:none;'>" +
                val.Clave + "</td><td>" +
                val.Nombre + "</td><td>" +
                val.Apellidos + "</td><td style='display:none;'>" +
                val.Edad + "</td><td style='display:none;'>" +
                val.Genero + "</td><td>" +
                val.Num_Empleado + "</td></tr>";
                filas.append(nuevafila);
            });
        } else {
            nuevosEncabezados = "<tr> <th style='display:none;'>Clave</th> <th>Nombre</th> <th>Apellidos</th> <th style='display:none;'>Edad</th> <th style='display:none;'>Genero</th> </tr>"
            encabezados.append(nuevosEncabezados);
            $.each(data, function (key, val) {
                var nuevafila = "<tr data-toggle=tooltip' data-placement='top' title='Haz doble click para pasarme a consulta'><td style='display:none;'>" +
                val.Clave + "</td><td>" +
                val.Nombre + "</td><td>" +
                val.Apellidos + "</td><td style='display:none;'>" +
                val.Edad + "</td><td style='display:none;'>" +
                val.Genero + "</td></tr>";
                filas.append(nuevafila);
            });
        }
        $("#tbPacientes").DataTable({
            "oLanguage": {
                "sProcessing": "Procesando...",
                "sLengthMenu": 'Mostrar <select>' +
                    '<option value="10">10</option>' +
                    '<option value="20">20</option>' +
                    '<option value="30">30</option>' +
                    '<option value="40">40</option>' +
                    '<option value="50">50</option>' +
                    '<option value="-1">All</option>' +
                    '</select> registros',
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando del (_START_ al _END_) de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sSearchPlaceholder": "Nombre, Apellido o Boleta",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Por favor espere - cargando...",
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
        });
    }).fail(manejarErrorAjax);
    $('[data-toggle="tooltip"]').tooltip();
}

function manejarErrorAjax(err) {
    console.log(err.responseText);
}

$(function () {
    $("#dtpFechaNac").datetimepicker({
        format: 'DD/MM/YYYY',
        extraFormats: ['DD/MM/YY']
        //defaultDate: fecha.getDate() + "/" + (fecha.getMonth() + 1) + "/" + fecha.getFullYear()
    });
});