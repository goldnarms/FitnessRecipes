var App;
(function (App) {
    'use strict';
    var FrontpageController = (function () {
        function FrontpageController($scope, mealService) {
            this.$scope = $scope;
            this.mealService = mealService;
            $scope.meals = mealService.query();
        }
        FrontpageController.prototype.injection = function () {
            return [
                '$scope', 
                'mealService', 
                FrontpageController
            ];
        };
        return FrontpageController;
    })();
    App.FrontpageController = FrontpageController;    
})(App || (App = {}));
