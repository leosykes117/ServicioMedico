$(document).ready(function () {
    CargarTabla();
    
});

/*function CargarTabla() {
    var t = $("#cmbTipoBuscar").val();
    $("#tbPacientes").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Pacientes/ListadoGeneral",
            "data": {
                tipo: 1
            },
            "type": "POST",
            "dataSrc": ""
        },
        "columns": [
            { "data": "Clave" },
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Edad" },
            { "data": "Genero" },
            { "data": "Boleta" },
            { "data": "Grupo" },
            { "data": "Carrera" },
            { "data": "Fecha" },
            { "data": "CURP" },
            { "data": "Calle" },
            { "data": "Num_Int" },
            { "data": "Num_Ext" },
            { "data": "Colonia" },
            { "data": "CP" },
            { "data": "id_Del_Mun" },
            { "data": "id_Edo" },
            { "data": "Telefono" },
            { "data": "Correo" },
        ]
    });
}*/