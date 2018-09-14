
angular.module('RabetsApp')
    .controller('clntLandController', function ($scope, clntService, $routeParams) {


        $scope.clnts = null;

            clntService.getClnts().then(function(d) {

                $scope.clnts = d.data;
            }, function() {
                alert('failed');
            });
      

    });