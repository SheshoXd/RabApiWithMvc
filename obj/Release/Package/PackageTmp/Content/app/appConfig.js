(function () {

    "user strict";

    angular
        .module("appConfig")
        .constant("appSettings",
        {
            //API Server Path (Must add the appSettings on every service )
            serverPath: "http://localhost:1234/api/",
        });

}());
