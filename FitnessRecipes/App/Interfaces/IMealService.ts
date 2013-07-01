/// <reference path="../_references.ts" />
module App {
    export interface IMealService extends ng.resource.IResource{
        query(): App.Meal[];
    }
}