$(document).ready(function () {
    var MadarMensajeCrear = false;
    var now = moment();
    var diaSemana = now.isoWeekday();
    if (diaSemana <= 7) {
        var dia = now.date();
        if (dia >= 1 && dia <= 31) {
            var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
            var datos = { "mesR": meses[now.month()-1], "yearR": now.format("YYYY") };
            $.ajax({
                url: "/Reportes/ReportePF",
                data: datos,
                type: "POST",
                dataType: "json",
                success: function (result) {
                    if (result == "Hare el reporte") {
                        MadarMensajeCrear = true;
                    }
                }}).done(function (data) {
                    if(MadarMensajeCrear){
                        $("#alertaReporte").removeClass("invisible");
                    }
                }).fail(function () {

                }).always(function () {

                });
        }
    } else {
        alert("Fin de Semana");
    }
    
});