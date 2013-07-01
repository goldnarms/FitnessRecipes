/// <reference path="../../Scripts/typings/angularjs/angular-resource.d.ts" />
/// <reference path="../../Scripts/typings/underscore/underscore.d.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module App {

    export class MealMembersCtrl {
        static $inject = ["$scope", "$http", "$location", "$routeParams"];
        constructor(private $scope: MealScope, $http, $location, $routeParams) {
}
}

    export interface MealScope extends ng.IScope {

    }
}