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
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { NotificationService } from "../Services/notification-service";
import { tap } from "rxjs/operators/tap";
var SecurityInterceptor = /** @class */ (function () {
    function SecurityInterceptor(router, notify) {
        this.router = router;
        this.notify = notify;
    }
    SecurityInterceptor.prototype.intercept = function (req, next) {
        var _this = this;
        console.dir(req);
        return next.handle(req).pipe(tap(function () { }, function (err) {
            if (err instanceof HttpErrorResponse && err.status === 401) {
                var returnUrl = err.url.split("/").pop().replace("get", "");
                _this.router.navigate(["login"], { queryParams: { returnUrl: returnUrl } });
                _this.notify.showError("You have to login for access this route");
            }
            else if (err.error.values instanceof Array) {
                err.error.values.forEach(function (msg) { return _this.notify.showError(msg); });
                console.dir(err);
            }
        }));
    };
    SecurityInterceptor = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [Router,
            NotificationService])
    ], SecurityInterceptor);
    return SecurityInterceptor;
}());
export { SecurityInterceptor };
//# sourceMappingURL=security.interceptor.js.map