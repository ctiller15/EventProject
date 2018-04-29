console.log("Connected!!!");

const app = angular.module("main", ["ngRoute"]);

app.config(function ($routeProvider) {
    // events. Index route.
    $routeProvider.when("/events", {
        templateUrl: "/Scripts/app/views/events.html",
        controller: "allEventsController"
    });

    // events. Show route.
    $routeProvider.when("/events/:eventID", {
        templateUrl: "/Scripts/app/views/eventDetail.html",
        controller: "eventDetailController"
    });

    $routeProvider.otherwise({ redirectTo: "/events" });
});

app.controller("allEventsController", ["$scope", "$http", function ($scope, $http) {
    $scope.searchParams = {
        Title: "",
    }

    $scope.searchForEvents = () => {
        console.log($scope.searchParams);
        let url = "/api/events";
        if ($scope.searchParams.Title) {
            url += `?Title=${$scope.searchParams.Title}`;
        }

        $http({
            method: "GET",
            url: url,
        }).then(res => {
            $scope.events = res.data;
            console.log($scope.events);
        });
    }

    $scope.searchForEvents();
}]);

app.controller("eventsDetailController", ["$scope", "$http", function ($scope, $http) {
    console.log("On the events detail controller!");
}]);