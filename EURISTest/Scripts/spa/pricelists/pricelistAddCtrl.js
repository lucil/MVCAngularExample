(function (app) {
    'use strict';

    app.controller('pricelistAddCtrl', pricelistAddCtrl);

    pricelistAddCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService'];

    function pricelistAddCtrl($scope, $location, $routeParams, apiService, notificationService) {
        $scope.pageClass = 'page-pricelists';
        $scope.priceList = { priceListCode: '', description: '', productsIds: []};

        $scope.products = [];
        $scope.priceListCodeAlreadyExists = false;
        $scope.addPriceList = addPriceList;
        $scope.verifyPriceListCode = verifyPriceListCode;

        function loadProducts() {
            apiService.get('/api/products/', null,
            productsLoadCompleted,
            productsLoadFailed);
        }

        function productsLoadCompleted(response) {
            $scope.products = response.data;
        }

        function productsLoadFailed(response) {
            notificationService.displayError(response.data);
        }


        function addPriceList() {
            addPriceListModel();
        }

        function addPriceListModel() {
            apiService.post('/api/pricelists/create', $scope.priceList,
            addPriceListSucceded,
            addPriceListFailed);
        }

        function addPriceListSucceded(response) {
            notificationService.displaySuccess(' Il listino è stato creato correttamente.');
            redirectToEdit(response.data);
        }

        function addPriceListFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function redirectToEdit(priceListId) {
            $location.url('pricelists/edit/' + priceListId);
        }

        function verifyPriceListCode(priceListCode) {
            apiService.get('/api/pricelists/verify?priceListCode=' + priceListCode, null,
            verifyCompleted,
            verifyFailed);
        }

        function verifyCompleted(response) {
            $scope.priceListCodeAlreadyExists = response.data;
        }

        function verifyFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
            $scope.priceListCodeAlreadyExists = false;
        }

        loadProducts();

    }

})(angular.module('euris'));