
(function () {
    var id = null;
    var app = angular.module('RabetsApp', ['ngRoute', 'ui.bootstrap', 'ui.grid', 'ui.grid.selection', 'ui.grid.edit']);
    app.config(["$routeProvider", "$locationProvider",
        function ($routeProvider, $locationProvider) {

            $routeProvider

                //.when("/DashBord", {
                //    templateUrl: "Content/app/DashBordController/DashBord.html",

                //})

                .when("/DashBord", {
                    templateUrl: "ADashBord/DashBord?ng=ture",

                })

                .when("/item/:id", {
                    templateUrl: "Content/app/itemController/itemForm.html",
                    controller: "itemController"
                })
                //.when("/items", {
                //    templateUrl: "Content/app/itemController/itemsLand.html",
                //    controller: "itemController"
                //})
                .when("/item", {
                    templateUrl: "Content/app/itemController/itemInsert.html",
                    controller: "itemController"
                })
                .when("/item/:id/Edit", {
                    templateUrl: "Content/app/itemController/itemEdit.html",
                    controller: "itemController"
                })
                .when("/so/:id/Edit", {
                    templateUrl: "Content/app/poController/soEdit.html",
                    controller: "poController"
                })

                .when("/so/:id", {
                    templateUrl: "Content/app/soController/soForm.html",
                    controller: "soFormController"
                })
                .when("/sos", {
                    templateUrl: "Content/app/soController/soLand.html",
                    controller: "soLandController"
                })
                .when("/so", {
                    templateUrl: "Content/app/soController/soInsert.html",
                    controller: "soInsertController"
                })
                .when("/so/:id/Edit", {
                    templateUrl: "Content/app/soController/soEdit.html",
                    controller: "soEditController"

                })

                .when("/po/:id", {
                    templateUrl: "Content/app/poController/poForm.html",
                    controller: "poFormController"
                })

                .when("/pos", {
                    templateUrl: "Content/app/poController/poLand.html",
                    controller: "poController"
                })

                .when("/po", {
                    templateUrl: "Content/app/poController/poInsert.html",
                    controller: "poController"
                })

                .when("/po/:id/Edit", {
                    templateUrl: "Content/app/poController/poEdit.html",
                    controller: "poController"
                })

                .when("/supp/:id", {
                    templateUrl: "Content/app/suppController/suppForm.html",
                    controller: "suppController"
                })
                //.when("/supps", {
                //    templateUrl: "Content/app/suppController/suppLand.html",
                //    controller: "suppController"
                //})
                //.when("/supp", {
                //    templateUrl: "Content/app/suppController/suppInsert.html",
                //    controller: "suppController"
                //})
                .when("/supp/:id/Edit", {
                    templateUrl: "Content/app/suppController/suppEdit.html",
                    controller: "suppController"
                })

                //الانجلر مش كامل و حولت  الشغل ل ام فى سى

                //.when("/clnt/:id", {
                //    templateUrl: "Content/app/suppController/clntForm.html",
                //    controller: "clntController"
                //})

                //.when("/clnts", {
                //    templateUrl: "Content/app/clntController/clntLand.html",
                //    controller: "clntLandController"
                //})

                .when("/clantsacc", {
                    templateUrl: "Content/app/clntController/clntaccLand.html",
                    controller: "clntAccController"

                })

                .when("/clnt", {
                    templateUrl: "Content/app/clntController/clntInsert.html",
                    controller: "clntInsertController"
                })
                .when("/supp/:id/Edit", {
                    templateUrl: "Content/app/clntController/clntEdit.html",
                    controller: "suppController"
                })

                //vauchers
                .when("/Vauchers", {
                    templateUrl: "Content/app/VaucherController/VaucherLand.html",
                    controller: "VaucherLandController"
                })

                .when("/VauchersClints", {
                    templateUrl: "Content/app/VaucherController/VaucherLand.html",
                    controller: "VaucherLandController"
                })
                ///

                //////////////////////////////////////////////// MVC route///////////////////////////////

                //// clintes الانجلر مش كامل و الانفى بينجز

                .when("/clnts", {
                    templateUrl: "AClients/Index",

                })
                .when("/clnt", {
                    templateUrl: "AClients/Create",

                })
                .when("/clnt/id", {
                    templateUrl: "AClients/Details/id",

                })

                // emps 
                .when("/emps", {
                    templateUrl: "AEmployees/Index",

                })
                .when("/emp", {
                    templateUrl: "AEmployees/Create",

                })

                // supps 
                .when("/supps", {
                    templateUrl: "ASuppliers/Index",
                })
                // item
                .when("/AddItem", {
                    templateUrl: "AItems/Create",

                })
                // item
                .when("/items", {
                    templateUrl: "AItems/index",

                })
                // item
                .when("/item/:id", {
                    templateUrl: "AItems/edit/" + id,

                })
                //.when("/supp", {
                //    templateUrl: "ASuppliers/Create",

                //})

                //////////////////////////////////////////////////////////////////////////////////

                .otherwise({
                    redirectTo: "/DashBord"
                });
            //$locationProvider.html5Mode(true);
        }]);

   
  
    })();

