angular.module('RabetsApp')
    .controller('soFormController', function ($scope, soService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        //$scope.so = null;
        $scope.PostiStats = true;

                if ($routeParams.id != null) {
                    soService.Getso($routeParams.id).then(function(d) {


                        $scope.so = d.data;
                        if (d.data.PostingStats !== 1) {

                            $scope.PostiStats = false;
                        }
                        $scope.clntName = d.data.Client.ClntName;


                    }, function() {

                    });
                } else {
                    $scope.so = null;

                }

        $scope.postso = function(so) {
            
            soService.Postso(so);
        };

    });

