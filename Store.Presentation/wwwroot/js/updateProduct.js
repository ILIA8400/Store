$(document).ready(function () {
    $('[data-bs-target="#exampleModal"]').on('click', function () {
        var productId = $(this).data('productid');
        $('#ProductId').val(productId);
    });
});
