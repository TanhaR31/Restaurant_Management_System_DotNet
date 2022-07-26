app.controller('alldeliveries',function($scope,$http){
    $http.get("https://localhost:44304/api/deliverydeliveryman/alldeliveries")
    .then(function(response){
        //debugger;
        $scope.Deliveries = response.data;
    });
});