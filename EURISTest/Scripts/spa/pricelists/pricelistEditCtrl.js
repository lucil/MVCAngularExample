(function (app) {
    'use strict';

    app.controller('pricelistEditCtrl', pricelistEditCtrl);

    pricelistEditCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService'];

    function pricelistEditCtrl($scope, $location, $routeParams, apiService, notificationService) {
        $scope.pageClass = 'page-pricelists';
        $scope.priceList = null;

        $scope.products = [];
        $scope.editPriceList = editPriceList;

        function loadPriceList() {
            var priceListId = $routeParams.id;
            apiService.get('/api/pricelists/' + priceListId, null,
            loadPriceListCompleted,
            loadPriceListFailed);
        }

        function loadPriceListCompleted(response) {
            $scope.priceList = response.data;
            loadProducts();
        }

        function loadPriceListFailed(response) {
            notificationService.displayError(response.data);
        }

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


        function editPriceList() {
            editPriceListModel();
        }

        function editPriceListModel() {
            apiService.post('/api/pricelists/edit', $scope.priceList,
            editPriceListSucceded,
            editPriceListFailed);
        }

        function editPriceListSucceded(response) {
            notificationService.displaySuccess(' Il listino è stato modificato correttamente.');
            $scope.priceList = response.data;
        }

        function editPriceListFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        loadPriceList();
    }

})(angular.module('euris'));