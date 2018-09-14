angular.module('RabetsApp')
    .controller('soEditController', function ($scope, soService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        $scope.DEpitFild = true; // disable enbale elemints
        $scope.newSOrdNum = null;
        $scope.Creditor = 0;
        $scop.SO = null;
        $scope.so.so.SlOrdDate = new Date(so.so.SlOrdDate);


        // select if depit or credate
        $scope.changeFunc = function () {
            
            var selectBox = document.getElementById("cashType");
            var selectedValue = selectBox.options[selectBox.selectedIndex].value;
            if (selectedValue == 1) {
                $scope.DEpitFild = false;
            } else {
                $scope.DEpitFild = true;
            }
        }
        //-------------------   //GetAll Items  //-------------------  
        itemsService.Getitems().then(function (d) {

            $scope.items = d.data;
        }, function () {
            alert('Not Items');
        });
        ////-------------------   //get all clients //-------------------  

                UtilitiesService.Utclnt().then(function (d) {
                    $scope.Getclnt = d.data;
                    },
                    function() {
                        alert('feild to load clients');
                    });


   
        // Functions too show clinte is selected//////////
                $scope.showClints = function (a, b) {  ///
                                              ///
                    $scope.so.Client.ClntName = b;               /// 
                    $scope.ClntId = a;                 ///
                                                       ///
                };                                     ///
        //////////////////////////////////////////////////

                $scope.soditems = {
                                ItemId: $scope.itemItemId,
                                ItemName: $scope.itemItemName,
                                ItemDescription: $scope.itemItemDescription,
                                AverageCost: $scope.itemAverageCost,
                                UintId: $scope.itemUintId,
                                DateCreated: $scope.itemDateCreated
                            };
                            $scope.soDetails = {

                                SlOrdDtId: $scope.SlOrdDtId,
                                SlOrdId: $scope.SlOrdId,
                                ItemId: $scope.ItemId,
                                SlQty: $scope.SlQty,
                                ItemPrice: $scope.ItemPrice,
                                TotalPrice: $scope.TotalPrice,
                                CaseNumber: $scope.CaseNumber,
                                CaseWight: $scope.CaseWight,
                                WightEmpty : $scope.WightEmpty,                           
                                ItemName: $scope.myItemName,
                               // Item: $scope.soditems
                            };
                            $scope.soDetailsList = [];
            //--------------------Drow  the Edit view---------------------------//

            //get one for edit
                            soService.Getso($routeParams.id).then(function (d) {
              
              $scope.so = d.data;

          
              angular.forEach($scope.so.SaleOrdersDetails, function (value, key) {
                  $scope.soDetailsList.push(value);
                  $scope.rowCount++;
                  $scope.toPricView += value.ItemPrice * value.QtyReq;

              });

          }, function () {
              // alert('No so To edit');
          });


            $scope.addsod = function (a,b,c) {
                var data = {};


                data.ItemId = a,
                    data.QtyReq = 1,
                  data.CaseWight = 0,
                    data.ItemPrice = c,
                    data.CaseNumber = 1,
                    data.StoredQty = 0,
                  data.myItemName = b,


                $scope.soDetailsList.push(data);
                console.log($scope.soDetailsList);
                $scope.so.TotalPrice = $scope.so.TotalPrice + c;
                $scope.rowCount++;
            };


            /// update so
            $scope.Updateso = function (d) {

                var UpdatedData = {
                    SlOrdId: $scope.SlOrdId,
                    ClntId: $scope.ClntId,
                    //  EmpId: $scope.EmpId,
                    EmpId: 1,
                    TotalPrice: $scope.TotalPrice,
                    SlOrdDate: $scope.OrderDate, //"2016-03-08T00:00:00",
                    PaymantType: $scope.PaymantType,
                    Debit: $scope.TotalPrice - $scope.Creditor,
                    Creditor: $scope.Creditor,
                    SaleOrdersDetails: $scope.soDetailsList

                };


                soService.Updateso(UpdatedData)
                console.log(UpdatedData);
                $window.Location.href = 'so/' + $scope.so.OrderId;
            };

    });

