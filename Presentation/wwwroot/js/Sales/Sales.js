(() => {
    var saleResume = {
        products: []
    };

    $(document).ready(function () {
        $('.showProducts-button').on('click', OnClick_ShowProduct);
        $('.product-list').on('click', '.minus-button', OnClick_MinusButton);
        $('.product-list').on('click', '.plus-button', OnClick_PlusButton);
        $('#btn-save').on('click', OnClick_SaveButton);
    });

    //Events
    function OnClick_MinusButton() {
        let product = getProduct(this);
        if (product.saleCount > 0) { updateProductCount(product, -1); }
    }

    function OnClick_PlusButton() {
        let product = getProduct(this);
        if (product.inventoryCount > 0) { updateProductCount(product, 1); }
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

    function OnClick_SaveButton() { postOrder(); }

    //Products
    function showProducts(productList) {
        $('.product-list').addClass('hide');
        $('.showProducts-button').html('+');
        $(productList).removeClass('hide');
    }

    function hideProducts(productList) { $(productList).addClass('hide'); }

    function updateProductCount(product, plusValue) {
        product.saleCount += plusValue;
        product.inventoryCount -= plusValue;
        $('li[data-id="' + product.id + '"]').find('strong.to-sale').text(product.saleCount);
        $('li[data-id="' + product.id + '"]').find('em.inventory').text(product.inventoryCount);
        updateSaleResume(product);
    }

    function getProduct(target) {
        return {
            id: $(target).parents('li').attr('data-id'),
            name: $(target).parent().siblings('div').text(),
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

    function getOrder() {
        let products = [];
        $('#sale-resume > ul > li').each(function (index, product){
            products.push({
                Product: $(product).attr('data-id'),
                Quantity: parseInt($(product).find('strong').text(), 10)
            });
        });
        return {
            Sale: $('#sale-resume').attr('data-id') || null,
            Table: $('#sale-resume').attr('data-table'),
            Order: {
                Id: null,
                Products: products,
                Note: ''
            }
        };
    }

    function clearOrder(saleId) {
        $('#sale-resume').attr('data-id', saleId);
        $('#sale-resume > ul').html('');
        $('strong.to-sale').text('0');
        saleResume.products = [];
    }

    //Server
    function postOrder() {
        $.ajax({
            url: 'add',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(getOrder()),
            success: function (response) {
                console.log("Respuesta del servidor:", response);
                clearOrder(response);
            },
            error: function (xhr, status, error) {
                console.error("Error en la petición:", error);
            }
        });
    }
})();