"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var GigCreateComponent = /** @class */ (function () {
    function GigCreateComponent() {
        this.genres = [
            { id: "id1", title: "Genre1" },
            { id: "id2", title: "Genre2" },
            { id: "id3", title: "Genre3" },
            { id: "id4", title: "Genre4" },
            { id: "id5", title: "Genre5" },
            { id: "id6", title: "Genre6" }
        ];
    }
    GigCreateComponent = __decorate([
        core_1.Component({
            selector: 'gig-create',
            templateUrl: "./gig-create.component.html",
            styles: []
        })
    ], GigCreateComponent);
    return GigCreateComponent;
}());
exports.GigCreateComponent = GigCreateComponent;
//# sourceMappingURL=gig-create.component.js.map