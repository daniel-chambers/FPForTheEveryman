'use strict';

angular.module('rxjsDemo')
  .controller('userSearchGoodCtrl', ["$scope", "$http", function($scope, $http) {
        
    $scope.searchTerms = null;
    $scope.loading = false;
    $scope.requestCount = 0;
    $scope.responseIndex = null;
    
    var searchObservable = $scope.$createObservableFunction('search');
    
    searchObservable
      .flatMapLatest(function() { 
        $scope.loading = true;
      
        var params = { 
          q: $scope.searchTerms,
          i: $scope.requestCount
        };
        
        $scope.requestCount++;
        
        return $http.get("/userSearch/api", { params: params });        
      })
      .safeApply($scope, function(response) {
        $scope.responseIndex = response.data.i;
        $scope.searchResults = response.data.results;
        $scope.loading = false;
      })
      .subscribe();
    
  }]);