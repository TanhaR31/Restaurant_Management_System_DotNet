app.controller('freedeliveryman',function($scope,$http){
    $http.get("https://localhost:44304/api/deliverydeliveryman/freedeliveryman")
    .then(function(response){
        //debugger;
        $scope.DeliverymansDetails = response.data;
    });
});