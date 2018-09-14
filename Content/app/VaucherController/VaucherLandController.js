
angular.module('RabetsApp')
    .controller('VaucherLandController', function ($scope, VaucherSerivers, itemsService, UtilitiesService, $routeParams, $timeout, $window) {



        $scope.AllVauchar = null;

        VaucherSerivers.GetVaus().then(function (d) {
            
            $scope.AllVauchar = d.data;
        },
           function () {
               alert('feild to load Vauchers');
           }
       );


        $scope.postVaucher = function (vau) {
            

            VaucherSerivers.PostVau(vau);
            
        }
        //$scope.gridOptions = {
        //    columnDefs: [
        //      { field: 'id', displayName: 'Id' },
        //      { field: 'name', displayName: 'Name' },
        //      { name: 'edit', displayName: 'Edit', cellTemplate: '<button id="editBtn" type="button" class="btn-small" ng-click="edit(row.entity)" >Edit</button> ' }
        //    ]
        //};

   
    });
