'use strict';

angular.module('rxjsDemo')
  .controller('userSearchGoodCtrl', ["$scope", "$http", function($scope, $http) {
        
    $scope.searchTerms = null;
    $scope.loading = false;
    $scope.requestCount = 0;
    $scope.responseIndex = null;
    
    $scope.$createObservableFunction('search')
      .flatMapLatest(function() { 
        $scope.loading = true;
      
        var params = { 
          q: $scope.searchTerms,
          i: $scope.requestCount
        };
        
        $scope.requestCount++;
        
        return $http.get("/userSearch/api", { params: params });        
      })
      .subscribe(function(response) {
        $scope.responseIndex = response.data.i;
        $scope.searchResults = response.data.results;
        $scope.loading = false; 
      });
    
  }]);