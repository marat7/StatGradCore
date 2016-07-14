"use strict";
var Directory = (function () {
    function Directory(name, directories, files) {
        this.name = name;
        this.directories = directories;
        this.files = files;
        this.expanded = false;
        this.checked = false;
    }
    Directory.prototype.toogle = function () {
        this.expanded = !this.expanded;
    };
    Directory.prototype.check = function () {
        var newState = !this.checked;
        this.checked = newState;
        this.checkRecursive(newState);
    };
    Directory.prototype.checkRecursive = function (state) {
        this.directories.forEach(function (d) {
            d.checked = state;
            d.checkRecursive(state);
        });
    };
    return Directory;
}());
exports.Directory = Directory;
