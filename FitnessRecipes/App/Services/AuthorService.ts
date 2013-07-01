/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
angular.module("authorService", ["ngResource"]).
       factory("AuthorService", ($resource) => {
           return $resource(
               "/api/author/:id",
               { id: "@id" },
               { "update": { method: "PUT" } }
          );
       });