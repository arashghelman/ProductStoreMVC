$(document).ready(function () {
    $(".btn-add").click(function () {
        var ref_Category = {};
        ref_Category.title = $("#title").val();
        console.log(ref_Category.title);
        $.ajax({
            method: "POST",
            url: "Category/Create/",
            data: '{ref_Category:' + JSON.stringify(ref_Category) + '}',
            data: JSON.stringify(ref_Category),
            contentType: "application/json; charset=utf-8",
            success: function () {
                console.log('Data added successfully.')
            },
            error: function () {
                console.log('Operation failed.')
            }
        });
    })
})