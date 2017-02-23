(function (app) {
    'use strict';

    app.controller('productEditCtrl', productEditCtrl);

    productEditCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService'];

    function productEditCtrl($scope, $location, $routeParams, apiService, notificationService) {
        $scope.pageClass = 'page-products';
        $scope.product = null;

        $scope.priceLists = [];

        $scope.editProduct = editProduct;

        function loadProduct() {
            var productId = $routeParams.id;
            apiService.get('/api/products/' + productId, null,
            loadProductCompleted,
            loadProductFailed);
        }

        function loadProductCompleted(response) {
            $scope.product = response.data;
            loadPriceLists();
        }

        function loadProductFailed(response) {
            notificationService.displayError(response.data);
        }

        function loadPriceLists() {
            apiService.get('/api/pricelists/', null,
            priceListsLoadCompleted,
            priceListsLoadFailed);
        }

        function priceListsLoadCompleted(response) {
            $scope.priceLists = response.data;
        }

        function priceListsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function editProduct() {
            editProductModel();
        }

        function editProductModel() {
            apiService.post('/api/products/edit', $scope.product,
            editProductSucceded,
            editProductFailed);
        }

        function editProductSucceded(response) {
            notificationService.displaySuccess(' Il prodotto è stato modificato correttamente.');
            $scope.product = response.data;
        }

        function editProductFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        loadProduct();
    }

})(angular.module('euris'));