
angular.module('RabetsApp')
.service('VaucherSerivers', function ($http) {



    this.GetVau = function (id) {



        return $http.get(appSettings.serverPath +'api/Vaucher/Get/' + id);

    };

    this.GetVaus = function () {
        return $http.get(appSettings.serverPath +'api/Vaucher');
    };

    //this.newSOrdNum = function () {
    //    
    //    return $http.get(appSettings.serverPath +'api/SaleOrders/NewNumber');
    //}

//    this.InsertVao = function (so) {
//        
//        var config = {
//            headers: {
//                'Content-Type': 'application/json'
//                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
//            }
//        }
//        return $http.post(appSettings.serverPath +'api/SaleOrders/PostSaleOrder/', so, config)
//            .success(function (data) {
//                alert("done");
//                location.reload();

//            })
//        .error(function (data, status) {
//            alert("error");
//            console.error('Repos error', status, data);
//        })
//.finally(function () {
//    console.log("finally finished repos");
//});
//    };



    this.PostVau = function (Vau) {
        
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }

        }
        return $http.get(appSettings.serverPath +'api/Posting/PostVaucher/' + Vau, config).success(function (data) {
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



    //this.Updateso = function (so) {
    //    var config = {
    //        headers: {
    //            'Content-Type': 'application/json'
    //            //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
    //        }
    //    }
    //    
    //    return $http.put(appSettings.serverPath +'api/SaleOrders/PutSaleOrder/' + so.OrderId, so, config)
    //        .success(function (data) {
    //            alert("done");
    //            location.reload();

    //        })
    //       .error(function (data, status) {
    //           alert("error");
    //           console.error('Repos error', status, data);
    //       })
    //       .finally(function () {
    //           console.log("finally finished repos");
    //       });
    //};


});
