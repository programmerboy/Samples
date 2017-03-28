(function () {
    "use strict";

    //This service makes sure that scope is safely applied. Otherwise if you directly apply
    // $scope.$apply(fn) in your code then you get following error https://docs.angularjs.org/error/$rootScope/inprog
    // http://stackoverflow.com/a/22733591/1813357

    angular.module('sample').service('scopeService', function () {
        return {
            safeApply: function ($scope, fn) {
                var phase = $scope.$root.$$phase;
                if (phase == '$apply' || phase == '$digest') {
                    if (fn && typeof fn === 'function') { fn(); }
                } else {
                    $scope.$apply(fn);
                }
            }//End of Safe Apply Function
        };
    });

    angular.module("sample")
    .factory("utilityFunctions", ["APP_SETTINGS", "$q", "$http", utilityFunctions]);

    function utilityFunctions(APP_SETTINGS, $q, $http) {

        var resetFeatureForm = function () {
            $("#some-id").data("kendoDropDownList").value(" ");
        };

        var getBranchCodes = function () {
            var branchCodes = [{ lkpColCode: "_", lkpColName: "_" }];
            for (var charCode = 65; charCode <= 90; charCode++) {
                branchCodes.push({ lkpColCode: String.fromCharCode(charCode), lkpColName: String.fromCharCode(charCode) });
            }
            return branchCodes;
        }

        return {
            resetFeatureForm: resetFeatureForm,
            getBranchCodes: getBranchCodes
        }
    }

}());