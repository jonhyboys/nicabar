document.addEventListener('DOMContentLoaded', function () {
    var productList = document.getElementById('product-list');
    var product = document.getElementById('product');

    productList.addEventListener('click', function (event) {
        if (event.target && event.target.nodeName === 'LI') {
            var productId = event.target.getAttribute('data-id');
            product.value = productId;
        }
    });
});

$('#product-list').on('click', 'li', function () {
    let counter = $(this).children('strong').eq(0);
    let newCounterValue = parseInt($(counter).html()) + 1; 
    $(counter).html(newCounterValue);
});