(function(){
    $(document).ready(function () {
        $('#products').on('click', '.details', OnClick_DivDetails);
    });

    function OnClick_DivDetails() {
        let productId = $(this).parent().attr('data-id');
        window.location.href = "/Product/Edit/" + productId;
    }
}) ();