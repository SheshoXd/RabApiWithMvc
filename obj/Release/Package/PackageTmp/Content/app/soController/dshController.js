angular.module('RabetsApp')
    .controller('dshController', function ($scope, soService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        $scope.AllSealOrder = null;
        soService.Getsos().then(function (d) {
            
            $scope.AllSealOrder = d.data;
        },
            function () {
                alert('feild to load clients');
            }
        );

        $scope.postso = function (so) {
            
            soService.Postso(so);
        };

    });
        