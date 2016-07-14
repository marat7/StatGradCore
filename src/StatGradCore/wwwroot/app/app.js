"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require('angular2/core');
var browser_1 = require('angular2/platform/browser');
var treeview_ts_1 = require('./treeview.ts');
var directory_ts_1 = require('./directory.ts');
var AppComponent = (function () {
    function AppComponent() {
        var PremierLeague = new directory_ts_1.Directory('Premier League', [], ['Arsenal', 'Chelsea', 'Liverpool', 'Man Unt']);
        var Primera = new directory_ts_1.Directory('Primera', [], ['Bercelona', 'Real Madrid', 'Atletico M']);
        var Leagues = new directory_ts_1.Directory('Leagues', [PremierLeague, Primera], []);
        var Teams = new directory_ts_1.Directory('Teams', [], ['Bayern', 'Milan']);
        this.directories = [Leagues, Teams];
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: '<treeview [directories]="directories"></treeview>',
            directives: [treeview_ts_1.TreeView]
        })
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
browser_1.bootstrap(AppComponent);
