angular.module('RabetsApp')
.controller('suppController', function ($scope, suppService, $routeParams) {

    // public Diclier
        $scope.Supp = null;
        $scope.GetSupp = null;
    // Disable / Enable  for form
        $scope.EnbDisb = true;
  //fire in public
 
  
  
  //fire for suppLand
    
    //get all Supp
    $scope.initSuppLand = function () {

        suppService.Supps().then(function (d) {
        $scope.GetSupp = d.data;
    },
    function () {
        alert('feild to load supp');
    });
            // end get all Supp
    };


   // fire for SuppForm
        $scope.initSuppForm = function () {
            
       //get one supp
            if ($routeParams.id != null) {
                suppService.SuppGetOneServ($routeParams.id).then(function (d) {
                    

                    $scope.Supp = d.data;
                 


                }, function () {

                });
            }
            else {
                $scope.Supp = null;

            }


            // end SuppForm
 };

        //-----------------------------------------------//
    });

