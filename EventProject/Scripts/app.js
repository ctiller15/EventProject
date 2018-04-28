console.log("Connected!!!");

const app = angular.module("main", ["ngRoute"]);

app.config(function ($routeProvider) {
    // events.
    $routeProvider.when("/events", {
        templateUrl: "/Scripts/app/views/events.html",
        controller: "allEventsController"
    })
})

app.controller("allEventsController", ["$scope", "$http", function ($scope, $http) {
    $scope.message = "Hello!!!";
    console.log("Hello!");

    $http({
        method: "GET",
        url: "/api/events"
    }).then(res => {
        $scope.events = res.data;
        console.log($scope.events);
    })
}])