'use strict';

angular.module('rxjsDemo')
  .controller('serverPollingHelperCtrl', ["$scope", "$http", function($scope, $http) {
    
    $scope.setCompletedState = function() {
      $http.post("/serverPolling/api?state=Completed");
    };
    
    $scope.resetState = function() {
      $http.post("/serverPolling/api?state=Loading");
    };
    
  }]);