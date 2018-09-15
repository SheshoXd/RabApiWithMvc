angular.module('RabetsApp')
    .service('UtilitiesService', function ($http, appSettings) {

    this.UtSupp = function () {

     
        return $http.get(appSettings.serverPath + 'Suppliers/GetSuppliers');
    };
  
    this.Utclnt = function () {

      
        return $http.get(appSettings.serverPath +'Clients/GetClients');
    };

        this.UtAreas = function (parameters) {
            return $http.get(appSettings.serverPath +'Areas/GetAreas');
    }



});