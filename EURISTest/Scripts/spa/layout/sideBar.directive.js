(function (app) {
    'use strict';

    app.directive('sideBar', sideBar);

    function sideBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/spa/layout/html/sideBar.html'
        }
    }

})(angular.module('common.ui'));