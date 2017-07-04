var intervalo;

$(document).ready(function () {
    $.get("/Consultas/ListadoMotivos", function (data) {
        $.each(data, function (id, item) {
            $("#cmbMotivo").append("<option value='" + item.CveMot + "'>" + item.Motivo + "</option>");
        });
    }).done(function () {
        $.get("/Medicamentos/ListadoMedicamentos", function (data) {
            $.each(data, function (id, item) {
                $("#cmbMedicamentos").append("<option value='" + item.CveMed + "'>" + item.Medicamento + "</option>");
            });
        }).fail(manejarErrorAjax);
    }).fail(manejarErrorAjax);
    $("#dtpFecha").val(moment().format("YYYY-MM-DD"));
    $("#dtpHoraEntrada").val(moment().format("LTS"));
    $("#dtpHoraFin").val(moment().format("LTS"));
});

$(function () {
    intervalo = setInterval(CambiarHora, 1000);
});

function CambiarHora() {
    $("#dtpHoraFin").val(moment().format("LTS"));
}

//ACTIVAR Y DESCATIVAR DATETIME PICKERS
$(".switchDt").click(function () {
    var ctrlDes = $(this).parent().prev();
    if ($(ctrlDes).attr("id") == "dtpHoraFin") {
        var desactivado = $(ctrlDes).attr("readonly");

        if (desactivado) {
            $(ctrlDes).removeAttr("readonly");
            $(this).html("Desactivar");
            clearInterval(intervalo);
        } else {
            $(ctrlDes).attr("readonly", "readonly");
            $(this).html("Activar");
            intervalo = setInterval(CambiarHora, 1000);
        }

    } else {
        var desactivado = $(ctrlDes).attr("readonly");

        if (desactivado) {
            $(ctrlDes).removeAttr("readonly");
            $(this).html("Desactivar");
        } else {
            $(ctrlDes).attr("readonly", "readonly");
            $(this).html("Activar");
        }

    }
});

/*INICIALIZACION DEL DATETIME PICKER*/
$(function () {
    $("#dtpFecha").datetimepicker({
        format: "YYYY-MM-DD",
        locale: "es",
        extraFormats: ['YYYY-MM-DD']
    });
    $("#dtpHoraEntrada, #dtpHoraFin").datetimepicker({
        format: 'LTS'
    });
});

$("#cmbMedicamentos").change(function () {
    if ($(this).val() == 0) {
        $("#cantPastillas").slideUp();
    } else {
        $("#cantPastillas").slideDown();
    }
});


/*NUMERIC UP DOWN*/
$(function () {
    var numericUD = $(".aumentar").parent().prev();
    $(numericUD).val(1);

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

$("#frmNuevaConsulta").on("submit", function (event) {
    event.preventDefault();
    var nuevaConsulta = $(this).serializeFormJSON();
    $.ajax({
        url: "/Consultas/Guardar",
        method: "POST",
        data: nuevaConsulta,
        cache: false,
        beforeSend: function () {
            $("#btnRegistrarConsulta").html("Guardando... <i class='fa fa-spinner fa-pulse fa-lg fa-fw'></i>" +
                "<span class='sr-only'>Loading...</span>").attr("disabled", true);
        }
    }).done(function (data) {

        if (data == "La Consulta se Registro Correctamente") {
            $("#snackbar").html(data);
        } else {
            $("#snackbar").html(data);
        }

    }).fail(manejarErrorAjax).always(function () {
        $("#btnRegistrarConsulta").html("Terminar Consulta").attr('disabled', false);
        mostrarSnack();
        setTimeout("location.href='/Doctores/Index'", 2000);
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