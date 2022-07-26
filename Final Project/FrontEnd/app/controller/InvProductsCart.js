app.controller('invproductscart',function($scope,$http){
    $http.get("https://localhost:44304/api/inventory/allorder")
    .then(function(response){
        //debugger;
        $scope.InventoryOrdersDetails = response.data;
    });
});