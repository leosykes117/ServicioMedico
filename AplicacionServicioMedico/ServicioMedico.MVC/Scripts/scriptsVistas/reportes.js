﻿var fechaActual;
var disabled = false;
var mesActual, yearActual;

$(document).ready(function () {
    fechaActual = new Date();
    mesActual = fechaActual.getMonth() + 1;
    yearActual = fechaActual.getFullYear();
    console.log(mesActual);
});

$("#frmReporte").on("submit", function (event) {
    event.preventDefault();
    var json = $(this).serializeFormJSON();
    $.ajax({
        type: $(this).attr("method"),
        url: $(this).attr("action"),
        data: json,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            $("#btnBuscarReporte").html("Buscando... <i class='fa fa-spinner fa-spin fa-lg fa-fw'></i>").attr('disabled', true);
        }
    }).done(function (data) {
        var filaReporte = $("table tbody tr").html("");
        /* Vemos que la respuesta no este vacía y sea una arreglo */
        if (data.length != 0 && $.isArray(data)) {
            /* Recorremos tu respuesta con each */
            $.each(data, function (index, value) {
                /* Vamos agregando a nuestra tabla las filas necesarias */
                $(filaReporte).append("<td>" + value.AlumnosH + "</td><td>" + value.AlumnosM +
                                       "</td><td>" + value.DocentesH + "</td><td>" + value.DocentesM +
                                       "</td><td>" + value.PaaesH + "</td><td>" + value.PaaesM +
                                       "</td><td>" + value.ExternosH + "</td><td>" + value.ExternosM +
                                       "</td><td>" + value.SubtotalH + "</td><td>" + value.SubtotalM + "</td><td>" + value.Total + "</td>");
            });
        } else {
            $(filaReporte).append("<td colspan='11' class='text-center'><strong>No se atendieron personas en este mes<strong></td>")
        }
    }).fail(function () {

    }).always(function () {
        $("#btnBuscarReporte").html("Ver Reporte <i class='fa fa-list-alt'></i>").removeAttr('disabled');
    });
});

$("#cmbMesBuscar").change(function () {
    if ($("#cmbYearBuscar").val() == yearActual) {
        if ($(this).val() >= mesActual) {
            disabled = true;
            alert("Este mes aun no pasa");
            $("#btnBuscarReporte").attr("disabled", true);
        } else {
            if (disabled) {
                disabled = false;
                $("#btnBuscarReporte").removeAttr("disabled");

            }
        }
    } else {
        if (disabled) {
            disabled = false;
            $("#btnBuscarReporte").removeAttr("disabled");

        }
    }
    console.log(disabled);
});

$("#cmbYearBuscar").change(function () {
    if ($(this).val() != yearActual) {
        if (disabled) {
            disabled = false;
            $("#btnBuscarReporte").removeAttr("disabled");

        }
    } else {
        if ($("#cmbMesBuscar").val() >= mesActual) {
            disabled = true;
            alert("Este mes aun no pasa");
            $("#btnBuscarReporte").attr("disabled", true);
        }
    }
});