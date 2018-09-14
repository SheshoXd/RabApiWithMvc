/// <reference path="../UtilitiesController/UtilitiesService.js" />

angular.module('RabetsApp')
    .service('soService', function ($http, UtilitiesService, appSettings) {

   

    this.Getso = function (id) {

        return $http.get(appSettings.serverPath  +'SaleOrders/GetSaleOrder/' + id);
        
    };

    this.Getsos = function () {
        return $http.get(appSettings.serverPath +'SaleOrders/GetSaleOrders');
    };

    this.newSOrdNum = function () {
        
        return $http.get(appSettings.serverPath +'SaleOrders/NewNumber');
    }

    this.Insertso = function (so) {
        
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post(appSettings.serverPath +'SaleOrders/PostSaleOrder/', so, config)
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

        this.Postso = function (so) {
            
            var config = {
                headers: {
                    'Content-Type': 'application/json'
                    //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
                
            }
            return $http.get(appSettings.serverPath +'Posting/PostRequestSealOrder/' + so, config).success(function (data) {
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

    this.Updateso = function (so) {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        
        return $http.put(appSettings.serverPath +'SaleOrders/PutSaleOrder/' + so.OrderId, so, config)
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

});
