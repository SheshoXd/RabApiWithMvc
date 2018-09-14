angular.module('RabetsApp')
    .controller('datepickerPopupController', function ($scope, $modalInstance, $timeout) {

        $scope.dt = new Date();


        $scope.open = function() {
   
            $timeout(function() {
                $scope.opened = true;
            });
        };

  
        $scope.ok = function () {
            $modalInstance.close($scope.dt);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });
