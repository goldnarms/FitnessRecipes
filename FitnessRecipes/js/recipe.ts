/// <reference path="../Definitions/knockout-2.2.d.ts" />
/// <reference path="../Definitions/knockback-0.16.d.ts" />
/// <reference path="../Definitions/backbone-0.9.d.ts" />
/// <reference path="../Definitions/jquery-1.8.d.ts" />

(function() {

  $(function() {
    var form, json, recipe, viewModel;
    form = $("#newRecipeForm");
    form.submit(function() {});
    form = $(this);
    recipe = {
      Id: 0,
      Name: $("#name").val(),
      ImageUrl: $("#imageurl").val(),
      WebUrl: $("#weburl").val()
    };
    json = JSON.stringify(recipe);
    $.ajax({
      url: "/api/recipe",
      cache: false,
      data: json,
      type: "POST",
      contentType: "application/json; charset=utf-8",
      statusCode: {
        201: function(data) {
          return viewModel.recipes.push(data);
        }
      }
    });
    return false;
  });

}).call(this);