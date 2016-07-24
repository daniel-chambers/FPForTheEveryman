'use strict';

angular.module('rxjsDemo')
  .controller('serverPollingCtrl', ["$scope", "$http", "rx", function($scope, $http, rx) {
    
    $scope.requestCount = 0;
    $scope.serverTime = null;
    $scope.state = null;
    $scope.timeSinceLastRequest = 0;
        
    var pollingObservable = 
      rx.Observable.return(null)
        .concat(rx.Observable.interval(1000).take(10))
        .concat(rx.Observable.interval(4000).take(10))
        .concat(rx.Observable.interval(10000));
    
    $scope.refreshSubscription = pollingObservable
      .flatMapLatest(function() {
        $scope.requestCount++;
        return $http.get("/serverPolling/api");
      })
      .safeApply($scope, function(response) {
        $scope.serverTime = response.data.serverTime;
        $scope.state = response.data.state;
        
        if ($scope.state === "Completed")
          $scope.refreshSubscription.dispose();
      })
      .subscribe();
      
    $scope.$on("$destroy", function() { $scope.refreshSubscription.dispose(); })
    
  }]);