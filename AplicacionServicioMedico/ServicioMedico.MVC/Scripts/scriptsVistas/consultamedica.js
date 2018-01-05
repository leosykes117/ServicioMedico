var intervalo;
var elementoLiActual = null;
var expresionR = /(([A-Za-z]+\s)([+]\s[A-Za-z]+)|([A-Za-z]+\s))(([-]\s[0-9]{2,4})([glmr]{1,2}))/;

$(document).ready(function () {
    /*$.get("/Consultas/ListadoMotivos", function (data) {
        $.each(data, function (id, item) {
            $("#cmbMotivo").append("<option value='" + item.CveMot + "'>" + item.Motivo + "</option>");
        });
    }).fail(manejarErrorAjax);*/
    $("#dtpFecha").val(moment().format("YYYY-MM-DD"));
    $("#dtpHoraEntrada").val(moment().format("LTS"));
    $("#dtpHoraFin").val(moment().format("LTS"));
    $("#cmbMotivo").select2({
        placeholder: "Motivos de Consulta",
        theme: "bootstrap",
        ajax: {
            url: "/Motivos/ListadoMotivos",
            dataType: "json",
            type: "POST",
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.DescripcionMotivo,
                            id: item.IdMotivo
                        }
                    })
                };
            },
            cache: true,
            escapeMarkup: function (markup) { return markup; },
            minimumInputLength: 1
        }
    });
});

$(function () {
    intervalo = setInterval(CambiarHora, 1000);
});


/*BORRA EL LI DEL LISTADO DE MEDICAMENTOS*/
function borrarLi(li_borrar) {
    $(li_borrar).parent().remove();
}

/*EDITA EL LI DEL LISTADO DE MEDICAMENTOS*/
function editarLi(li_editar) {
    elementoLiActual = $(li_editar).parent();
    //$("#cmbMedicamento").val($(li_editar).siblings("span.idMedicamento").text()).change();
    $("#txtMedicamento").val($(li_editar).siblings("u").text());
    $("#txtPrescripcion").val($(li_editar).siblings("span.prescrib").text());
    $("#txtCantidad").val($(li_editar).siblings("span.cantSum").text());
}


/*RELOJ DE LA CONSULTA*/
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

/*NUMERIC UP DOWN*/
$(function () {
    $("#txtCantidad").NumericUpDown(0, 5);
});

/*INICIALIZA EL BS CONFIRMATION*/
$('[data-toggle=confirmation]').confirmation({
    rootSelector: '[data-toggle=confirmation]',
    title: "¿Seguro que deseas realizar la consulta",
    btnOkClass: "btn-xs btn-info",
    btnOkLabel: "Si",
    singleton: true
});

//POPOVER DE MOTIVOS DE LA CONSULTA
$(".motivosConsulta").popover({
    title: "Motivos",
    content: function () {
        var data = { cve: $(this).siblings("span").text() };
        var contenido = $("<ol>", { "class": "list-group" });
        $.ajax({
            url: "/Motivos/MotivosConsultas",
            method: "POST",
            data: data,
            cache: false,
            success: function (data) {
                $.each(data, function (id, item) {
                    contenido.append("<li class='list-group-item'>" + item.DescripcionMotivo + "</li>");
                });
            }
        });
        return contenido;
    },
    placement: "bottom",
    html: true
});

$(".medicamentosConsulta").popover({
    title: "Medicamentos",
    content: function () {
        var clave = $(this).siblings("span").text();;
        return detallesConsulta(clave);
    },
    placement: "bottom",
    html: true
});

function detallesConsulta(consulta) {
    var data = { cve: consulta };
    var contenido = $("<ol>", { "class": "list-group" });
    $.ajax({
        url: "/Medicamentos/MedicamentosConsultas",
        method: "POST",
        data: data,
        cache: false,
        success: function (data) {
            $.each(data, function (id, item) {
                contenido.append("<li class='list-group-item'>" +
                                    "<strong>" + item.NombreMedicamento + "</strong> " +
                                    "Cantidad: <strong>" + item.CantidadSuministrada + "</strong> " +
                                    "Prescripcion: <strong>" + item.PrescripcionMedica + "</strong></li>");
            });
        }
    });
    return contenido;
}

