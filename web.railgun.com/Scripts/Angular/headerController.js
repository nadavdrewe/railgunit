(function () {
    'use strict';

    angular
        .module('app')
        .controller('headerController', headerController);

    headerController.$inject = ['$scope']; 

    function headerController($scope) {
        $scope.title = 'headerController';
        $scope.value = "Test";

        activate();

        function activate() {


        }
    }
})();
