app.controller('invproducts',function($scope,$http){
    $http.get("https://localhost:44304/api/inventory/allproduct")
    .then(function(response){
        //debugger;
        $scope.InventoryProducts = response.data;
    });
});