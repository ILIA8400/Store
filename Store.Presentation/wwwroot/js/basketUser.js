// Get Total Price
$.ajax({
    type: "get",
    url: "/Basket/GetTotalPrice",
    success: function (response) {
        $(".total-price").append(numberWithCommas(response));
    }
});


// Functions
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}