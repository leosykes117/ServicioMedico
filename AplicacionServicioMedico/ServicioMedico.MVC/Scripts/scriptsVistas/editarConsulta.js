$(document).ready(function () {
    $.get("/Consultas/ListadoMotivos", function (data) {
        $.each(data, function (id, item) {
            $("#cmbMotivo").append("<option value='" + item.CveMot + "'>" + item.Motivo + "</option>");
        });
        var mot = $("#cveMotivo").html();
        $("#cmbMotivo").val(mot);
    }).done(function () {
        $.get("/Medicamentos/ListadoMedicamentos", function (data) {
            $.each(data, function (id, item) {
                $("#cmbMedicamentos").append("<option value='" + item.CveMed + "'>" + item.Medicamento + "</option>");
            });
            var med = $("#cveMedicamento").html();
            $("#cmbMedicamentos").val(med);
        }).fail(manejarErrorAjax);
    }).fail(manejarErrorAjax);
});

$(function () {
    $('#dtpFecha').datetimepicker({
        format: 'YYYY-MM-DD',
        locale: "es",
        extraFormats: ['YYYY-MM-DD']
    });
    $("#dtpHoraEntrada, #dtpHoraFin").datetimepicker({
        format: 'LTS',
        extraFormats: ['LTS']
    });
});

$(function () {
    var numericUD = $(".aumentar").parent().prev();
    /*$(numericUD).val(1);*/

    $(".aumentar").click(function () {
        var cant = $(numericUD).val();
        if (cant >= 1 && cant < 5) {
            cant++;
            $(numericUD).val(cant);
        } else {
            $(numericUD).val(1);
        }
    });

    $(".disminuir").click(function () {
        var cant = $(numericUD).val();
        if (cant == 1 || cant == "") {
            $(numericUD).val(5);
        } else {
            cant--;
            $(numericUD).val(cant);
        }
    });

    $(numericUD).keyup(function () {
        var cant = $(numericUD).val();
        if (cant > 1 && cant <= 5 || cant == "") {
            //$(numericUD).val(cant);
        }
        else {
            $(numericUD).val(1);
        }
    });

    $(numericUD).keypress(function (event) {
        var ascii = event.which;
        if (ascii >= 49 && ascii <= 53) {

        } else {
            event.preventDefault();
        }
    });
});

$("#frmEditarConsulta").on("submit", function (event) {
    var mensajeJson;
    event.preventDefault();
    var actualizarConsulta = $(this).serializeFormJSON();
    var consultaEditada = JSON.stringify(actualizarConsulta);
    console.log(consultaEditada);
    $.ajax({
        url: "/Consultas/Actualizar",
        method: "POST",
        data: actualizarConsulta,
        cache: false,
        beforeSend: function () {
            $("#btnEditarConsulta").html("Editando... <i class='fa fa-spinner fa-pulse fa-lg fa-fw'></i>" +
                "<span class='sr-only'>Loading...</span>").attr("disabled", true);
        }
    }).done(function (data) {
        if (data == "") {
            mensajeJson = "Ocurrio un error inesperado en la aplicación";
            $("#snackbar").html("Ocurrio un error inesperado en la aplicación");
        } else {
            mensajeJson = data;
            $("#snackbar").html(data);
        }
    }).fail(manejarErrorAjax).always(function () {
        $("#btnEditarConsulta").html("Editar Consulta").attr('disabled', false);
        mostrarSnack();
        if (mensajeJson == "Consulta Actualizada con Exito" || mensajeJson == "Ocurrio un error inesperado en la aplicación") {
            setTimeout("location.href='/Doctores'", 2000);
        } else {

        }
    });
});

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

function manejarErrorAjax(err) {
    console.log(err.responseText);
}