
angular.module('RabetsApp')
    .controller('clntAccController', function($scope, clntService, $routeParams) {

        $scope.f = "hello";
        $scope.initPoEdit = function() {

            $scope.clnts

            clntService.GetClintesAccount().then(function (d) {

                $scope.clnts = d.data;
            }, function() {
                alert('failed');
            });
        }

    });