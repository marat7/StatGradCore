"use strict";
///<reference path="../../node_modules/angular2/typings/browser.d.ts"/> 
var browser_1 = require("angular2/platform/browser");
var router_1 = require("angular2/router");
var http_1 = require("angular2/http");
var app_1 = require("./app");
browser_1.bootstrap(app_1.AppComponent, [router_1.ROUTER_PROVIDERS, http_1.HTTP_PROVIDERS]);
