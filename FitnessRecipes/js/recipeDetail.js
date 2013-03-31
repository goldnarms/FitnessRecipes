(function () {
    $(document).ready(function () {
        $("a#single_image").fancybox();
        var btnSearchRecipe, mealId;
        btnSearchRecipe = $("#btnSearchRecipe");
        mealId = $("#hiMealId").val();
        btnSearchRecipe.bind("click", function (e) {
            $("#searchResult").load("/recipe/SearchResult?searchString=" + $("#tbSearchField").val());
        });
        $("#btnAddToFavorites").bind("click", function () {
            $.post("/meal/AddToFavorite?mealId=" + mealId);
        });
        $("#btnDelete").bind("click", function () {
            $.post("/meal/DeleteMeal?id=" + mealId);
        });
    });
}).call(this);
