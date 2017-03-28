(function () {
    "use strict";

    angular.module('sample').factory('authentication', ["$resource", "APP_SETTINGS", authentication]);

    function authentication($resource, APP_SETTINGS) {
        var baseURL = $("base").attr("href");
        var resource = $resource(baseURL + 'Login/GetUserGroups', {}, { 'get': { method: 'GET', isArray: true }, 'query': { method: 'GET', isArray: true } });
        return resource;
    }

}());