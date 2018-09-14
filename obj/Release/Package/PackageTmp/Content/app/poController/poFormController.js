angular.module('RabetsApp')
    .controller('poFormController', function ($scope, poService, $routeParams) {

       $scope.PostiStats = true ;

             
                    poService.GetLastpo($routeParams.id).then(function(d) {


                        $scope.po = d.data;
                        
                       
                        if ( d.data.PostingStats !== 1) {

                            $scope.PostiStats = false   ;
                        }
                        $scope.clntName = d.data.Client.ClntName;


                    }, function() {

                    });
              
        $scope.postpo = function(po) {
            
            poService.Postpo(po);
        };

    });

