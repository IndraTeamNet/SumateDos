//------------------------------------------------------------------------------------------------------------------------------------------
// VISTA: ConsultaLogin.cshtml.
//------------------------------------------------------------------------------------------------------------------------------------------

$(document).ready(function () {
    $(".header").css({ "visibility": "hidden" });
});


function GetLogin() {

    var vUsuario = $("#txtUsuario").val();
    var vPass = $('#txtPass').val();

    $.ajax({
        url: "/Login/GetLogin",
        type: "POST",
        dataType: "json",
        data: { 'pUsuario': vUsuario, 'pPass': vPass },
        processData: true,
        async: false,
        success: function (bLoginCorrecto) {
            if (bLoginCorrecto) {           
                window.location.href = "../Eventos/ConsultaEventos";
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
