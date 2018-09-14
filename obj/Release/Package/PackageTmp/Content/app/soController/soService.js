/// <reference path="../UtilitiesController/UtilitiesService.js" />

angular.module('RabetsApp')
.service('soService', function ($http, UtilitiesService) {

    var ut = "http://localhost:1234/api/";

    this.Getso = function (id) {

        return $http.get(ut+'SaleOrders/GetSaleOrder/' + id);
        
    };

    this.Getsos = function () {
        return $http.get(ut + 'SaleOrders/GetSaleOrders');
    };

    this.newSOrdNum = function () {
        
        return $http.get(ut + 'SaleOrders/NewNumber');
    }

    this.Insertso = function (so) {
        
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post( ut+'SaleOrders/PostSaleOrder/', so, config)
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
            return $http.get(ut+'Posting/PostRequestSealOrder/' + so, config).success(function (data) {
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
        
        return $http.put(ut+'SaleOrders/PutSaleOrder/' + so.OrderId, so, config)
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
