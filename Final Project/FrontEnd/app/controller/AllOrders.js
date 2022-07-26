app.controller('allorders',function($scope,$http){
    $http.get("https://localhost:44304/api/deliverydeliveryman/allorders")
    .then(function(response){
        //debugger;
        $scope.Orders = response.data;
    });
});