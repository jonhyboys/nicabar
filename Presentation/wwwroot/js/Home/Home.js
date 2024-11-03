(function () {
    $(document).ready(function () {
        $('#invoices').on('click', '> li .btn-pay', OnClick_BtnPay);
    });

    //Eventos
    function OnClick_BtnPay() {
        let saleId = $(this).attr('data-sale');
        $.ajax({
            url: 'invoice/pay/' + saleId,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                console.log("Respuesta del servidor:", response);
                $('.btn-pay[data-sale="' + response + '"').parents('li').remove();
            },
            error: function (xhr, status, error) {
                console.error("Error en la petición:", error);
            }
        });
    }
})();