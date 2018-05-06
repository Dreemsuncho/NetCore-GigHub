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
import { HttpClient } from "@angular/common/http";
var GigsUpcomingComponent = /** @class */ (function () {
    function GigsUpcomingComponent(http) {
        this.http = http;
        this.pageTitle = "Upcoming gigs";
        this.gigs = [];
        this.showActions = true;
    }
    GigsUpcomingComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.http.get("api/gigs/getupcoming")
            .subscribe(function (res) {
            _this.gigs = res;
            console.dir(res);
        });
    };
    GigsUpcomingComponent.prototype.toggleFollow = function (gigId) {
        alert(gigId);
    };
    GigsUpcomingComponent.prototype.toggleGoing = function (gigId) {
        this.http.post("api/attendances/attend", gigId)
            .subscribe(function (res) {
            alert("SUCCESS!");
            console.dir(res);
        });
    };
    GigsUpcomingComponent = __decorate([
        Component({
            selector: "gigs-upcoming",
            templateUrl: "./gigs-upcoming.component.html"
        }),
        __metadata("design:paramtypes", [HttpClient])
    ], GigsUpcomingComponent);
    return GigsUpcomingComponent;
}());
export { GigsUpcomingComponent };
var VmGig = /** @class */ (function () {
    function VmGig() {
    }
    return VmGig;
}());
//# sourceMappingURL=gigs-upcoming.component.js.map