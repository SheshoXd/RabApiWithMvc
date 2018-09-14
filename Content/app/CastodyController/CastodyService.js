angular.module('RabetsApp')
    .service('CastodyService', function ($http){
        //Get all Supliers 
        this.GetListCast = function () {

            return $http.get( 'api/Castody/GetListCast');

        };

        // Get One
        //this.SuppGetOneServ = function (id) {
        //    //var f = {
        //    //    SuppId: 2,
        //    //    SuppName: "الحج صلاح",
        //    //    phoneNo: 123456789,
        //    //    DateCreated: "0001-01-01T00:00:00"
                
              
        //    //}
        //    //return f;
        //    return $http.get('api/Suppliers/GetSupplier/?id='+ id);
        //};
    });