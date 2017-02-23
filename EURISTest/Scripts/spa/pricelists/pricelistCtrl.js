(function (app) {
    'use strict';

    app.controller('pricelistCtrl', pricelistCtrl);

    pricelistCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function pricelistCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-pricelists';
        $scope.loadingPricelists = true;
        $scope.deletingPricelist = true;
        $scope.pricelists = [];
        $scope.search = search;
        $scope.deletePricelist = deletePricelist;

        function search() {
            $scope.loadingPricelists = true;
            apiService.get('/api/pricelists/', null, pricelistsLoadCompleted, pricelistsLoadFailed);
        }

        function pricelistsLoadCompleted(result) {
            $scope.pricelists = result.data;
            $scope.loadingPricelists = false;
            notificationService.displayInfo(result.data.length + ' listini trovati');
        }

        function pricelistsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function deletePricelist(priceListId) {
            if (confirm("Sei sicuro di volere cancellare questo listino?")) {
                $scope.deletingPricelist = true;
                var data = {
                    priceListId: priceListId
                }
                apiService.post('/api/pricelists/delete', data, pricelistDeleteCompleted, pricelistDeleteFailed);
            }
        }

        function pricelistDeleteCompleted(result) {
            $scope.deletingPricelist = false;
            notificationService.displaySuccess('Listino cancellato correttamente.');
            $scope.pricelists = _.without($scope.pricelists, _.findWhere($scope.pricelists, {
                priceListId: result.data.priceListId
            }));
        }

        function pricelistDeleteFailed(response) {
            notificationService.displayError(response.data);
        }

        $scope.search();
    }

})(angular.module('euris'));