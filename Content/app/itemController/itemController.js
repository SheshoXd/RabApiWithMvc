angular.module('RabetsApp')
.controller('itemController', function ($scope, itemsService, $routeParams) {
    $scope.item = null;
    $scope.items = null;
    var url = null;

    itemsService.Getitems().then(function (d) {

        $scope.items = d.data;
     
    }, function () {
        alert('failed');
    });

    itemsService.GetUints().then(function (d) {

        $scope.Uints = d.data;
       
    }, function () {
        alert('failed');
    });

    $scope.handleDataTableButtons = function () {
        if ($("#datatable-buttons").length) {
            $("#datatable-buttons").DataTable({
                dom: "Bfrtip",
                buttons: [
                  {
                      extend: "copy",
                      className: "btn-sm"
                  },
                  {
                      extend: "csv",
                      className: "btn-sm"
                  },
                  {
                      extend: "excel",
                      className: "btn-sm"
                  },
                  {
                      extend: "pdfHtml5",
                      className: "btn-sm"
                  },
                  {
                      extend: "print",
                      className: "btn-sm"
                  },
                ],
                responsive: true,
                "ajax": {
                    "url": uts.url + "Items/GetItems",
                    dataSrc: ''
                },
                "columns": [{
                    "data": "ItemId"
                }, {
                    "data": "ItemName"
                }, {
                    "data": "ItemDescription"
                }, {
                    "data": "AverageCost"
                }, {
                    "data": "OpenBlance"
                }, {
                    "data": "availableQty"
                },
                {
                    "data": "Uint.UintName"
                }
                ]
            });
        }
    };

    if ($routeParams.id != null)
    {
        itemsService.GetLastItem($routeParams.id).then(function (d) {
           
            $scope.item = d.data;
        }, function () {
            alert('failed');
        });
    }
    else
    {
        $scope.item = null;

    }
    itemsService.Getitems().then(function (d) {
        
        $scope.items = d.data;
    }, function () {
        alert('failed');
    });
    $scope.insertItem = function (d) {
        
        var insertedData = {
        
            ItemName: $scope.ItemName,
            ItemDescription: $scope.ItemDescription,
            AverageCost: $scope.AverageCost,
            UintId: $scope.UintId,
            itemDepr:$scope.itemDepr

        };
     
        itemsService.InsertItem(insertedData)
    };

    $scope.UpdateItem = function (d) {
        
        var UpdatedData = {
            ItemDetailsId : $scope.item.ItemDetailsId,
            ItemName: $scope.item.ItemName,
            ItemDescription: $scope.item.ItemDescription,
            AverageCost: $scope.item.AverageCost,
            UintId: $scope.item.UintId,
            itemDepr:$scope.item.itemDepr

        };

        itemsService.UpdateItem(UpdatedData)
    };
 
});

