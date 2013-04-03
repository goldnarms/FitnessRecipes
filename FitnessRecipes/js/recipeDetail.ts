/// <reference path="../Definitions/jquery-1.8.d.ts" />
/// <reference path="../Definitions/fancybox-2.1.d.ts" />

(function() {

  $(document).ready(function() {
    var btnSearchRecipe, mealId;
    btnSearchRecipe = $("#btnSearchRecipe");
    mealId = $("#hiMealId").val();
    btnSearchRecipe.bind("click", function(e) {
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
