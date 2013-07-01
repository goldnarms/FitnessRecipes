/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
angular.module("dietService", ["ngResource"]).
       factory("DietService", ($resource) => {
           return $resource(
               "/api/diet/:id",
               { id: "@id" },
               { "update": { method: "PUT" } }
          );
       });