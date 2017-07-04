var intervalo;

$(document).ready(function () {
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

var motivosC = [];

$("#cmbMotivo").focusout(function () {
    motivosC = $(this).val();
});

//BOTON PARA REGISTRAR CONSULTA
$("#frmNuevaConsulta").on("submit", function (event) {
	event.preventDefault();
    var nuevaConsulta = $(this).serializeFormJSON();
    console.log(nuevaConsulta); 
    /*var nuevaConsulta = [];
    for (var i = 0; i < numMedicamentos; i++) {
        var consulta = $(this).serializeFormJSON();
        nuevaConsulta.push(consulta);
        //console.log(consulta);
    }
    console.log(nuevaConsulta);*/
});

/*INICIALIZACION DEL DATETIME PICKER*/
$(function () {
    $("#dtpFecha").datetimepicker({
        format: "YYYY-MM-DD",
        extraFormats: ['YYYY-MM-DD']
    });
    $("#dtpHoraEntrada, #dtpHoraFin").datetimepicker({
        format: 'LTS'
    });
});

/*NUMERIC UP DOWN*/
$(function () {
    $("#txtNumMot").NumericUpDown(1, 10);
    $("#txtCantidad").NumericUpDown(0, 5);
});

var numListados = 0;
$("#btnAgregarMedicina").click(function () {
    var nomMed = $("#txtMedicamento").val();
    var prescrib = $("#txtPrescripcion").val();
    var cantSum = $("#txtCantidad").val();
    numListados++;
    var li = "<li class='list-group-item'><strong>" + numListados + ".-</strong> <u>"+nomMed+"</u> "+prescrib +"</li>"
    $(li).appendTo( $("#list-group-medicinas") );
    $("#cmbMedicamentos").val(0);
    $("#txtPrescripcion").val("");
    $("#txtCantidad").val(1);
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

function validar() {
    $("#frmNuevaConsulta").find('input, select').each(function () {
        var elemento = this;
        if (elemento.tagName == "INPUT") {
        	$(elemento).css("border-color","#f44242");
        } else if (elemento.tagName == "SELECT") {
            $(elemento).css("border-color", "//#4173f4");
        } else {

        }
        //console.log("elemento.id=" + elemento.id + ", elemento.value=" + elemento.value + " Elemento: " + elemento.tagName);
    });
}