app.controller('allsalary',function($scope,$http){
    $http.get("https://localhost:44304/api/salary/allsalary")
    .then(function(response){
        //debugger;
        $scope.Salaries = response.data;
    });
});