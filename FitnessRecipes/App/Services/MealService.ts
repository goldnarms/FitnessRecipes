/// <reference path='../_references.ts' />

module App {
    'use strict';
    export class MealService {

        public injection(): any[] {
            return ['ngResource', MealService]
        }

        constructor($resource) {
            return $resource("/api/meal/:id",
                          { id: "@id" },
                          { "update": { method: "PUT" } }
                     );
        }
    }
}