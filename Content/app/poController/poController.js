angular.module('RabetsApp')
    .controller('poController', function ($scope, poService, itemsService, UtilitiesService, $routeParams, $timeout, $window) {
        $scope.EnbDisb = true; // disable enbale elemints
        $scope.DEpitFild = true; // disable enbale elemints
        $scope.po = null;
        $scope.required = true;
        $scope.newOrdNum = null;
        $scope.po2Edit = null;
        $scope.items = null;
        $scope.pos = [];
        $scope.GetSupp = null;
        $scope.SuppId = null;
        $scope.SuppName = null;
        $scope.OrderId = null;
        $scope.myCreditor = 0;
        $scope.myDepit = 0;
        
   

   
  // select if depit or credate
        $scope.changeFunc= function () {
            
            var selectBox = document.getElementById("selectBox");
            var selectedValue = selectBox.options[selectBox.selectedIndex].value;
            if (selectedValue == 1) {
                $scope.DEpitFild = false;
            } else {
                $scope.DEpitFild = true;
            }
        }


        $scope.postpo = function (po) {
            
            poService.Postpo(po);

        };

       
        ////

        $scope.poditems = {
            ItemId: $scope.itemItemId,
            ItemName: $scope.itemItemName,
            ItemDescription: $scope.itemItemDescription,
            AverageCost: $scope.itemAverageCost,
            UintId: $scope.itemUintId,
            DateCreated: $scope.itemDateCreated
        };
        $scope.PODetails = {
            OrderDetailsId: $scope.OrderDetailsId,
            OrderId: $scope.OrderId,
            ItemId: $scope.ItemId,
            QtyReq: $scope.QtyReq,
            ItemPrice: $scope.ItemPrice,
            TotalPrice: $scope.TotalPrice,
            CaseNumber: $scope.CaseNumber,
            CaseWight: $scope.CaseWight,
            WightEmpty : $scope.WightEmpty,
            StoredQty: $scope.StoredQty,
            ItemName: $scope.myItemName,
            Item: $scope.poditems
        };
        $scope.PODetailsList = [];

        //************ 




//***************


/*******/


//-------------------   //get all Supp //-------------------  

        UtilitiesService.UtSupp().then(function(d) {
                $scope.GetSupp = d.data;
            },
            function() {
                alert('feild to load supp');
            });


        //-------------------   //GetAll Items  //-------------------  
        itemsService.Getitems().then(function(d) {

            $scope.items = d.data;
        }, function() {
            alert('Not Items');
        });


        //get new order number
        poService.newOrdNum().then(function (d) {
            
            $scope.newOrdNum = d.data;
        });

        //-------------------   Drow  the form view  ----------------------------//


        //getone

        if ($routeParams.id != null) {
            poService.GetLastpo($routeParams.id).then(function(d) {


                $scope.po = d.data;
                $scope.SuppName = d.data.Supplier.SuppName;


            }, function() {

            });
        } else {
            $scope.po = null;

        }


        //-------------------   Drow  the Land view  ----------------------------//


        $scope.initPoLand = function() {
            //getall pos
            
            poService.Getpos().then(function(d) {
                
                $scope.pos = d.data;

            }, function() {
                // alert('No Data To show Land');
            });

      


        };
        // func-------------->
  
  $scope.putSupp = function(a,b)
  {
    
      $scope.SuppName = b;
      $scope.SuppId = a;

  };

    //-------------------   Drow  the insert view  ----------------------------//
 // Totle price conuter
  $scope.getTotal = function () {
      var total = 0;
      for (var i = 0; i < $scope.PODetailsList.length; i++) {
          var d = $scope.PODetailsList[i];
          total += (d.CaseWight - d.StoredQty) * d.ItemPrice;
      }
      $scope.TotalPrice = total;
    
   

      // return total;
  }
       
  $scope.addpod = function (a, b, c) {
        var data = {};
      // $scope.OrderType = null;
        $scope.rowCount = null;

      data.ItemId = a,
          data.QtyReq = 1,
        data.CaseWight = 0,
          data.ItemPrice = c,
          data.CaseNumber = 1,
          data.StoredQty = 0,
        data.myItemName = b,


        $scope.PODetailsList.push(data);
        console.log($scope.PODetailsList);
       // $scope.po.TotalPrice = $scope.po.TotalPrice + c;
        $scope.rowCount++;

  };
        $scope.Debit = $scope.TotalPrice;

    /// insert po 
  $scope.insertpo = function (d) {
      
 
 
      var insertedData = {
          SuppId: $scope.SuppId,
          //  EmpId: $scope.EmpId,
          EmpId: 1,
          TotalPrice: $scope.TotalPrice,
          OrderType: 0,//$scope.OrderType,
          OrderDate: $scope.OrderDate, //"2016-03-08T00:00:00",
          PaymantType: $scope.PaymantType,
          Debit: $scope.TotalPrice - $scope.Creditor,
          Creditor: $scope.Creditor,
          PostingStats: 0,
          PurchaseOrdersDetails: $scope.PODetailsList
      };

      poService.Insertpo(insertedData)
  };

    //--------------------Drow  the Edit view---------------------------//
        $scope.initPoEdit = function() {
            //get one for edit
            poService.GetLastpo($routeParams.id).then(function(d) {
                
                $scope.po2Edit = d.data;

                angular.forEach($scope.po2Edit.PurchaseOrdersDetails, function(value, key) {
                    $scope.PODetailsList.push(value);
                    $scope.rowCount++;
                    $scope.toPricView += value.ItemPrice * value.QtyReq;

                });

            }, function() {
                // alert('No Po To edit');
            });

        };
        // $scope.OrderType = null;
        $scope.rowCount = null;
        // add rows to table
        $scope.addpod2Edit = function (a,b,c) {
        var data = {};
      
    
      
        data.ItemId = a,
         data.QtyReq = 1,
      //  data.ItemsDetail.itemItemName = b,
        data.ItemPrice = c,
        data.CaseNumber =1,
        data.myItemName = b,
        
      
        $scope.PODetailsList.push(data);
        console.log($scope.PODetailsList);
        $scope.po.TotalPrice = $scope.po.TotalPrice + c;
        $scope.rowCount++;
    };


    /// update po
    $scope.Updatepo = function (d) {
      
        var UpdatedData = {
            OrderId: $scope.po2Edit.OrderId,
            SuppId: $scope.po2Edit.Supplier.SuppId,
            EmpId: 1,
            OrderDate: $scope.OrderDate,
            TotalPrice: $scope.TotalPrice,
            PurchaseOrdersDetails: $scope.PODetailsList

        };
       
        
        poService.Updatepo(UpdatedData)
        console.log(UpdatedData);
        $window.Location.href = 'po/' + $scope.po2Edit.OrderId;
    };

    //-----------------------    test area and other thing ------------------------//

    ///// test area
    /// add row orgnal
    $scope.user = {};
    $scope.user.name = "";
    $scope.user.dept = "";
    $scope.employeeList = [];
    $scope.add = function () {
        var data = {};
        data.name = $scope.user.name;
        data.dept = $scope.user.dept;
        $scope.employeeList.push(data);
        console.log($scope.employeeList);
    }
    //-----------------------------------------------//
    /// remove row 
    $scope.remove = function (obj) {
        // console.log('data from remove'+obj);
        //console.log('before'+$scope.employeeList);
        // $scope.employeeList.splice(obj, obj);
        console.log('end' + $scope.employeeList);

        if (obj != -1) {
            $scope.employeeList.splice(obj, 1);
        }
    }

    var dd = new Date().getUTCDate();
    var mm = new Date().getUTCMonth();
    var yyyy = new Date().getUTCFullYear();
  
   // $scope.dt = dd + '/' + mm + '/' + yyyy;

        /// datepaker
 
    $scope.open = function () {

        $timeout(function () {
            $scope.opened = true;
        });
    };
    //-----------------------------------------------//

    //$scope.ok = function () {
    //    $modalInstance.close($scope.dt);
    //};

    //$scope.cancel = function () {
    //    $modalInstance.dismiss('cancel');
    //};
    //-----------------------------------------------//


    /// adda row 

    $scope.rows = [];

    $scope.counter = 0;

    $scope.addRow = function (PODetails) {


        // $scope.rows.push('Row' + $scope.counter + data);
        $scope.rows.push(PODetails)


        $scope.counter++;
    }

    //-----------------------------------------------//
});

