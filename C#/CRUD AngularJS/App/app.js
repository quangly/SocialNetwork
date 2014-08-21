var app = angular.module('app', ['ngRoute', 'ngResource', 'ngCookies', 'ngSanitize', 'angularFileUpload']);


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'Templates/home.html',
            controller: 'HomeCtrl'
        })
        .when('/profile', {
            templateUrl: 'Templates/profile.html',
            controller: 'ProfileCtrl'
        })
        .when('/search', {
        templateUrl: 'Templates/results.html',
        controller: 'SearchCtrl'
        })
        .when('/register', {
            templateUrl: 'Templates/register.html',
            controller: 'MainCtrl'
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
        
        getSearch: function (username) {
            var promise = $http({
                method: 'GET',
                url: '/api/people/search?username=' + username,
            });
            return promise;
        },
        
        addComment: function (itemid, commenttext, username) {
            var promise = $http({
                method: 'POST',
                url: '/api/people/comment',
                data: {
                    itemId: itemid,
                    commentText: commenttext,
                    userName: username
                }
            });
            return promise;
        },
        
        register: function (userName, name, email, location, picUrl) {
            var promise = $http({
                method: 'POST',
                url: '/api/people/register',
                data: {
                    userName: userName,
                    name: name,
                    email: email,
                    location: location,
                    picUrl: picUrl
                }
            });
            return promise;
        }
        


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


function MainCtrl($scope, appFactory, $routeParams, $location) {
    $scope.search = function (username) {
        $location.url('/search?username=' + username);
    };

    $scope.register = function() {
        $location.url('/register');
    };

    $scope.registerSubmit = function (userName, name, email, location, picUrl) {
        console.log(userName);
        console.log(name);
        appFactory.register(userName, name, email, location, picUrl).then(function (d) {
            console.log(d.data);
            $location.url('/profile?username=' + userName);
        });
    };

}


function ProfileCtrl($scope, appFactory, $routeParams, $location, $route) {
    $scope.loadProfile = function (userName) {
        $location.url('/profile?username=' + userName);
    };
    
    var username = $routeParams.username;
    //var itemid = $routeParams.itemid;
    //var commenttext = $routeParams.commenttext;
    //console.log('itemid ' + itemid);
    //console.log('comment ' + commenttext);

    $scope.addComment = function(itemid, commenttext, username) {
        appFactory.addComment(itemid, commenttext, username).then(function(d) {
            console.log(d.data);
            $route.reload();
        });
    };
    
    appFactory.getPerson(username).then(function (d) {
        $scope.person = d.data;
    });



}

function SearchCtrl($scope, appFactory, $routeParams, $location) {
    $scope.loadProfile = function (person) {
        $location.url('/profile?username=' + person.userName);
    };
    
    var username = $routeParams.username;
    appFactory.getSearch(username).then(function (d) {
        $scope.people = d.data;
    });

}

function UploadCtrl($scope, $scope, $http, $timeout, $upload) {
    $scope.upload = [];
    $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };

    $scope.onFileSelect = function ($files) {
        //$files: an array of files selected, each file has name, size, and type.
        for (var i = 0; i < $files.length; i++) {
            var $file = $files[i];
            (function (index) {
                $scope.upload[index] = $upload.upload({
                    url: "/api/files/upload", // webapi url
                    method: "POST",
                    data: { fileUploadObj: $scope.fileUploadObj },
                    file: $file
                }).progress(function (evt) {
                    // get upload percentage
                    console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                }).success(function (data, status, headers, config) {
                    // file is uploaded successfully
                    console.log(data);
                }).error(function (data, status, headers, config) {
                    // file failed to upload
                    console.log(data);
                });
            })(i);
        }
    }

    $scope.abortUpload = function (index) {
        $scope.upload[index].abort();
    };
};
