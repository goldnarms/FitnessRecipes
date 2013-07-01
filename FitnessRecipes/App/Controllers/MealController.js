var App;
(function (App) {
    var MealMembersCtrl = (function () {
        function MealMembersCtrl($scope, $http, $location, $routeParams) {
            this.$scope = $scope;
        }
        MealMembersCtrl.$inject = [
            "$scope", 
            "$http", 
            "$location", 
            "$routeParams"
        ];
        return MealMembersCtrl;
    })();
    App.MealMembersCtrl = MealMembersCtrl;    
})(App || (App = {}));
