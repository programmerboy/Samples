//Angular Controller
(function () {
    'use strict';

    angular.module('sample')
    .controller('sampleCtrl', [
        //"authentication",
        "$scope",
        "$http",
        "$q",
        "commonFunctions",
        //"commonKendoFunctions",
        "commonNgFunctionsCtrl",
        "APP_SETTINGS",
        "filterFilter",
        sampleCtrl])

    /** @ngInject */
    function sampleCtrl($scope, $http, $q, commonFunctions, commonNgFunctionsCtrl, APP_SETTINGS, filterFilter) {

        var apiURL = APP_SETTINGS.WEB_API_PATH;
        var baseURL = $("base").attr("href");
        var vm = this;

        var ctrl = this;

        ctrl.array = [{ name: 'Tobias' }, { name: 'Jeff' }, { name: 'Brian' }, { name: 'Igor' }, { name: 'James' }, { name: 'Brad' }];
        ctrl.filteredArray = filterFilter(this.array, ctrl.filterBy);

        ctrl.openSimpleModal = function () {
            commonNgFunctionsCtrl.openSimpleAlert("Created", "Filtered Array", JSON.stringify(filterFilter(this.array, ctrl.filterBy)), "alert alert-info");
        };

        //Following function triggers after ng-include has loaded its content
        //It is specially written to handle Panel Close Open Icon Toggle Functionality
        //$scope.$on('$includeContentLoaded', function () {
        //    $('.panel-group .collapse').on('shown.bs.collapse', commonFunctions.togglePanelIcon).on('hidden.bs.collapse', commonFunctions.togglePanelIcon);
        //});

        //This function is specially programmed to add Toggle functionality on the Accordion Panel Title Icon
        vm.IncludeLoaded = function (id) { $(id).on('shown.bs.collapse', commonFunctions.togglePanelIcon).on('hidden.bs.collapse', commonFunctions.togglePanelIcon); };

    }//END of Controller Function
}());