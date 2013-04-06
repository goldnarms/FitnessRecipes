(function () {
    $(document).ready(function () {
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
    (function (e, t, n) {
        "use strict";
        e.fn.foundationTabs = function (n) {
            var r = e.extend({
callback: e.noop            }, n), i = function (t) {
                var n = t.closest("dl").find("dd.active"), r = t.children("a").attr("href") + "Tab";
                r = r.replace(/^.+#/, "#") , n.removeClass("active") , t.addClass("active") , e(r).closest(".tabs-content").children("li").removeClass("active").hide() , e(r).css("display", "block").addClass("active");
            };
            e(document).on("click.fndtn", "dl.tabs dd a", function (t) {
                i(e(this).parent("dd"));
            }) , t.location.hash && (i(e('a[href="' + t.location.hash + '"]').parent("dd")) , r.callback());
        };
    })}).call(this);
