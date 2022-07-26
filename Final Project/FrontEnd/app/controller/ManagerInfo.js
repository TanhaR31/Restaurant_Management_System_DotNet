app.controller('getinfo',function($scope,$http){
    $http.get("https://localhost:44304/api/manager/info")
    .then(function(response){
        //debugger;
        $scope.ManagersDetails = response.data;
    });
});