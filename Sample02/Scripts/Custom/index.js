$(document).ready(function () {
    $(".btn-add").click(function () {
        var ref_Category = {};
        ref_Category.title = $("#title").val();
        console.log(ref_Category.title);
        $.ajax({
            method: "POST",
            url: "category/create/",
            ref_Category: ref_Category
        });
    })
})