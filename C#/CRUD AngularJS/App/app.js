var app = angular.module('app', ['ngRoute', 'ngResource']);


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'Templates/home.html',
            controller: 'HomeCtrl'
        })
        .when('/profile', {
            templateUrl: 'Templates/profile.html',
            controller: 'ProfileCtrl'
        });
}]);


app.factory('appFactory', function ($http, $rootScope) {
    var service = {
        getPeople: function () {
            var promise = $http({
                method: 'GET',
                url: '/api/people'
            });
            return promise;
        },

        getPerson: function (username) {
            var promise = $http({
                method: 'GET',
                url: '/api/people/person?username=' + username,
            });
            return promise;
        },

        //createPlace: function (location, city) {
        //    var promise = $http({
        //        method: 'POST',
        //        url: '/api/Place/',
        //        data: {
        //            Name: location
        //        }
        //    });
        //    return promise;
        //}
    };

    return service;
});


function HomeCtrl($scope, appFactory, $location) {
    $scope.name = "Quang";

    $scope.places = [];

    appFactory.getPeople().then(function (d) {
        $scope.people = d.data;
    });

    $scope.loadProfile = function(person) {
        $location.url('/profile?username=' + person.userName);
    };
}


function ProfileCtrl($scope, appFactory, $routeParams) {
    var username = $routeParams.username;
    appFactory.getPerson(username).then(function (d) {
        $scope.person = d.data;
    });

}