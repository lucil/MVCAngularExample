(function (app) {
    'use strict';

    app.controller('productCtrl', productCtrl);

    productCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-products';
        $scope.loadingProducts = true;
        $scope.deletingProduct = true;
        $scope.products = [];
        $scope.search = search;
        $scope.deleteProduct = deleteProduct;
     
        function search() {
            $scope.loadingProducts = true;
            apiService.get('/api/products/', null, productsLoadCompleted, productsLoadFailed);
        }

        function productsLoadCompleted(result) {
            $scope.products = result.data;
            $scope.loadingProducts = false;
            notificationService.displayInfo(result.data.length + ' prodotti trovati');
        }

        function productsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function deleteProduct(productId) {
            if (confirm("Sei sicuro di volere cancellare questo prodotto?")) {
                $scope.deletingProduct = true;
                var data = {
                    productId : productId
                }
                apiService.post('/api/products/delete', data, productDeleteCompleted, productDeleteFailed);
            }
        }

        function productDeleteCompleted(result) {
            $scope.deletingProduct = false;
            notificationService.displaySuccess('Prodotto cancellato correttamente.');
            $scope.products = _.without($scope.products, _.findWhere($scope.products, {
                productId: result.data.productId
            }));
        }

        function productDeleteFailed(response) {
            notificationService.displayError(response.data);
        }


        $scope.search();
    }

})(angular.module('euris'));