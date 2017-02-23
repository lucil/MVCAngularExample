(function (app) {
    'use strict';

    app.controller('productAddCtrl', productAddCtrl);

    productAddCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService'];

    function productAddCtrl($scope, $location, $routeParams, apiService, notificationService) {
        $scope.pageClass = 'page-products';
        $scope.product = { productCode: '', description: '', priceListIds: [] };

        $scope.priceLists = [];
        $scope.productCodeAlreadyExists = false;
        $scope.addProduct = addProduct;
        $scope.verifyProductCode = verifyProductCode;

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

        function addProduct() {
            addProductModel();
        }

        function addProductModel() {
            apiService.post('/api/products/create', $scope.product,
            addProductSucceded,
            addProductFailed);
        }

        function addProductSucceded(response) {
            notificationService.displaySuccess(' Il prodotto è stato creato correttamente.');
            redirectToEdit(response.data);
        }

        function addProductFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToEdit(productId) {
            $location.url('products/edit/' + productId);
        }

        function verifyProductCode(productCode) {
            apiService.get('/api/products/verify?productCode=' + productCode, null,
            verifyCompleted,
            verifyFailed);
        }

        function verifyCompleted(response) {
            $scope.productCodeAlreadyExists = response.data;
        }

        function verifyFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
            $scope.productCodeAlreadyExists = false;
        }

        loadPriceLists();
    }

})(angular.module('euris'));