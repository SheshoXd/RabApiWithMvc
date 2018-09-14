
angular.module('RabetsApp' )
    .service('poService', function ($http, appSettings) {

   
  
    this.GetLastpo = function (id) {



        return $http.get(appSettings.serverPath +'/api/order/' + id );

    };

    this.Getpos = function () {
        return $http.get(appSettings.serverPath +'api/order/all');
    };

    this.newOrdNum = function (type) {
        
        return $http.get(appSettings.serverPath +'PurchaseOrders/NewId');
    }

    this.Insertpo = function (po) {
        
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post(appSettings.serverPath +'PurchaseOrders/PostPurchaseOrder', po, config)
     .success(function (data) {
            alert("done");
            location.reload();

        })
    .error(function (data, status) {
            alert("error");
            console.error('Repos error', status, data);
        })
    .finally(function () {
    console.log("finally finished repos");
});
    };

    this.Updatepo = function (po) {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        
        return $http.put(appSettings.serverPath +'PurchaseOrders/PutPurchaseOrder/' + po.OrderId, po, config).success(function (data) {
            alert("done");
            location.reload();

        })
        .error(function (data, status) {
            alert("error");
            console.error('Repos error', status, data);
        })
.finally(function () {
    console.log("finally finished repos");
});
    };
    
    this.Postpo = function (po) {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        
        return $http.get(appSettings.serverPath +'Posting/TranspurchsOrder/' + po, config)
        .success(function(data) {
            alert("done");
            location.reload();
             
            })
        .error(function (data, status) {
            alert("error");
            console.error('Repos error', status, data);
        })
.finally(function () {
    console.log("finally finished repos");
});
    };


});
