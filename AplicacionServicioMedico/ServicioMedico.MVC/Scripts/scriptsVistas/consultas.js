$(document).ready(function () {
    cargarTabla();
    $("#cmbTipoBuscar").change(function () {
        cargarTabla();
    });

    $("#btnAgregarPaciente").click(function () {
        var urlPaciente = "/Pacientes/NuevoPaciente"
        var nombre = $("#txtNombre").val();
        var apellidos = $("#txtApellidos").val();
        var genero = $("#cmbGenero").val();
        var edad = $("#txtEdad").val();
        var correo = $("#txtCorreo").val();
        var bol = $("#txtBoleta").val();
        var grp = $("#txtGrupo").val();
        var carr = $("#cmbCarrera").val();
        var tipo = $("#cmbTipo").val();
        if (tipo == 1) {
            if (nombre != "" && apellidos != "" && edad != "" && correo != "" && bol != "" && grp != "") {
                var paciente = {
                    idPaciente: null,
                    nombrePaciente: nombre,
                    apellidosPaciente: apellidos,
                    generoPaciente: genero,
                    edadPaciente: edad,
                    correoElectronico: correo,
                    boleta: bol,
                    grupo:grp,
                    carrera: carr,
                    tipoPaciente: tipo
                };
                $.post(urlPaciente, paciente)
                    .done(function (data) {
                        if (data[0] == "Registrado") {
                            $("#txtidEnviar").val(data[1]);
                            $("#txtnomEnviar").val(data[2]);
                            $("#txtedadEnviar").val(data);
                            $("#txtgeneroEnviar").val($(g).html());
                            $("#myModal").modal("hide");
                            $("#myModal").hide();
                            $("#myModal2").modal("show");
                        } else {
                            $("#mensajeError").html(data).css("color", "red");
                        }
                    }).fail(manejarErrorAjax);
            } else {
                $("#mensajeError").html("Faltan Campos por Llenar");
            }

        } else {
            if (nombre != "" && apellidos != "" && edad != "" && correo != "") {
                var paciente = {
                    idPaciente: null,
                    nombrePaciente: nombre,
                    apellidosPaciente: apellidos,
                    generoPaciente: genero,
                    edadPaciente: edad,
                    correoElectronico: correo,
                    boleta: null,
                    grupo: null,
                    carrera: null,
                    tipoPaciente: tipo
                };
                $.post(urlPaciente, paciente)
                    .done(function (data) {
                        if (data[0] == "Registrado") {
                            $("#txtidEnviar").val(data[1]);
                            $("#txtnomEnviar").val(data[2]);
                            $("#txtedadEnviar").val(data[3]);
                            $("#txtgeneroEnviar").val(data[4]);
                            $("#myModal").modal("hide");
                            $("#myModal").hide();
                            $("#myModal2").modal("show");
                        } else {
                            $("#mensajeError").html(data).css("color", "red");
                        }
                    }).fail(manejarErrorAjax);
            } else {
                $("#mensajeError").html("Faltan Campos por Llenar");
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

    /*$("#tbPacientes tr").click(function () {
        alert("click en fila");
    });*/
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
                var nuevafila = "<tr><td style='display:none;'>" +
                val.Clave + "</td><td>" +
                val.Nombre + "</td><td>" +
                val.Apellidos + "</td><td style='display:none;'>" +
                val.Edad + "</td><td style='display:none;'>" +
                val.Genero + "</td><td>" +
                val.Boleta + "</td></tr>";
                filas.append(nuevafila);
            });
        } else {
            nuevosEncabezados = "<tr> <th style='display:none;'>Clave</th> <th>Nombre</th> <th>Apellidos</th> <th style='display:none;'>Edad</th> <th style='display:none;'>Genero</th> </tr>"
            encabezados.append(nuevosEncabezados);
            $.each(data, function (key, val) {
                var nuevafila = "<tr><td style='display:none;'>" +
                val.Clave + "</td><td>" +
                val.Nombre + "</td><td>" +
                val.Apellidos + "</td><td style='display:none;'>" +
                val.Edad + "</td><td style='display:none;'>" +
                val.Genero + "</td></tr>";
                filas.append(nuevafila);
            });
        }
        $("#tbPacientes").DataTable();
    }).fail(manejarErrorAjax);
}

function manejarErrorAjax(err) {
    console.log(err.responseText);
}