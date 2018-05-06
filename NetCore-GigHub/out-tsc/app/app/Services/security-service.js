var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { tap } from "rxjs/operators";
var SecurityService = /** @class */ (function () {
    function SecurityService(http) {
        this.http = http;
        this.urlApiBase = "api/account";
        this.userIdKey = "userId";
        this.userNameKey = "userName";
        this.tokenKey = "bearerToken";
        this.authObject = new AuthObject;
    }
    SecurityService.prototype.register = function (viewModel) {
        return this.http.post(this.urlApiBase + "/register", viewModel);
    };
    SecurityService.prototype.login = function (viewModel) {
        var _this = this;
        return this.http.post(this.urlApiBase + "/login", viewModel)
            .pipe(tap(function (res) {
            Object.assign(_this.authObject, res);
            localStorage.setItem(_this.userIdKey, "" + _this.authObject.userId);
            localStorage.setItem(_this.userNameKey, _this.authObject.userName);
            localStorage.setItem(_this.tokenKey, _this.authObject.bearerToken);
        }));
    };
    SecurityService.prototype.logout = function () {
        this.resetAuthObject();
    };
    SecurityService.prototype.getTokenBearer = function () {
        return localStorage.getItem(this.tokenKey);
    };
    SecurityService.prototype.resetAuthObject = function () {
        this.authObject.userId = null;
        this.authObject.userName = null;
        this.authObject.bearerToken = null;
        this.authObject.isAuthenticated = false;
        this.authObject.claims = [];
        localStorage.removeItem(this.userIdKey);
        localStorage.removeItem(this.userNameKey);
        localStorage.removeItem(this.tokenKey);
    };
    SecurityService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], SecurityService);
    return SecurityService;
}());
export { SecurityService };
var AuthObject = /** @class */ (function () {
    function AuthObject() {
        this.isAuthenticated = false;
        this.claims = [];
    }
    return AuthObject;
}());
var ClaimUser = /** @class */ (function () {
    function ClaimUser() {
    }
    return ClaimUser;
}());
//# sourceMappingURL=security-service.js.map