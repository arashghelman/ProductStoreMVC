function sendAjaxRequest(url, type, data) {
    return $.ajax({
        url: url,
        type: type,
        data: JSON.stringify(data),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    }).fail(function (error) {
        console.log(error);
    });
};

var ref_ProductViewModel = new Object();
var inputs = new Object();
var selectedCategory;

function createProduct() {
    ref_ProductViewModel.categoryRef = selectedCategory;
    ref_ProductViewModel.title = $("#title").val();
    ref_ProductViewModel.unitPrice = $("#unitPrice").val();
    ref_ProductViewModel.discount = $("#discount").val();
    ref_ProductViewModel.quantity = $("#quantity").val();
    console.log(ref_ProductViewModel);
    sendAjaxRequest('/Product/Create/', 'POST', ref_ProductViewModel);
}
function deleteProduct() {
    ref_ProductViewModel.productId = inputs.productId;
    console.log(ref_ProductViewModel);
    sendAjaxRequest('/Product/Delete/', 'POST', ref_ProductViewModel);
}
function editProduct() {
    ref_ProductViewModel.productId = inputs.productId;
    ref_ProductViewModel.categoryRef = selectedCategory;
    ref_ProductViewModel.title = $("#title").val();
    ref_ProductViewModel.unitPrice = $("#unitPrice").val();
    ref_ProductViewModel.discount = $("#discount").val();
    ref_ProductViewModel.quantity = $("#quantity").val();
    sendAjaxRequest('/Product/Edit/', 'POST', ref_ProductViewModel);
}

$(document).ready(function () {

    $("#categoryRef").change(function () {
        selectedCategory = $(this).children("option:selected").val();
    })

    $("#btn-add").click(createProduct);
    $("#btn-remove").click(deleteProduct);

    $("#btn-select").click(function () {
        var $this = this;
        var divContent = $this.parentElement.children;
        console.log(divContent);
        inputs = {
            category: divContent[0].innerText,
            title: divContent[1].innerText,
            productId: divContent[2].innerText,
            unitPrice: divContent[6].innerText,
            discount: divContent[8].children[0].innerText,
            quantity: divContent[9].innerText
        }
        console.log(inputs);
        $("#title").val(inputs.title);
        $("#unitPrice").val(inputs.unitPrice);
        $("#discount").val(inputs.discount);
        $("#quantity").val(inputs.quantity);
    })

})