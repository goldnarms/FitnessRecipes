var App;
(function (App) {
    'use strict';
    var MealService = (function () {
        function MealService($resource) {
            return $resource("/api/meal/:id", {
                id: "@id"
            }, {
                "update": {
                    method: "PUT"
                }
            });
        }
        MealService.prototype.injection = function () {
            return [
                'ngResource', 
                MealService
            ];
        };
        return MealService;
    })();
    App.MealService = MealService;    
})(App || (App = {}));
