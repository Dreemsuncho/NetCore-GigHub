var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from "@angular/core";
var HomeComponent = /** @class */ (function () {
    function HomeComponent() {
    }
    HomeComponent = __decorate([
        Component({
            selector: "home",
            template: "\n    <div class=\"jumbotron\">\n        <h1 class=\"display-4\">\n            This is GigHub Application Written in .NET Core & Angular\n        </h1>\n        <p class=\"lead mt-1\">\n            For full feature use, you have to <a routerLink=\"register\">register</a> account, but if you don't want to sign up, you can still look at the public side of GigHub application.\n        </p>\n        <p class=\"lead mt-1\">\n            <a routerLink=\"gigs/upcoming\" class=\"btn btn-primary btn-lg\" role=\"button\">See Upcoming Gigs</a>\n        </p>\n    </div>"
        })
    ], HomeComponent);
    return HomeComponent;
}());
export { HomeComponent };
//# sourceMappingURL=home.component.js.map