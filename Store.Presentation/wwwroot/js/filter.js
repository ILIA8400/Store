// Get All Products
$.ajax({
    type: "get",
    url: "/Product/GetProducts",
    success: function (product) {
        product.forEach(p => {           
            $("#product_list").append(productDiv(p))
        });
    }
});

// Get All Category Options
$.ajax({
    type: "get",
    url: "https://localhost:44313/Category/GetCategories",
    success: function (response) {
        response.forEach(category => {
            $("#category-select").append(
                `<option value="${category.categoryId}">${category.categoryName}</option>`
            );
        });
    }
});

// Get All Brands Options
$.ajax({
    type: "get",
    url: `https://localhost:44313/Brand/GetBrands`,
    success: function (response) {
        response.forEach(brand => {
            $("#brand-select").append(
                `<option value="${brand.brandId}">${brand.brandName}</option>`
            );
        });
    }
});



// Loading by Category
$("#category-select").on("change", function () {
    const selectedCategoryId = $(this).val();
    if (selectedCategoryId) {
        getBrandsById(selectedCategoryId);
    }
    $.get(`https://localhost:44313/Product/GetProductsByBrandAndCategory/0_${selectedCategoryId}`,
        product => {
            if (product.length == 0) {
                $("#product_list").append(`<p class="no-product">محصولی یافت نشد</p>`);
            }
            else {
                $("#product_list").remove(".no-product");
            }

            $("#product_list").empty();
            product.forEach(product => {
                $("#product_list").append(productDiv(product))
            });
        }
    );
});

// Loading by brand
$("#brand-select").on("change", function () {
    const selectedBrandId = $(this).val();
    const selectedCategoryId = $("#category-select").find("option:selected").val();
    $.get(`https://localhost:44313/Product/GetProductsByBrandAndCategory/${selectedBrandId}_${selectedCategoryId}`,
        product => {
            if (product.length == 0) {
                $("#product_list").append(`<p class="no-product">محصولی یافت نشد</p>`);
            }
            else {
                $("#product_list").remove(".no-product");
            }
            $("#product_list").empty();
            product.forEach(product => {
                $("#product_list").append(productDiv(product))
            });
        }
    );
});

// Loading by price
$("#price-select").on("change", function () {
    const selectedPriceId = $(this).val();

    $(".mb-5").show();

    $(".price").each(function () {
        const price = parseInt($(this).text().replace(/,/g, "").trim(), 10);

        if (selectedPriceId == "1" && price >= 20000000) {
            $(this).closest(".mb-5").hide();
        } else if (selectedPriceId == "2" && (price < 20000000 || price > 40000000)) {
            $(this).closest(".mb-5").hide();
        } else if (selectedPriceId == "3" && price <= 40000000) {
            $(this).closest(".mb-5").hide();
        }
    });

    if ($("#product_list").find(".price:visible").length == 0) {
        if ($("#product_list").find(".no").length == 0)
        $("#product_list").append(`<p class="no">محصولی یافت نشد</p>`);
    }
    else {
        $("#product_list").find(".no").remove();
    }
});


// Functions :
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function productDiv(product) {
    return `<div class="col-md-6 col-lg-4 mb-5">
                        <div class="card h-100 product-card">
                            <div class="p-3">
                                <img src="images/${product.medias[0].path}" class="card-img-top" alt="">
                            </div>
                            <div class="card-body text-center">
                                <p class="card-title h5 mb-3">${product.productName}</p>
                                <p>${product.description}</p>
                            </div>
                            <div class="card-footer d-flex justify-content-between align-items-center">
                                <p class="mb-0"><span class="price">${numberWithCommas(product.price)}</span> تومان</p>
                                <div class="text-center">
                                    <form method="post" action="Basket/AddToBasket">
                                        <input type="hidden" name="ProductId" value="${product.productId}"/>
                                        <div class="btn-group-sm">
                                            <button type="submit" class="btn btn-dark">افزودن به سبد</button>
                                            <input placeholder="تعداد" min="1" style="width: 30%;" type="number" name="Quentity">
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>`;
} 
function getBrandsById(categoryId) {
    $("#brand-select").empty().append(`<option value="0">-- برند --</option>`);
    $.ajax({
        type: "get",
        url: `https://localhost:44313/Brand/GetBrands/${categoryId}`,
        success: function (response) {
            response.forEach(brand => {
                $("#brand-select").append(
                    `<option value="${brand.brandId}">${brand.brandName}</option>`
                );
            });
        }
    });
}


