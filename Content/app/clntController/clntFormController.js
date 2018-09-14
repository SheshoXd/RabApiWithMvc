
angular.module('RabetsApp')
    .controller('clntController', function($scope, clntService, $routeParams) {


        $scope.initPoEdit = function() {

            $scope.clnts

            clntService.getClnts().then(function(d) {

                $scope.clnts = d.data;
            }, function() {
                alert('failed');
            });
        }

    });