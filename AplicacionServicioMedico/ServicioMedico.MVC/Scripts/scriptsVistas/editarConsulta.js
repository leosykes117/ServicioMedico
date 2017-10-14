$(document).ready(function () {
    
});

$(function () {
    $('#dtpFecha').datetimepicker({
        format: 'L',
        locale: "es"
    });
    $("#dtpHoraEntrada, #dtpHoraFin").datetimepicker({
        format: 'LTS'
    });
});

$("#frmEditarConsulta").on("submit", function (event) {
    var actualizar = false;
    event.preventDefault();
    var consultaEditada = $(this).serializeFormJSON();
    $.ajax({
        url: $(this).attr("action"),
        method: $(this).attr("method"),
        data: consultaEditada,
        cache: false,
        beforeSend: function () {
            $("#btnEditarConsulta").html("Editando... <i class='fa fa-spinner fa-pulse fa-lg fa-fw'></i>" +
                "<span class='sr-only'>Loading...</span>").attr("disabled", "true");
        }
    }).done(function (data) {
        if (data == "Consulta Actualizada con Exito") {
            actualizar = true;
        }
        $("#snackbar").html(data);
    }).fail(manejarErrorAjax).always(function () {
        $("#btnEditarConsulta").html("Editar Consulta").removeAttr("disabled");
        mostrarSnack();
        if (actualizar) {
            setTimeout("location.href='/Doctores'", 2000);
        }
    });
});

function manejarErrorAjax(err) {
    console.log(err.responseText);
}