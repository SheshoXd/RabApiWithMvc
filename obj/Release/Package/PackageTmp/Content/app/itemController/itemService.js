
angular.module('RabetsApp')
    .service('itemsService', function ($http, appSettings) {

    this.GetLastItem = function (id) {
        return $http.get(appSettings.serverPath +'Items/GetItems/?id=' + id);
    }

    this.Getitems = function () {
        return $http.get(appSettings.serverPath +'Items/GetItems');
    }

    this.GetUints = function () {
        return $http.get(appSettings.serverPath +'Uints/GetUints');
    }

    this.InsertItem = function (item)
    {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post('api/Items', item, config);
    }

    this.UpdateItem = function (item) {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post(appSettings.serverPath +'Item/PostItems', item, config).success(function (data) {
            alert("done");
            location.reload();

        })
    .error(function (data, status) {
        alert("error");
        console.error('Repos error', status, data);
    })
    .finally(function () {
        console.log("finally finished repos");
    })
        ;
    }

});
