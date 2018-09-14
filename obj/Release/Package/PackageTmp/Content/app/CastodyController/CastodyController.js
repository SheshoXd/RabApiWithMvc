angular.module('RabetsApp')
.controller('CastodyController', function ($scope, CastodyService, $routeParams) {

    // public Diclier
    
    // Disable / Enable  for form
      
  //fire in public
    $scope.LastCast =0;

    //fire for Castody

    $scope.Selected = "اختار";

    $scope.Tryit = function (d) {

        CastodyService.GetListCast().then(function (d) {

            $scope.LastCast = d.data;

        }, function () {
            alert('failed');
        });
    
        alert("hello"+d);
    };

        //-----------------------------------------------//
    });

