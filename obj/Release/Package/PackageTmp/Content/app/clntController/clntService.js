angular.module('RabetsApp')
    .service('clntService', function($http) {
        
        this.getClnts= function() {
            return $http.get(appSettings.serverPath +'api/Clients/GetClients');
        }
    
        this.GetClintesAccount = function () {
            return $http.get(appSettings.serverPath +'api/Clients/GetClintesAccount');
        }

        this.getClnt = function(id) {
            return $http.get(appSettings.serverPath +'api/Clients/GetClients/'+id);
        }

        this.InsertClnt = function (clnt) {
            
            var config = {
                headers: {
                    'Content-Type': 'application/json'
                    //'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }
            return $http.post(appSettings.serverPath +'api/Clients/PostClient/', clnt, config)
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