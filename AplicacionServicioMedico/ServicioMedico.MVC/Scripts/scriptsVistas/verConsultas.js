$(document).ready(function () {
    var comboPac = $("#cmbTipoPaciente").val();
    listarConsultas(comboPac);
    $("#tbConsultas").clear().draw();
});

$("#cmbTipoPaciente").change(function () {
    var cmbPacient = $(this).val()
    listarConsultas(cmbPacient);
    $("#tbConsultas").clear().draw();
    if (cmbPacient == 1) {
        $("#tituloTb").html("Tabla de Consultas Alumnos");
    } else if (cmbPacient == 2) {
        $("#tituloTb").html("Tabla de Consultas Docentes");
    } else if (cmbPacient == 3) {
        $("#tituloTb").html("Tabla de Consultas Personal Escolar");
    } else {
        $("#tituloTb").html("Tabla de Consultas Externos");
    }
});

/*$("#frmEnviarDatosConsulta").on("submit", function () {

});*/


function listarConsultas(cmbTipo) {
    var tipoPaciente = {t : cmbTipo, estatus: 1};
    var tablaConsultas = $("#tbConsultas").DataTable({
        "destroy": true,
        "ajax": {
            "serverSide": true,
            "method": "POST",
            "url": "/Consultas/ListarConsultas",
            "data": tipoPaciente,
            "cache": "false",
            "dataSrc": ""
        },
        "columns": [
            { "data": "NombrePaciente" },
            { "data": "ApellidosPaciente" },
            { "data": "Generos" },
            { "data": "CveDoctor" },
            { "data": "Diagnostico"},
            { "data": "FechaConsulta"},
            { "data": "HoraEntrada" },
            { "data": "HoraSalida" },
            { "data": "DuracionConsulta" },
            { "data": "NombreMedicamento" },
            { "data": "CantidadSuminstrada" },
            { "defaultContent": "<button type='button' class='btn btn-success btn-block editar'><i class='fa fa-pencil-square-o fa-lg' aria-hidden='true'></i></button> <button type='button' class='btn btn-danger btn-block eliminar'><i class='fa fa-trash-o fa-lg' aria-hidden='true'></i></button>" }
        ],
        "columnDefs": [
            {
                "targets": 5,
                "data": "FechaConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    moment.locale("es");
                    return moment(data).format("LL");
                },
                "width": "80px"
            },
            {
                "targets":[6, 7],
                "data": "HoraEntrada, HoraSalida",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("h:mm:ss a");
                },
                "width": "70px"
            },
            {
                "targets": 8,
                "data": "DuracionConsulta",
                "render": function (data, type, full) { // Devuelve el contenido personalizado
                    return moment(data).format("HH:mm:ss");
                }
            }
        ],
        "language": idioma_español
    });
    obtener_editar("#tbConsultas tbody", tablaConsultas);
}

function obtener_editar(tbody, table) {
    $(tbody).on("click", "button.editar", function () {
        var data = table.row($(this).parents("tr")).data();
        $("#txtClave").val(data.IdPaciente);
        $("#txtNombre").val(data.NombrePaciente + " " + data.ApellidosPaciente);
        $("#txtEdad").val(data.EdadPaciente);
        $("#txtGenero").val(data.Generos);
        $("#txtDiagnostico").val(data.Diagnostico);
        $("#txtFecha").val(moment(data.FechaConsulta).format("YYYY-MM-DD"));
        $("#txtHoraEntrada").val(moment(data.HoraEntrada).format("LTS"));
        $("#txtHoraSalida").val(moment(data.HoraSalida).format("LTS"));
        $("#txtDuracion").val( moment(data.DuracionConsulta).format("HH:mm:ss"));
        $("#txtMedicamento").val(data.CveMedicamento);
        $("#txtMotivo").val(data.CveMotivo);
        $("#txtCantidad").val(data.CantidadSuminstrada);
        $("#modalConsultaEditar").modal("show");
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