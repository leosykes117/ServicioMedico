var intervalo;
var elementoLiActual = null;
var expresionR = /(([A-Za-z]+\s)([+]\s[A-Za-z]+)|([A-Za-z]+\s))(([-]\s[0-9]{2,4})([glmr]{1,2}))/;

$(document).ready(function () {
	$("#dtpFecha").val(moment().format("YYYY-MM-DD"));
	$("#dtpHoraEntrada").val(moment().format("LTS"));
	$("#dtpHoraFin").val(moment().format("LTS"));
    $("#cmbMedicamento").select2({
        placeholder: "Busque un medicamento",
        theme: "bootstrap",
        language: "es",
        allowClear: true
    });
    $("#cmbMotivo").select2({
        placeholder: "Motivos de Consulta",
        theme: "bootstrap",
        language: "es"
    });
});

//BOTON PARA REGISTRAR CONSULTA
$("#frmNuevaConsulta").on("submit", function (event) {
    event.preventDefault();
    if( $("#list-group-medicinas li").length > 0){
       
        var motivosConsultas = [];
        $.each($('#cmbMotivo :selected'), function() {
                    
            var objeto = {
                "IdMotivo": $(this).val(), 
                "DescripcionMotivo": $(this).text()
            };
            motivosConsultas.push(objeto);
        });
        var nuevaConsulta = $(this).serializeFormJSON();
        nuevaConsulta.MotivosConsultas = motivosConsultas;
        nuevaConsulta.MedicamentosConsultas = jsonMedicamentos();
        console.log(nuevaConsulta);
        $('#list-group-medicinas').popover("destroy");
    
    } else {
        $("#list-group-medicinas").popover("show");
    }
});

function jsonMedicamentos() {
    var medConsultas = [];
    $("#list-group-medicinas li").each(function (index) {
        /*var longitudCompleta = $(this).children("u").text().length; //longitud completa de medicamento
        var posicionguion = $(this).children("u").text().indexOf("-"); //encuentra el guion que separa el nombre de la dosis
        var nomMedicamento = $(this).children("u").text().substring(0, (posicionguion - 1)); //obtiene solo el nombre del medicamento
        var dosisMedicamento = $(this).children("u").text().substring((posicionguion + 1), longitudCompleta); //obtiene solo la dosis*/
        var objeto = {
            //"IdMedicamento": $(this).children("span.idMedicamento").text(), 
            "NombreMedicamento": $(this).children("u").text(),
            //"DosisMedicamento": dosisMedicamento,
            "PrescripcionMedica": $(this).children("span.prescrib").text(),
            "CantidadSuministrada": $(this).children("span.cantSum").text()
        };
        medConsultas.push(objeto);
    });
    return medConsultas;
}

$(function () {
	intervalo = setInterval(CambiarHora, 1000);
});

$('[data-toggle=confirmation]').confirmation({
    rootSelector: '[data-toggle=confirmation]',
    title: "¿Seguro que deseas realizar la consulta",
    btnOkClass: "btn-xs btn-info",
    btnOkLabel: "Si",
    singleton: true
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
            if ( $(ctrlDes).attr("id") == "dtpFecha" ){
                $(ctrlDes).val( moment().format("YYYY-MM-DD") );
            } else {
                $(ctrlDes).val( moment().format("LTS"));
            }
        }

    }
});

function borrarLi(li_borrar) {
    $(li_borrar).parent().remove();
}

function editarLi(li_editar) {
    elementoLiActual = $(li_editar).parent();
    $("#cmbMedicamento").val( $(li_editar).siblings("span.idMedicamento").text() ).change();
    $("#txtPrescripcion").val( $(li_editar).siblings("span.prescrib").text() );
    $("#txtCantidad").val( $(li_editar).siblings("span.cantSum").text() );
}

$('.motivosConsulta').popover({
    title: "Motivos", 
    content: function () {
        return $(this).siblings("span").text();
    }, 
    placement: "bottom",
    html: true
});

