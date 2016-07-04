'use strict';

var App = angular.module('RSSFeedApp', []);

App.controller("FeedCtrl", ['$scope', 'FeedService', function ($scope, Feed) {
    $scope.loadButonText = "Load";
    $scope.loadFeed = function (e) {
        Feed.parseFeed($scope.feedSrc).then(function (res) {
            $scope.loadButonText = angular.element(e.target).text();
            $scope.feeds = res;
        });
    }
}]);

App.factory('FeedService', ['$http', function ($http) {
        return {
        parseFeed: function (rowcount) {
            var promise = $http.get('http://localhost:54674/api/Values/Index/').then(function (response) {

               return response.data;
            }, function (error) {
                alert('error');
            })
            return promise;
        }
    }

}]);