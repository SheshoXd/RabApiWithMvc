angular.module('RabetsApp')
    .controller('soInsertController', function ($scope, soService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        $scope.DEpitFild = true; // disable enbale elemints
        $scope.newSOrdNum = null;
        $scope.Creditor = 0;
        // select if depit or credate
        $scope.changeFunc = function () {
            
            var selectBox = document.getElementById("selectBox");
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


       // get new order number
                soService.newSOrdNum().then(function (d) {
                    
                    $scope.newSOrdNum = d.data;
                });

        // Functions too show clinte is selected//////////
                $scope.showClints = function (a, b) {  ///
                                              ///
                    $scope.ClntName = b;               /// 
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

        //-------------------   Drow  the insert view  ----------------------------//

          //$scope.addsod = function (a, b, c) {
          //      var data = {};


          //    data.ItemId = a,
          //        data.QtyReq = 1,
          //      data.CaseWight = 0,
          //        data.ItemPrice = c,
          //        data.CaseNumber = 1,
          //        data.StoredQty = 0,
          //      data.myItemName = b,


          //      $scope.soDetailsList.push(data);
          //      console.log($scope.soDetailsList);
          //     // $scope.so.TotalPrice = $scope.so.TotalPrice + c;
          //      $scope.rowCount++;

          //};

         // $scope.TotalPrice = 0;
          $scope.getTotal = function () {
              var total = 0;
              for (var i = 0; i < $scope.soDetailsList.length; i++) {
                  var d = $scope.soDetailsList[i];
                  
                  total += (d.CaseWight - d.WightEmpty) * d.ItemPrice;
              }
              $scope.TotalPrice = total;


              // return total;
          }
          $scope.rowCount = 0;
          $scope.addsod = function (a, b, c, d) {
              //if (d > 0) {
                  $scope.rowCount++;
                  var data = {};


                  data.ItemId = a,
                      data.QtyReq = 1,
                      data.CaseWight = 0,
                      data.ItemPrice = c,
                      data.CaseNumber = 1,
                      data.StoredQty = 0,
                      data.myItemName = b,
                        data.AvilQty = d,


                  $scope.soDetailsList.push(data);
                  console.log($scope.soDetailsList);
                  // $scope.so.TotalPrice = $scope.so.TotalPrice + c;
                 
              //} else {

              //    alert('هذا الصنف غير متاح فى المخازن لا يمكن ادراجه فى امر بيع');
              //}
          };
                $scope.Debit = $scope.TotalPrice;

                //$scope.ChekAvlib = function (a, b) {
                    
                //    if (a > b) {
                //        alert("  الكميه المطلوبه اكبر من الكميه المتاحه بالمخزن يجب ان يكون الوزن الصافى اقل من" + b);
                //    }


                //}
        //-------------------   Drow  the insert view  ----------------------------//

        //    /// insert so   //-------------------   ----------------------------//
          $scope.insertso = function (d) {
              
              if ($scope.ClntId == null || $scope.ClntId === "undefined") {
                //  alert("يجب اختيار عميل  (محل)");
              }
              else
                  // clinte id if 
                  {
              
                  if ($scope.OrderDate == null || $scope.OrderDate === "undefined") {
                //  alert("اختيار تاريخ");
              }
                  // date if 
              else
                  {
//>>
              if ($scope.soDetailsList.length == 0)
              {
                  alert("يجب ادخال اصناف");
                  
              }
              else
                  {
              var  df= "";
              for (var i = 0; i < $scope.soDetailsList.length; i++) {

                  var qty = $scope.soDetailsList[i].WightEmpty - $scope.soDetailsList[i].CaseWight;
                  var avlb = $scope.soDetailsList[i].AvilQty ;
                  //if (qty > avlb) {
                  //    df = "***" +$scope.soDetailsList[i].myItemName + "متاح من كميه  " + avlb + "***";
                  //}
                  alert(df);
              }


              var insertedData = {
                  SlOrdId : '0',
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
             

              soService.Insertso(insertedData)
              } //item if

              } // date if 

               }   // clinte id if 
              
              //>>
          };
    });

