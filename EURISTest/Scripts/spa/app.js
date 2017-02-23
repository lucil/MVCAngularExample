(function () {
    'use strict';

    angular.module('euris', ['common.core', 'common.ui', 'checklist-model'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/html/index.html",
                controller: "indexCtrl"
            })     
            .when("/products", {
                templateUrl: "scripts/spa/products/html/products.html",
                controller: "productCtrl"
            })
            .when("/products/add", {
                templateUrl: "scripts/spa/products/html/add.html",
                controller: "productAddCtrl"           
            })
            .when("/products/edit/:id", {
                templateUrl: "scripts/spa/products/html/edit.html",
                controller: "productEditCtrl"
            })
            .when("/pricelists", {
                templateUrl: "scripts/spa/pricelists/html/pricelists.html",
                controller: "pricelistCtrl"
            })
            .when("/pricelists/products/:id", {
                 templateUrl: "scripts/spa/pricelists/html/products.html",
                 controller: "pricelistAddCtrl"
            })
            .when("/pricelists/add", {
                templateUrl: "scripts/spa/pricelists/html/add.html",
                controller: "pricelistAddCtrl"
            })
            .when("/pricelists/edit/:id", {
                templateUrl: "scripts/spa/pricelists/html/edit.html",
                controller: "pricelistEditCtrl"
            })
            .when("/pricelists/products/:id", {
                templateUrl: "scripts/spa/pricelists/html/products.html",
                controller: "pricelistProductsCtrl"
            })
           .otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
       
        $(document).ready(function () {
            //do you really need this document ready thing?
        });
    }
})();