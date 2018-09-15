angular.module('RabetsApp')
    .service('suppService', function ($http) {
        //Get all Supliers 
        this.Supps = function () {

            return $http.get('api/Suppliers/GetSuppliers');

        };

        // Get One
        this.SuppGetOneServ = function (id) {
            //var f = {
            //    SuppId: 2,
            //    SuppName: "الحج صلاح",
            //    phoneNo: 123456789,
            //    DateCreated: "0001-01-01T00:00:00"
                
              
            //}
            //return f;
            return $http.get('api/Suppliers/GetSupplier/?id='+ id);
        };
    });