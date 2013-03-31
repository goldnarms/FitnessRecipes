(function () {
    $(document).ready(function () {
        $("#tbSearchField").focus();
        var btnSearch = $("#btnSearchIngredients");
        var divAddedIngredients = $("#addedIngredients");
        var mealId = $("#hiMealId").val();
        $("#ingredientCategories").load("/meal/GetIngredientCategories", function () {
            $(".categoryIngredient").bind("click", function () {
                $("#searchResult").load("/ingredient/Categories?id=" + $(this).data("categoryid"), function () {
                    $(".ingredientPopup").bind("click", function () {
                        $("#addModal").reveal();
                        $("#hiIngredientId").val($(this).data("ingredientid"));
                    });
                    $(".superIngredient").click(function () {
                        $(this).parent().siblings(".subIngredient").toggle();
                        $("#hiIngredientId").val($(this).data("ingredientid"));
                    });
                });
            });
        });
        divAddedIngredients.load("/meal/GetIngredientsForMeal?id=" + mealId);
        $("#btnIngredientsAdd").click(function () {
            $.post("/meal/AddIngredientToMeal?mealId=" + mealId + "&ingredientId=" + $("#hiIngredientId").val() + "&quantity=" + $("#tbQuantity").val() + "&quantityId=" + $("#ddlQuantityType").val() + "&optional=" + $("#cbOptional").val(), function () {
                $('#addModal').trigger('reveal:close');
                divAddedIngredients.load("/meal/GetIngredientsForMeal?id=" + mealId);
            });
        });
        btnSearch.bind("click", function () {
            $("#searchResult").load("/ingredient/SearchResult?searchString=" + $("#tbSearchField").val(), function () {
                $(".ingredientPopup").click(function () {
                    $("#addModal").reveal();
                    $("#hiIngredientId").val($(this).data("ingredientid"));
                });
                $(".superIngredient").click(function () {
                    $(this).parent().siblings(".subIngredient").toggle();
                    $("#hiIngredientId").val($(this).data("ingredientid"));
                });
            });
        });
    });
}).call(this);
