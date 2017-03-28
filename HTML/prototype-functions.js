//////////////////////////////////////////////////
/////////////// STRING FUNCTIONS   ///////////////
//////////////////////////////////////////////////

String.prototype.toProperCase = function () {
    return this.replace(/\w\S*/g, function (txt) {
        return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
    });
};

String.prototype.toCamelCase = function () {
    return this.replace(/([A-Z])/g, "$1", function (result) {
        return result.charAt(0).toLowerCase() + result.slice(1);
    });
};
String.prototype.toPascallCase = function () {
    return this.replace(/([A-Z])/g, "$1", function (result) {
        return result.charAt(0).toUpperCase() + result.slice(1);
    });
};

String.prototype.splitCamelCase = function () {
    return this.split(/(?=[A-Z])/).join(' ')
};


String.prototype.getLastPart = function (separator) {
    if (!this) { return ""; }
    if (!separator) separator = "\\";
    if (this.indexOf(separator) < 0) { return this; }
    return this.substring(this.lastIndexOf(separator) + 1);
};

String.prototype.getDatePortionFromDateTime = function () {
    var pattern = /(0*)(.+)T.*/;
    var results = pattern.exec(this);
    results = results[1].replace(/00/g, '20') + results[2];
    results = results.replace(/-/g, '/');
    var dt = new Date(results);
    return dt;
};


//////////////////////////////////////////////////
/////////////// NUMBER FUNCTIONS   ///////////////
//////////////////////////////////////////////////

Number.prototype.padZero = function () {
    return ("0" + this).slice(-2);
}

//////////////////////////////////////////////////
/////////////// DATE FUNCTIONS   ///////////////
//////////////////////////////////////////////////

//Removes the Time Portion from the supplied dates
Date.prototype.withoutTime = function () {
    var d = new Date(this);
    d.setHours(0, 0, 0, 0);
    return d;
}

//////////////////////////////////////////////////
/////////////// ARRAY FUNCTIONS   ///////////////
//////////////////////////////////////////////////

//Returns a unique Array back
Array.prototype.unique = function () {
    var unique = [];
    for (var i = 0; i < this.length; i++) {
        if (unique.indexOf(this[i]) == -1) {
            unique.push(this[i]);
        }
    }
    return unique;
};