// Get All Products
$(function () {
    $.ajax({
        url: "/Wallet/GetUserBalance",
        success: function (balance) {
            $("#wallet-balance-user").text(numberWithCommas(balance));
        }
    });
});

// functions
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}


