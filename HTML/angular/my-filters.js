//Angular Module
(function () {
    'use strict';

    var WEB_API_PATH = "http://localhost:49742/api/"
    var app = angular.module("sample")

    app.filter('htmlToPlaintext', function () {
        return function (text) { return text ? String(text).replace(/<[^>]+>/gm, '') : ''; };
    })

    app.filter('removeSpaces', function () {
        return function (text) { return text ? String(text).replace(/ /gm, '+') : ''; };
    })

    ///////////////////////////////////////////////////////////
    ///////////////////////END OF IIFE/////////////////////////
    ///////////////////////////////////////////////////////////

}());