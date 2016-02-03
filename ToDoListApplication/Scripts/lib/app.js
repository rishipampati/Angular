(function () {

    var TodoApp = angular.module("TodoApp", ["ngResource", "ngRoute", "ngAnimate"]);

    TodoApp.factory('ToDoListItems', function ($resource) {
        return $resource('http://localhost:65212/api/ToDoListItems/:id', { id: '@id' }, { update: { method: 'PUT' } });//Url of the Web API
    });


    //Controller to handle viewing list and deleting 'to do' list items
    var ListViewDeleteController = function ($scope, $location, ToDoListItems) {
        //pulls up list of all available "to do's"
        $scope.todos = ToDoListItems.query();

        //performs deletion and fade out animation 
        $scope.delete = function () {
            var id = this.todo.Id;
            ToDoListItems.delete({ id: id }, function () {
                $('#todo_' + id).fadeOut();
            });

        };

    };

    //Controller to handle creation of new list items
    var CreateController = function ($scope, $location, ToDoListItems) {
        //'action' parameter used to update relavent text on UI
        $scope.action = "Add";

        $scope.save = function () {

            ToDoListItems.save($scope.item, function () {
                $location.path('/');
            });
        };
    };

    //Controller to handle update to list items, makes use of same page as 'add'
    var EditController = function ($scope, $location, $routeParams, ToDoListItems) {
        //'action' parameter used to update relavent text on UI
        $scope.action = "Update";
        var id = $routeParams.editId;
        $scope.item = ToDoListItems.get({ id: id });

        $scope.save = function () {

            ToDoListItems.update({ id: id }, $scope.item, function () {
                $location.path('/');
            });
        };

    };
   
    //routing
    TodoApp.config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "list.html",
                controller: ListViewDeleteController
            })
            .when("/new", {
                templateUrl: "details.html",
                controller: CreateController
            })
             .when("/edit/:editId", {
                 templateUrl: "details.html",
                 controller: EditController
             })
            .otherwise({
                redirectTo: "/"
            });

    });


    ////Revisit this section of code to optimize sort functionality
    //TodoApp.controller('TodoApp', ['$scope', function($scope)])
    //{
    //    $scope.predicate = 'Id';
    //    $scope.reverse = true;
    //    $scope.order = function($scope, predicate) {
    //        $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
    //        $scope.predicate = predicate;
    //    };
    //};


}());