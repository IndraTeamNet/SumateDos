//------------------------------------------------------------------------------------------------------------------------------------------
// VISTA: ConsultaLogin.cshtml.
//------------------------------------------------------------------------------------------------------------------------------------------

$(document).ready(function () {

});

function GetUsuario() {

    var vUsuario = $("#txtUsuario").val();
    var vPass = $('#txtPass').val();

    $.ajax({
        url: "/Login/GetUsuario",
        type: "GET",
        dataType: "json",
        data: { 'pUsuario': vUsuario, 'pPass': vPass },
        processData: false,
        async: false,
        success: function (bLoginCorrecto) {
            if (bLoginCorrecto) {
                alert("funca");
            }
            else {
                //$("#txtModalInfo").empty();
                //$("#txtModalInfo").append("El alumno seleccionado no posee cuotas generadas, verifique que se encuentre matriculado.");
                //$("#modalInfo").modal('show');
            }
        },
        error: function (xhr, status, errorThrown) {
            //$("#txtModalInfo").empty();
            //$("#txtModalInfo").append("Se produjo un error al consultar las cuotas del alumno seleccionado.");
            //$("#modalInfo").modal('show');
        }
    });
}
