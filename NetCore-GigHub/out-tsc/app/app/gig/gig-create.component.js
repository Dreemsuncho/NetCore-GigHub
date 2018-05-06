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
import { Router } from "@angular/router";
import { NotificationService } from "../Services/notification-service";
var GigCreateComponent = /** @class */ (function () {
    function GigCreateComponent(http, router, notify) {
        this.http = http;
        this.router = router;
        this.notify = notify;
        this.genres = [];
    }
    GigCreateComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.http.get("api/gigs/getgenres")
            .subscribe(function (res) {
            Object.assign(_this.genres, res);
        });
    };
    GigCreateComponent.prototype.createGig = function (formValues) {
        var _this = this;
        var reqBody = formValues;
        reqBody.ArtistId = localStorage.getItem("userId");
        if (reqBody.GenreId === "")
            reqBody.GenreId = "0";
        this.http.post("api/gigs/create", reqBody)
            .subscribe(function (res) {
            console.dir(res);
            _this.router.navigate([""]);
            _this.notify.showSuccess("Your gig was created!");
        });
    };
    GigCreateComponent = __decorate([
        Component({
            selector: "gig-create",
            templateUrl: "./gig-create.component.html",
            styles: []
        }),
        __metadata("design:paramtypes", [HttpClient,
            Router,
            NotificationService])
    ], GigCreateComponent);
    return GigCreateComponent;
}());
export { GigCreateComponent };
var Genre = /** @class */ (function () {
    function Genre() {
    }
    return Genre;
}());
//# sourceMappingURL=gig-create.component.js.map