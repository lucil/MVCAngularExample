(function (app) {
    'use strict';

    app.directive('tooltip', tooltip);

    function tooltip() {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                $(element).hover(function () {
                    // on mouseenter
                    $(element).tooltip('show');
                }, function () {
                    // on mouseleave
                    $(element).tooltip('hide');
                });
            }
        };
    }

})(angular.module('common.ui'));
