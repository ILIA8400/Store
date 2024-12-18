$(function () {
    console.log("ssssss")
    $.get("https://localhost:44313/Product/GetProducts",
        product => {
            
            data.forEach(product => {
                console.log(product)
                $("#product_list").append
                    (
                        `<div class="col-md-6 col-lg-4 mb-5">
                        <div class="card">
                            <div class="p-3">
                                <img src="images/71YDXFhIuWL._AC_SL1500_.jpg" class="card-img-top" alt="">
                            </div>
                            <div class="card-body text-center">
                                <p class="card-title h5 mb-3">${product.ProductName}</p>
                                <p>${product.Description}</p>
                            </div>
                            <div class="card-footer d-flex justify-content-between align-items-center">
                                <p class="mb-0">قیمت : ${product.Price}</p>
                                <div class="text-center">
                                    <form method="post">
                                        <div class="btn-group-sm">
                                            <button class="btn btn-dark">افزودن به سبد</button>
                                            <input placeholder="تعداد" min="1" style="width: 30%;" type="number">
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>`
                    )
            });
        }
    );
});