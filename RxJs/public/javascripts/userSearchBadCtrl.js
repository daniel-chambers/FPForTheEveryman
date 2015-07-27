'use strict';

angular.module('rxjsDemo')
  .controller('userSearchBadCtrl', ["$scope", "$http", function($scope, $http) {
        
    $scope.searchTerms = null;
    $scope.loading = false;
    $scope.requestCount = 0;
    $scope.responseIndex = null;
    
    $scope.search = function() {
      $scope.loading = true;
      
      var params = { 
        q: $scope.searchTerms,
        i: $scope.requestCount
      };
      
      $http.get("/userSearch/api", { params: params })
        .then(function(response) {
          $scope.responseIndex = response.data.i;
          $scope.searchResults = response.data.results;
          $scope.loading = false;
        });
        
      $scope.requestCount++;
    };
    
  }]);