angular.module('RabetsApp')
    .controller('soLandController', function ($scope, soService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        $scope.AllSealOrder = null;
        soService.Getsos().then(function (d) {
            
            $scope.AllSealOrder = d.data;
        },
            function () {
                alert('feild to load clients');
            }
        );


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
                        "url": "http://localhost:1234/api/SaleOrders/GetSaleOrders",
                        dataSrc: ''
                    },
                    "columns": [{
                        "data": "SlOrdId"
                    }, {
                        "data": "SlOrdDate"
                    }, {
                        "data": "Client.ClntName"
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




        $scope.postso = function (so) {
            
            soService.Postso(so);
        };

        $scope.AddToPrint = function(so){


            alert("fd");
        };

        // dash bord  area

        $scope.tpo = 5222;
        $scope.tso = 544;
        $scope.nvu = 44;
        $scope.tdep = 5444;



    });
        