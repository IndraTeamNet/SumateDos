//------------------------------------------------------------------------------------------------------------------------------------------
// VISTA: ConsultaEventos.cshtml.
//------------------------------------------------------------------------------------------------------------------------------------------

$(document).ready(function () {

});

function GetEventos() {
    $.ajax({
        url: "/Eventos/GetEventos",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "GET",
        beforeSend: function () {
            $("#spinner").toggle();
        },
        complete: function () {
            $("#spinner").toggle();
        },
        success: function (lstEventos) {
            var tabla = $('#tablaDatos').dataTable();
            if (tabla != null) tabla.fnDestroy();

            $("#theadEventos").css("visibility", "visible");
            $('#tablaDatos').DataTable({
                data: lstEventos,
                dom: 'lBfrtip',
                lengthMenu: [[10, 25, -1], [10, 25, "All"]],
                buttons: [
                    'excel', 'pdf', 'print'
                ]
            });
        },
        error: function () {
            alert('A error');
        }
    });
}

//------------------------------------------------------------------------------------------------------------------------------------------