app.controller('alldeliveryman',function($scope,$http){
    $http.get("https://localhost:44304/api/deliverydeliveryman/alldeliveryman")
    .then(function(response){
        //debugger;
        $scope.DeliverymansDetails = response.data;
    });
});