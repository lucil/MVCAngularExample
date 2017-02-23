(function (app) {
    'use strict';

    app.controller('pricelistProductsCtrl', pricelistProductsCtrl);

    pricelistProductsCtrl.$inject = ['$scope', '$routeParams', 'apiService', 'notificationService'];

    function pricelistProductsCtrl($scope, $routeParams, apiService, notificationService) {
        $scope.pageClass = 'page-pricelists';
        $scope.loadingProducts = true;
        $scope.products = [];
        $scope.priceList = null;
        $scope.searchProducts = searchProducts;

        function loadPriceList() {
            var priceListId = $routeParams.id;
            apiService.get('/api/pricelists/' + priceListId, null,
            loadPriceListCompleted,
            loadPriceListFailed);
        }

        function loadPriceListCompleted(response) {
            $scope.priceList = response.data;
            $scope.searchProducts();
        }

        function loadPriceListFailed(response) {
            notificationService.displayError(response.data);
        }

        function searchProducts() {
            var priceListId = $routeParams.id;
            $scope.loadingProducts = true;
            apiService.get('/api/pricelists/products/' + priceListId, null, productsLoadCompleted, productsLoadFailed);
        }

        function productsLoadCompleted(result) {
            $scope.products = result.data;
            $scope.loadingProducts = false;
            notificationService.displayInfo(result.data.length + ' prodotti associati al listino');
        }

        function productsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        loadPriceList();
    }

})(angular.module('euris'));