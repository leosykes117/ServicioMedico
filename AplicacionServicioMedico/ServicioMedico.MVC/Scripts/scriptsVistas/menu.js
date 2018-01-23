$(document).ready(function () {
    if ($("#vistaRep").text() == "False") {
        var MadarMensajeCrear = false;
        var now = moment();
        var diaSemana = now.isoWeekday();//NUMERO DE DIA DE LA SEMANA
        if (diaSemana < 7) {
            var dia = now.date();
            if (dia >= 1 && dia <= 7) {
                var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
                if (now.month() == 0) {
                    var datos = { "mesR": meses[11], "yearR": now.format("YYYY") - 1 };
                } else {
                    var datos = { "mesR": meses[now.month() - 1], "yearR": now.format("YYYY") };
                }
                console.log(datos);
                $.ajax({
                    url: "/Reportes/ReportePF",
                    data: datos,
                    type: "POST",
                    dataType: "json",
                    success: function (result) {
                        if (result == "Hare el reporte") {
                            MadarMensajeCrear = true;
                        }
                    }
                }).done(function (data) {
                    if (MadarMensajeCrear) {
                        $("#alertaReporte").removeClass("invisible");
                    }
                }).fail(function () {

                }).always(function () {

                });
            }
        } else {
            alert("Fin de Semana");
        }
    }
});