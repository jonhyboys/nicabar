(function () {
    $(document).ready(function () {
        $('#tables').on('click', '.details', OnClick_DivDetails);
    });

    function OnClick_DivDetails() {
        let tableId = $(this).parent().attr('data-id');
        window.location.href = "/Table/Edit/" + tableId;
    }
})();