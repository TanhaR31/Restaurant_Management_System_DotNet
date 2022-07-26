var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    .when("/", {
        templateUrl : "views/pages/InvProducts.html",
        controller: 'invproducts'
    })

    .when("/invproducts", {
        templateUrl : "views/pages/InvProducts.html",
        controller: 'invproducts'
    })

    .when("/invproductscart", {
        templateUrl : "views/pages/InvProductsCart.html",
        controller: 'invproductscart'
    })

    .when("/invproductsorder", {
        templateUrl : "views/pages/InvProductsOrder.html",
        controller: 'invproductsorder'
    })

    .when("/alldeliveries", {
        templateUrl : "views/pages/AllDeliveries.html",
        controller: 'alldeliveries'
    })

    .when("/freedeliveryman", {
        templateUrl : "views/pages/FreeDeliveryman.html",
        controller: 'freedeliveryman'
    })

    .when("/allorders", {
        templateUrl : "views/pages/AllOrders.html",
        controller: 'allorders'
    })

    .when("/alldeliveryman", {
        templateUrl : "views/pages/AllDeliveryman.html",
        controller: 'alldeliveryman'
    })

    .when("/allfeedback", {
        templateUrl : "views/pages/AllFeedback.html",
        controller: 'allfeedback'
    })

    .when("/allsalary", {
        templateUrl : "views/pages/AllSalary.html",
        controller: 'allsalary'
    })

    .when("/getinfo", {
        templateUrl : "views/pages/ManagerInfo.html",
        controller: 'getinfo'
    })

    .when("/login", {
        templateUrl : "views/pages/login.html",
        controller: 'login'
    })

    .when("/logout", {
        templateUrl : "views/pages/login.html",
        controller: 'logout',
        
    })
    
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);