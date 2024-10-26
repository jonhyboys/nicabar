(() => {
    var saleResume = {
        products: [],
        total: 0
    };

    $(document).ready(function () {
        $('.showProducts-button').on('click', OnClick_ShowProduct);
        $('.product-list').on('click', '.minus-button', OnClick_MinusButton);
        $('.product-list').on('click', '.plus-button', OnClick_PlusButton);
    });

    function OnClick_MinusButton() {
        let product = getProduct(this);
        if (product.saleCount > 0) { updateCount(product, -1); }
        //updateProductSelected(parent);
    }

    function OnClick_PlusButton() {
        let product = getProduct(this);
        if (product.inventoryCount > 0) { updateCount(product, 1); }
        //updateProductSelected(parent);
    }

    function OnClick_ShowProduct() {
        let productList = $(this).parent().next();
        if ($(productList).hasClass('hide')) {
            showProducts(productList);
            $(this).html('-');
        }
        else {
            hideProducts(productList);
            $(this).html('+');
        }
    }

    function showProducts(productList) {
        $('.product-list').addClass('hide');
        $('.showProducts-button').html('+');
        $(productList).removeClass('hide');
    }

    function hideProducts(productList) {
        $(productList).addClass('hide');
    }

    function updateProductSelected(parentObj) {
        let id = $(parentObj).parent().attr('data-id');
        $('#product').val(id);
    }

    function updateCount(product, plusValue) {
        product.saleCount += plusValue;
        product.inventoryCount -= plusValue;
        $('li[data-id="' + product.id + '"]').find('strong.to-sale').text(product.saleCount);
        $('li[data-id="' + product.id + '"]').find('em.inventory').text(product.inventoryCount);
        updateSaleResume(product);
    }

    //Product
    function getProduct(target) {
        return {
            id: $(target).parents('li').attr('data-id'),
            name: 'Coca',
            saleCount: parseInt($(target).siblings('span').find('strong.to-sale').text(), 10),
            inventoryCount: parseInt($(target).siblings('span').find('em.inventory').text(), 10),
            price: parseFloat($(target).parents('li').attr('data-price'))
        };
    }

    //SaleResume
    function updateSaleResume(product) {
        var productIndex = getProductIndexInSaleResume(product.id);
        if (productIndex > -1) {
            if (product.saleCount == 0) {
                saleResume.products.splice(productIndex, 1);
                removeProductFromSaleResumeView(product.id);
            }
            else {
                saleResume.products[productIndex] = product;
                updateProductToSaleResumeView(product);
            }            
        }
        else {
            saleResume.products.push(product);
            addProductToSaleResumeView(product);
        }
        console.log(saleResume);
    }

    function getProductIndexInSaleResume(id) { return saleResume.products.findIndex(item => item.id === id); }

    function updateProductToSaleResumeView(product) {
        $('#sale-resume li[data-id="' + product.id + '"] strong').text(product.saleCount);
    }

    function addProductToSaleResumeView(product) {
        $('#sale-resume > ul').append('<li data-id="' + product.id + '"><span>' + product.name + '</span><strong>' + product.saleCount + '</strong></li>');
    }

    function removeProductFromSaleResumeView(productId) {
        $('#sale-resume li[data-id="' + productId + '"]').remove();
    }
})();