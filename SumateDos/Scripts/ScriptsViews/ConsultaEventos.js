//------------------------------------------------------------------------------------------------------------------------------------------
// VISTA: ConsultaEventos.cshtml.
//------------------------------------------------------------------------------------------------------------------------------------------

$(document).ready(function () {
    $('.DisfrazBody').addClass("FondoIngreso");
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
                    'excel', 'print'
                ,{
                    extend: 'pdfHtml5',
                    orientation: 'landscape',
                    pageSize: 'LEGAL',
                     customize: function (doc) {
                        doc.defaultStyle.fontSize = 7; //<-- set fontsize to 16 instead of 10 
                    },  
                      exportOptions: {
                        columns: [0,1, 2, 3, 4, 5, 7, 8, 9, 10,11,13,14,15,16,17,18,19,20]
                    }
                    }               
                ]
            });
        },
        error: function () {
            alert('A error');
        }
    });
}

//------------------------------------------------------------------------------------------------------------------------------------------