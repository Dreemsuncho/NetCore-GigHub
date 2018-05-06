var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { SecurityService } from "../Services/security-service";
import { NotificationService } from "../Services/notification-service";
var LoginComponent = /** @class */ (function () {
    function LoginComponent(route, router, securityService, notify) {
        this.route = route;
        this.router = router;
        this.securityService = securityService;
        this.notify = notify;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.returnUrl = this.route.snapshot.queryParamMap.get("returnUrl");
    };
    LoginComponent.prototype.login = function (viewModel) {
        var _this = this;
        this.securityService.login(viewModel)
            .subscribe(function (res) {
            if (_this.returnUrl) {
                _this.router.navigateByUrl("gigs/" + _this.returnUrl.split("/").pop().replace("get", ""));
            }
            _this.notify.showSuccess("User " + res.userName + " logged in successful");
            console.dir(res);
        });
    };
    LoginComponent = __decorate([
        Component({
            selector: "login",
            templateUrl: "login.component.html"
        }),
        __metadata("design:paramtypes", [ActivatedRoute,
            Router,
            SecurityService,
            NotificationService])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map