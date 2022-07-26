app.controller('invproductsorder',function($scope,$http){
    $http.get("https://localhost:44304/api/inventory/orderplace")
    .then(function(response){
        //debugger;
        $scope.InventoryOrdersTotals = response.data;
    });
});