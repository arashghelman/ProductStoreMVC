function sendAjaxRequest (url, type, data) {
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

var ref_CategoryViewModel = new Object();
var inputs = new Object();

function createCategory() {
    ref_CategoryViewModel.title = $("#title").val();
    sendAjaxRequest('/Category/Create/', 'POST', ref_CategoryViewModel).done(function () {
        $("#table-div").load(location.href + " #table-div>*", "");
    });
};

function deleteCategory() {
    ref_CategoryViewModel.id = inputs.id;
    sendAjaxRequest('/Category/Delete/', 'POST', ref_CategoryViewModel).done(function () {
        $("#table-div").load(location.href + " #table-div>*", "");
        $("#title").val("");
    });
};

function editCategory() {
    ref_CategoryViewModel.id = inputs.id;
    ref_CategoryViewModel.title = $("#title").val();
    sendAjaxRequest('/Category/Edit/', 'POST', ref_CategoryViewModel).done(function () {
        $("#table-div").load(location.href + " #table-div>*", "");
        $("#title").val("");
    });
};

$(document).ready(function () {

    $("#btn-add").click(createCategory);
    $("#btn-remove").click(deleteCategory);
    $("#btn-edit").click(editCategory);

    $("input[type='checkbox']").change(function () {
        var $this = $(this);
        if (this.checked) {
            $("input[type='checkbox']").attr("disabled", true);
            $this.removeAttr("disabled");
            $this.closest("tr").addClass("row-selected");
            var id = $this.closest("tr").find("#id-cell").text().trim();
            var title = $this.closest("tr").find("#title-cell").text().trim();
            inputs = {
                id: id,
                title: title
            };
            $("#title").val(inputs.title);
            console.log(inputs);
        }
        if (!this.checked) {
            $("input[type='checkbox']").attr("disabled", false);
            $this.closest("tr").removeClass("row-selected");
            $("#title").val("");
        }
    })    
})