/*VALIDA LA REGEX*/
$("#txtMedicamento").focusout(function () {
    if (!expresionR.test($(this).val())) {
        $("#nuevoMedicamento").addClass("has-error");
        $("#helpBlock").removeClass("hidden");
    } else {
        $("#nuevoMedicamento").removeClass("has-error");
        $("#helpBlock").addClass("hidden");
    }
});

var numListados = 0;
$("#btnAgregarMedicina").click(function () {
    /*var medicamento = $("#cmbMedicamento");
    var nomMed, idMed;*/
    var idMed = 0;
    var nomMed = $("#txtMedicamento").val();
    var prescrib = $("#txtPrescripcion").val();
    var cantSum = $("#txtCantidad").val();

    /*if ($(medicamento).val() != "Otro") {
        idMed = $(medicamento).val();
        nomMed = $("option:selected", medicamento).text();

    } else {
        idMed = 0;
        nomMed = $("#txtMedicamento").val();
    }*/

    numListados++;
    var li = "<li class='list-group-item'>" +
                "<button type='button' class='close' aria-label='Close' onclick='editarLi(this)'><i class='fa fa-pencil-square'></i></button>" +
                "<button type='button' class='close' aria-label='Close' onclick='borrarLi(this)'><i class='fa fa-times-circle'></i></button>" +
                "<strong>" + numListados +
                ".-</strong> <span class='idMedicamento' style='display:none;'>" + idMed + "</span> <u>" + nomMed + "</u> " +
                "<span class='prescrib'>" + prescrib + "</span> <span class='cantSum' style='display:none;'>" + cantSum + "</span> </li>";
    if (elementoLiActual == null) {
        if (!validarListaMed(idMed)) {
            $(li).sort().appendTo($("#list-group-medicinas"));
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
    $("#list-group-medicinas li span.idMedicamento").each(function (index) {
        //console.log( id + ": " + $( this ).text() );
        if (id == 0) {
            //alert("El medicamento no esta en la lista (Otro)");
            siAgregar = false;
            return true;
        }
        else if (id == $(this).text()) {
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

$("#frmNuevaConsulta").on("submit", function (event) {
    event.preventDefault();
    var resultado;
    var motivosConsultas = [];
    $.each($('#cmbMotivo :selected'), function () {
        var objeto = {
            "IdMotivo": $(this).val(),
            "DescripcionMotivo": $(this).text()
        };
        motivosConsultas.push(objeto);
    });
    var nuevaConsulta = $(this).serializeFormJSON();
    nuevaConsulta.MotivosConsultas = motivosConsultas;
    nuevaConsulta.MedicamentosConsultas = jsonMedicamentos();
    if ($("#ckbReceta").is(':checked')) {
        direccion = "/Consultas/ConReceta"
    }
    $.ajax({
        url: $(this).attr("action"),
        type: $(this).attr("method"),
        data: nuevaConsulta,
        cache: false,
        beforeSend: function () {
            $("#btnRegistrarConsulta").html("Guardando... <i class='fa fa-spinner fa-pulse fa-lg fa-fw'></i>" +
                "<span class='sr-only'>Loading...</span>").attr("disabled", true);
        }
    }).done(function (data) {

        resultado = data;
        $("#snackbar").html(data);

    }).fail(manejarErrorAjax).always(function () {
        $("#btnRegistrarConsulta").html("Terminar Consulta").attr('disabled', false);
        mostrarSnack();
        if (resultado == "La Consulta se Registro Correctamente") {
            setTimeout("location.href='/Doctores'", 2000);
        }
    });
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

function manejarErrorAjax(err) {
    console.log(err.responseText);
}