var app = angular.module('app', ['ngRoute', 'ngResource']);


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'Templates/home.html',
            controller: 'HomeCtrl'
        });
}]);


app.factory('appFactory', function ($http, $rootScope) {
    var service = {
        getPlaces: function() {
            var promise = $http({
                method: 'GET',
                url: '/api/place'
            });
            return promise;
        },

        getPeople: function () {
            var promise = $http({
                method: 'GET',
                url: '/api/person'
            });
            return promise;
        },


        createPlace: function (location, city) {
            var promise = $http({
                method: 'POST',
                url: '/api/Place/',
                data: {
                    Name: location
                }
            });
            return promise;
        }
    };

    return service;
});


function HomeCtrl($scope, appFactory) {
    $scope.name = "Quang";

    $scope.places = [];

    appFactory.getPlaces().then(function (d) {
        $scope.places = d.data;
    });

    appFactory.getPeople().then(function (d) {
        $scope.people = d.data;
    });

    //appFactory.createPlace("some new place");
}