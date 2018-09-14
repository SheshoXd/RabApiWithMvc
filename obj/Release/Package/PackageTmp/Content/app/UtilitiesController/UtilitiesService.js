angular.module('RabetsApp')
.service('UtilitiesService', function ($http) {

    this.UtSupp = function () {

        return getDataUrl('Suppliers/GetSuppliers');
    };
  
    this.Utclnt = function () {

        return getDataUrl('Clients/GetClients');
    };

    this.UtAreas = function(parameters) {
        return $http.get(appSettings.serverPath +'api/Areas/GetAreas');
    }

   var getDataUrl = function (url) {

        return $http.get(appSettings.serverPath +'api/'+url);

    };

    this.masterUrl = function () {
        
        return 'http://localhost:1234/api/';
    }
});