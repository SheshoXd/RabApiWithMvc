
angular.module('RabetsApp')
.service('itemsService', function ($http) {

    this.GetLastItem = function (id) {
        return $http.get(appSettings.serverPath +'api/Items/GetItems/?id=' + id);
    }

    this.Getitems = function () {
        return $http.get(appSettings.serverPath +'api/Items/GetItems');
    }

    this.GetUints = function () {
        return $http.get(appSettings.serverPath +'api/Uints/GetUints');
    }

    this.InsertItem = function (item)
    {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post(appSettings.serverPath +'api/Items', item, config);
    }

    this.UpdateItem = function (item) {
        var config = {
            headers: {
                'Content-Type': 'application/json'
                //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        return $http.post(appSettings.serverPath +'api/Item/PostItems', item, config).success(function (data) {
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
