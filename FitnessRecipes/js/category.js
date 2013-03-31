(function () {
    $(function () {
        var category, form, json, viewModel;
        form = $("#newCategoryForm");
        form.submit(function () {
        });
        form = $(this);
        category = {
            Name: $("#name").val()
        };
        json = JSON.stringify(category);
        $.ajax({
            url: "/api/category",
            cache: false,
            data: json,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            statusCode: {
                201: function (data) {
                    return viewModel.categories.push(data);
                }
            }
        });
        false;
        viewModel.categories([]);
        return $.get("/api/category", function (data) {
            return viewModel.categories(data);
        });
    });
}).call(this);
