angular.module('RabetsApp')
    .controller('soController', function ($scope, soService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        $scope.DEpitFild = true; // disable enbale elemints

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
                soService.newOrdNum().then(function (d) {
                    
                    $scope.newOrdNum = d.data;
                });


                $scope.showClints = function (a, b) {

                    $scope.ClntName = b;
                    $scope.ClntId = a;

                };

        //$scope.EnbDisb = true; // disable enbale elemints
        //$scope.DEpitFild = true; // disable enbale elemints
        //$scope.so = null;
        //$scope.required = true;
        //$scope.newOrdNum = null;
        //$scope.so2Edit = null;
        //$scope.items = null;
        //$scope.sos = [];
        //$scope.Getclnt = null;
        //$scope.SuppId = null;
        //$scope.clntName = null;
        //$scope.OrderId = null;
        //$scope.myCreditor = 0;
        //$scope.myDepit = 0;


//       // $scope.OrderType = null;
//        $scope.rowCount = null;
//        $scope.toPricView = 0;
//        $scope.dt = null;
//        var mytype = null;
//        $scope.initiatorType = function (type) {
//            
//            $scope.OrderType = type;
//            mytype = type;
//        }

//        $scope.changeFunc= function () {
//            
//            var selectBox = document.getElementById("selectBox");
//            var selectedValue = selectBox.options[selectBox.selectedIndex].value;
//            if (selectedValue == 1) {
//                $scope.DEpitFild = false;
//            } else {
//                $scope.DEpitFild = true;
//            }
//        }


//        ////

//        $scope.soditems = {
//            ItemId: $scope.itemItemId,
//            ItemName: $scope.itemItemName,
//            ItemDescription: $scope.itemItemDescription,
//            AverageCost: $scope.itemAverageCost,
//            UintId: $scope.itemUintId,
//            DateCreated: $scope.itemDateCreated
//        };
//        $scope.soDetails = {

//            SlOrdDtId: $scope.SlOrdDtId,
//            SlOrdId: $scope.SlOrdId,
//            ItemId: $scope.ItemId,
//            SlQty: $scope.SlQty,
//            ItemPrice: $scope.ItemPrice,
//            TotalPrice: $scope.TotalPrice,
//            CaseNumber: $scope.CaseNumber,
//            CaseWight: $scope.CaseWight,
//            WightEmpty : $scope.WightEmpty,
//            StoredQty: $scope.StoredQty,
//            ItemName: $scope.myItemName,
//            Item: $scope.soditems
//        };
//        $scope.soDetailsList = [];

//        //************ 


////***************


///*******/


////-------------------   //get all clients //-------------------  

//        UtilitiesService.Utclnt().then(function (d) {
//            $scope.Getclnt = d.data;
//            },
//            function() {
//                alert('feild to load clients');
//            });


//        //-------------------   //GetAll Items  //-------------------  
//        itemsService.Getitems().then(function(d) {

//            $scope.items = d.data;
//        }, function() {
//            alert('Not Items');
//        });


//  

//        //-------------------   Drow  the form view  ----------------------------//


//        //getone

//        if ($routeParams.id != null) {
//            soService.Getso($routeParams.id).then(function(d) {


//                $scope.so = d.data;
//                $scope.clntName = d.data.Client.ClntName;


//            }, function() {

//            });
//        } else {
//            $scope.so = null;

//        }


//        //-------------------   Drow  the Land view  ----------------------------//


//        $scope.initsoLand = function(type) {
//            //getall sos
//            soService.Getsos(type).then(function(d) {

//                $scope.sos = d.data;

//            }, function() {
//                // alert('No Data To show Land');
//            });


////angular.forEach($scope.sos, function(value, key) {
//            //    $scope.sos.push(value);
//            //});


//        };
//        // func-------------->

//  $scope.putSupp = function(a,b)
//    {
//      $scope.SuppName = b;
//      $scope.SuppId = a;

//  };
//    /// get last number
//  $scope.SumNewTotl = function (a) {
//      $scope.toPricView += a;
//  };
//    //-------------------   Drow  the insert view  ----------------------------//
// // $scope.TotalPrice = 0;
//  $scope.getTotal = function () {
//      var total = 0;
//      for (var i = 0; i < $scope.soDetailsList.length; i++) {
//          var d = $scope.soDetailsList[i];
//          total += (d.CaseWight - d.StoredQty) * d.ItemPrice;
//      }
//      $scope.TotalPrice = total;


//      // return total;
//  }

//  $scope.addsod = function (a, b, c) {
//        var data = {};


//      data.ItemId = a,
//          data.QtyReq = 1,
//        data.CaseWight = 0,
//          data.ItemPrice = c,
//          data.CaseNumber = 1,
//          data.StoredQty = 0,
//        data.myItemName = b,


//        $scope.soDetailsList.push(data);
//        console.log($scope.soDetailsList);
//       // $scope.so.TotalPrice = $scope.so.TotalPrice + c;
//        $scope.rowCount++;

//  };
//        $scope.Debit = $scope.TotalPrice;

//    /// insert so 
//  $scope.insertso = function (d) {
//      


//      var insertedData = {
//          SuppId: $scope.SuppId,
//          //  EmpId: $scope.EmpId,
//          EmpId: 1,
//          TotalPrice: $scope.TotalPrice,
//          OrderType: 0,//$scope.OrderType,
//          OrderDate: $scope.OrderDate, //"2016-03-08T00:00:00",
//          PaymantType: $scope.PaymantType,
//          Debit: $scope.TotalPrice - $scope.Creditor,
//          Creditor: $scope.Creditor,
//          sostingStats: 0,
//          PurchaseOrdersDetails: $scope.soDetailsList
//      };

//      soService.Insertso(insertedData)
//  };

//    //--------------------Drow  the Edit view---------------------------//

//    //get one for edit
//  soService.GetLastso($routeParams.id,0).then(function (d) {

//      $scope.so2Edit = d.data;

//      angular.forEach($scope.so2Edit.PurchaseOrdersDetails, function (value, key) {
//          $scope.soDetailsList.push(value);
//          $scope.rowCount++;
//          $scope.toPricView += value.ItemPrice * value.QtyReq;

//      });

//  }, function () {
//      // alert('No so To edit');
//  });


//    $scope.addsod2Edit = function (a,b,c) {
//        var data = {};


//        data.ItemId = a,
//         data.QtyReq = 1,
//      //  data.ItemsDetail.itemItemName = b,
//        data.ItemPrice = c,
//        data.CaseNumber =1,
//        data.myItemName = b,


//        $scope.soDetailsList.push(data);
//        console.log($scope.soDetailsList);
//        $scope.so.TotalPrice = $scope.so.TotalPrice + c;
//        $scope.rowCount++;
//    };


//    /// update so
//    $scope.Updateso = function (d) {

//        var UpdatedData = {
//            OrderId: $scope.so2Edit.OrderId,
//            SuppId: $scope.so2Edit.Supplier.SuppId,
//            EmpId: 1,
//            OrderDate: $scope.OrderDate,
//            TotalPrice: $scope.TotalPrice,
//            PurchaseOrdersDetails: $scope.soDetailsList

//        };


//        soService.Updateso(UpdatedData)
//        console.log(UpdatedData);
//        $window.Location.href = 'so/' + $scope.so2Edit.OrderId;
//    };

//    //-----------------------    test area and other thing ------------------------//

//    ///// test area
//    /// add row orgnal
//    $scope.user = {};
//    $scope.user.name = "";
//    $scope.user.dept = "";
//    $scope.employeeList = [];
//    $scope.add = function () {
//        var data = {};
//        data.name = $scope.user.name;
//        data.dept = $scope.user.dept;
//        $scope.employeeList.push(data);
//        console.log($scope.employeeList);
//    }
//    //-----------------------------------------------//
//    /// remove row 
//    $scope.remove = function (obj) {
//        // console.log('data from remove'+obj);
//        //console.log('before'+$scope.employeeList);
//        // $scope.employeeList.splice(obj, obj);
//        console.log('end' + $scope.employeeList);

//        if (obj != -1) {
//            $scope.employeeList.splice(obj, 1);
//        }
//    }

//    var dd = new Date().getUTCDate();
//    var mm = new Date().getUTCMonth();
//    var yyyy = new Date().getUTCFullYear();

//   // $scope.dt = dd + '/' + mm + '/' + yyyy;

//        /// datepaker

//    $scope.open = function () {

//        $timeout(function () {
//            $scope.opened = true;
//        });
//    };
//    //-----------------------------------------------//

//    //$scope.ok = function () {
//    //    $modalInstance.close($scope.dt);
//    //};

//    //$scope.cancel = function () {
//    //    $modalInstance.dismiss('cancel');
//    //};
//    //-----------------------------------------------//


//    /// adda row 

//    $scope.rows = [];

//    $scope.counter = 0;

//    $scope.addRow = function (soDetails) {


//        // $scope.rows.push('Row' + $scope.counter + data);
//        $scope.rows.push(soDetails)


//        $scope.counter++;
//    }

        //-----------------------------------------------//
    });

