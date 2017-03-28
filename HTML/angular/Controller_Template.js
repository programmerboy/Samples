//Angular Controller
(function () {
    'use strict';

    angular.module('sample')
    .controller('someNameCtrl', ['authentication', "$scope", "$http", "$q", "commonFunctions", "commonKendoFunctions", "commonNgFunctionsCtrl", "APP_SETTINGS", someNameCtrl])

    /** @ngInject */
    function someNameCtrl(authentication, $scope, $http, $q, commonFunctions, commonKendoFunctions, commonNgFunctionsCtrl, APP_SETTINGS) {

        var DEVICE_TYPE = getDeviceType();
        var apiURL = APP_SETTINGS.WEB_API_PATH;
        var baseURL = $("base").attr("href");
        var vm = this;

        vm.isProcessing = false;

        var httpRequest = commonFunctions.getRequestObject("GET", apiURL + "GetOrders");
        $http(httpRequest).then(function successCallback(response) { console.log(response.data); }, displayError);


        function displayError(error) {
            vm.errorMessage = commonFunctions.displayError(error);
            vm.isProcessing = false;
        }

        function resetForProcessing(selector) {
            vm.errorMessage = "";
            vm.isProcessing = true;
            if (selector) selector.prepend($("#loading-icon"));
        }

        vm.closeAlert = function () { vm.message = ""; vm.errorMessage = ""; };

        //Following function triggers after ng-include has loaded its content
        //It is specially written to handle Panel Close Open Icon Toggle Functionality
        //$scope.$on('$includeContentLoaded', function () {
        //    $('.panel-group .collapse').on('shown.bs.collapse', commonFunctions.togglePanelIcon).on('hidden.bs.collapse', commonFunctions.togglePanelIcon);
        //});

        //This function is specially programmed to add Toggle functionality on the Accordion Panel Title Icon
        vm.IncludeLoaded = function (id) { $(id).on('shown.bs.collapse', commonFunctions.togglePanelIcon).on('hidden.bs.collapse', commonFunctions.togglePanelIcon); };

    }//END of Controller Function
}());