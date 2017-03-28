//Angular Controller
(function () {
    'use strict';

    angular.module('sample')
    .factory('lookupFactory', ["$http", "$q", "commonFunctions", "commonNgFunctionsCtrl", "scopeService", "APP_SETTINGS", lookupCtrl])

    /** @ngInject */
    function lookupCtrl($http, $q, commonFunctions, commonNgFunctionsCtrl, scopeService, APP_SETTINGS, $scope) {

        var apiURL = APP_SETTINGS.WEB_API_PATH;
        var httpRequest;

        ////////////////////////////////////////////////////////
        ////////////////////////  TYPES ////////////////////////
        ////////////////////////////////////////////////////////

        //Get Stop Comment Types
        var getProductNames = function () {
            var deferred = $q.defer();
            httpRequest = commonFunctions.getRequestObject("GET", apiURL + "GetProductNames");
            $http(httpRequest).then(function successCallBack(response) { deferred.resolve(response.data); }, errorCallBack);
            return deferred.promise;
        };

        ///////////////////////////////////////////////////////////////
        ////////////////////// COMMON FUNCTIONS ///////////////////////
        ///////////////////////////////////////////////////////////////

        function errorCallBack(error) {
            console.log(error)
            commonNgFunctionsCtrl.openErrorAlert("Lookup Ctrl", "Error in Lookup Ctrl");
        }

        return {
            //TYPES
            getProductNames: getProductNames
        }

    }//END of Controller Function
}());