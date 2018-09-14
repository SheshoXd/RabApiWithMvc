var JsConfigApp = angular.module('app-name', [])
JsConfigApp.component('jsconfig', {
    template: "<div>{{myc}}{{ff}}<button ng-click='isClick()'>helooooo</button></div>" + "<div> firstname <input type='text' ng-model='Mytxt1' /> lastname  <input type='text' ng-model='Mytxt2' /> <button ng-click='GetTxtValyes()'>insert</button> </div>",
    controller: function ($scope) {

        $scope.ff = 0;
        $scope.GetTxtValyes = function () {
            alert($scope.Mytxt1 + ' ' + $scope.Mytxt2);

        }
        $scope.isClick = function () {

            $scope.myc = "hey ";

            $scope.ff += 1;
        }
    }


});