/*$("#cmbMotivo").change(function () {
    var valorMotivo = $(this).val();
    var textoMotivo = $("option:selected", this).text();
    var siAgregar;
    $("#listaMotivos li span").each(function( index ) {
        console.log( valorMotivo + ": " + $( this ).text() );
        if ( valorMotivo == $( this ).text() ) {
            alert("El motivo ya esta en la lista");
            siAgregar = true;
            return false;
        } else {
            alert("El motivo no esta en la lista");
            siAgregar = false;
            return true;
        } 
    });
    console.log(siAgregar);
    if(!siAgregar){
        alert("Agregalo");
        var li = "<li class='list-group-item'><button type='button' class='close' aria-label='Close' onclick='borrarLi(this)'><i class='fa fa-times-circle' aria-hidden='true'></i></button> <span>" + valorMotivo + "</span> " + textoMotivo + "</li>";
        $(li).appendTo( $("#listaMotivos") );
    }
});*/

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

$("#cmbMedicamento").change(function () {
    //alert( $(this).val() );
    if ( $(this).val() === "Otro") {
        $("#nuevoMedicamento").removeClass("hidden");
    } else {
        $("#nuevoMedicamento").addClass("hidden");
    }
});

$("#txtMedicamento").focusout(function () {
    if(!expresionR.test( $(this).val() )) {
        $("#nuevoMedicamento").addClass("has-error");
        $("#helpBlock").removeClass("hidden");
    } else{
        $("#nuevoMedicamento").removeClass("has-error");
        $("#helpBlock").addClass("hidden");
    }
});

//AGREAGR MEDICAMENTO A LA LISTA
var numListados = 0;
$("#btnAgregarMedicina").click(function () {
    var medicamento = $("#cmbMedicamento");
    var nomMed, idMed;
    var prescrib = $("#txtPrescripcion").val();
    var cantSum = $("#txtCantidad").val();

    if( $(medicamento).val() != "Otro" ) {
        idMed = $(medicamento).val();
        nomMed = $("option:selected", medicamento).text();

    } else {
        idMed = 0;
        nomMed = $("#txtMedicamento").val();
    }
    
    numListados++;
    var li = "<li class='list-group-item'>"+
                "<button type='button' class='close' aria-label='Close' onclick='editarLi(this)'><i class='fa fa-pencil-square'></i></button>" +
                "<button type='button' class='close' aria-label='Close' onclick='borrarLi(this)'><i class='fa fa-times-circle'></i></button>" +
                "<strong>" + numListados +
                ".-</strong> <span class='idMedicamento'>" + idMed + "</span> <u>" + nomMed + "</u> " + 
                "<span class='prescrib'>" + prescrib + "</span> <span class='cantSum'>" + cantSum + "</span> </li>";
    if (elementoLiActual == null) {
        if (!validarListaMed(idMed)) {
            $(li).sort().appendTo( $("#list-group-medicinas") );
        }
    } else {
        $(elementoLiActual).children("span.idMedicamento").text(idMed);
        $(elementoLiActual).children("u").text(nomMed);
        $(elementoLiActual).children("span.prescrib").text(prescrib);
        $(elementoLiActual).children("span.cantSum").text(cantSum);
        elementoLiActual = null;
    }
    $("#txtMedicamento").val(null);
    $("#txtPrescripcion").val(null);
    $("#txtCantidad").val(0);
    $("#cmbMedicamento").val(0).change();
});

function validarListaMed(id) {
    var siAgregar;
    $("#list-group-medicinas li span.idMedicamento").each(function( index ) {
        //console.log( id + ": " + $( this ).text() );
        if (id == 0) {
            //alert("El medicamento no esta en la lista (Otro)");
            siAgregar = false;
            return true;
        }
        else if ( id == $( this ).text() ) {
            alert("El medicamento ya esta en la lista");
            siAgregar = true;
            return false;
        } else {
            //alert("El medicamento no esta en la lista");
            siAgregar = false;
            return true;
        } 
    });
    console.log(siAgregar);
    return siAgregar;
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