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
var NotificationService = /** @class */ (function () {
    function NotificationService() {
        this.toastr = window["toastr"];
    }
    NotificationService.prototype.showError = function (message) {
        this.toastr.error(message);
    };
    NotificationService.prototype.showInfo = function (message) {
        this.toastr.info(message);
    };
    NotificationService.prototype.showSuccess = function (message) {
        this.toastr.success(message);
    };
    NotificationService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [])
    ], NotificationService);
    return NotificationService;
}());
export { NotificationService };
//# sourceMappingURL=notification-service.js.map