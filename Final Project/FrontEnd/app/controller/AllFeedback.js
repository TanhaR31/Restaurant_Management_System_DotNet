app.controller('allfeedback',function($scope,$http){
    $http.get("https://localhost:44304/api/feedback/all")
    .then(function(response){
        //debugger;
        $scope.Feedbacks = response.data;
    });
});