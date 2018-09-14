
angular.module('RabetsApp')
    .controller('clntInsertController', function($scope, clntService,UtilitiesService, $routeParams) {

        $scope.Areas = null;
       
        UtilitiesService.UtAreas().then(function (d) {
         
                $scope.Areas = d.data;
                Console.Write(data);
            },
                function () {
                    alert('feild to load clients');
                });

     $scope.InsertClnt = function(d) {
          var insertData = {
             ClntId: $scope.ClntId,
             ClntName: $scope.ClntName,
             Type: 1,
             fullAddress: $scope.fullAddress,
             OwnerName: $scope.OwnerName,
             PhoneNo: $scope.PhoneNo,
             AreaId: $scope.AreaId
         }
  
         clntService.InsertClnt(insertData);
     }

    });