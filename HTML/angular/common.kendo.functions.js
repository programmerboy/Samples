(function () {
    "use strict";

    angular.module("sample")
    .factory("commonKendoFunctions", [commonKendoFunctions]);

    function commonKendoFunctions() {

        //Function to Load Kendo Multi Select Option
        var loadMultiSelect = function (placeholder, dataTextField, dataValueField, valuePrimitive, autoBind, dataSource, initialValue, changeFunc, dataBoundFunc, openFunc, closeFunc) {
            var options = {};

            if (placeholder) { options.placeholder = placeholder; }
            if (dataTextField) { options.dataTextField = dataTextField; }
            if (dataValueField) { options.dataValueField = dataValueField; }
            if (valuePrimitive) { options.valuePrimitive = valuePrimitive; }
            if (autoBind) { options.autoBind = autoBind; }
            if (dataSource) { options.dataSource = dataSource; }
            if (initialValue) { options.value = initialValue; }
            if (changeFunc) { options.change = changeFunc; }
            if (dataBoundFunc) { options.dataBound = dataBoundFunc; }
            if (openFunc) { options.open = openFunc; }
            if (closeFunc) { options.close = closeFunc; }

            options.autoClose = false;
            options.filter = "Contains";

            return options;
        }//End of Function

        //Function to Load Kendo Multi Select
        var loadMultiSelectSelector = function (selector, placeholder, dataTextField, dataValueField, valuePrimitive, autoBind, dataSource, initialValue, changeFunc, dataBoundFunc, openFunc, closeFunc) {

            var options = {};

            if (placeholder) { options.placeholder = placeholder; }
            if (dataTextField) { options.dataTextField = dataTextField; }
            if (dataValueField) { options.dataValueField = dataValueField; }
            if (valuePrimitive) { options.valuePrimitive = valuePrimitive; }
            if (autoBind) { options.autoBind = autoBind; }
            if (dataSource) { options.dataSource = dataSource; }
            if (initialValue) { options.value = initialValue; }
            if (changeFunc) { options.change = changeFunc; }
            if (dataBoundFunc) { options.dataBound = dataBoundFunc; }
            if (openFunc) { options.open = openFunc; }
            if (closeFunc) { options.close = closeFunc; }

            options.autoClose = false;
            options.filter = "Contains";

            selector.kendoMultiSelect(options);
            return selector.data("kendoMultiSelect");
        }//End of Function

        //Set Kendo DropDown Options
        function getDropwDownOptions(sourceURL, textField, valueField, value, optionLabel, changeFunc, dataBoundFunc, openFunc, closeFunc, selectFunc) {

            var options = {};

            if (sourceURL) { options.dataSource = getDataSource(sourceURL); }
            if (textField) { options.dataTextField = textField; }
            if (valueField) { options.dataValueField = valueField; }
            if (optionLabel) { options.optionLabel = optionLabel; }
            if (value) { options.value = value; }

            if (changeFunc) { options.change = changeFunc; }
            if (dataBoundFunc) { options.dataBound = dataBoundFunc; }
            if (openFunc) { options.open = openFunc; }
            if (closeFunc) { options.close = closeFunc; }
            if (selectFunc) { options.select = selectFunc; }

            //options.footerTemplate = "<div style='padding:3px 0;'><strong>#: instance.dataSource.total() #</strong> items</div>";
            //options.filter = "Contains", //"startswith";

            return options;

        }//END of Function

        //Set Kendo DropDown Options
        function getDropwDownOptionsDS(dataSource, textField, valueField, value, optionLabel, changeFunc, dataBoundFunc, openFunc, closeFunc, selectFunc) {
            var options = {};

            if (dataSource) { options.dataSource = dataSource; }
            if (textField) { options.dataTextField = textField; }
            if (valueField) { options.dataValueField = valueField; }
            if (optionLabel) { options.optionLabel = optionLabel; }
            if (value) { options.value = value; }

            if (changeFunc) { options.change = changeFunc; }
            if (dataBoundFunc) { options.dataBound = dataBoundFunc; }
            if (openFunc) { options.open = openFunc; }
            if (closeFunc) { options.close = closeFunc; }
            if (selectFunc) { options.select = selectFunc; }

            //options.footerTemplate = "<div style='padding:3px 0;'><strong>#: instance.dataSource.total() #</strong> items</div>";
            //options.filter = "Contains", //"startswith";

            return options;
        }//END of Function


        //Return Datasource
        //If Windows Authentication is set then we need Request to send Credentials using [xhrFields: { withCredentials: true }]
        //Also make sure [SupportsCredentials = true] is set in the CORS attribute in WebAPI
        //Not doing so will cause 401 Unauthorized error
        var getDataSource = function (sourceURL) {
            return {
                transport: {
                    read: {
                        url: sourceURL, type: "GET",
                        xhrFields: { withCredentials: true }
                    }
                }
            };
        }//END of Function


        /************** Events /**************/
        function onSelect(e) {
            if ("console" in window) {
                var dataItem = this.dataItem(e.item);
                console.log("event :: select (" + dataItem.LKP_COLUMN_NAME + " : " + dataItem.LKP_COLUMN_CODE + ")");
            }
        };

        /************** END Events /**************/

        return {
            loadMultiSelect: loadMultiSelect,
            loadMultiSelectSelector: loadMultiSelectSelector,
            getDropwDownOptions: getDropwDownOptions,
            getDropwDownOptionsDS: getDropwDownOptionsDS,
            getDataSource: getDataSource
        }
    }
}());