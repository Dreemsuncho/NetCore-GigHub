var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
// Angular
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
// Interceptors
import { SecurityInterceptor } from "./Middleware/security.interceptor";
import { JwtInterceptor } from "./Middleware/jwt.interceptor";
// Components
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home.component";
import { HeaderComponent } from "./common/header.component";
import { FooterComponent } from "./common/footer.component";
import { RegisterComponent } from "./account/register.component";
import { LoginComponent } from "./account/login.component";
import { LogoutComponent } from "./account/logout.component";
import { GigCreateComponent } from "./gig/gig-create.component";
import { GigsUpcomingComponent } from "./gig/gigs-upcoming.component";
// Services
import { NotificationService } from "./Services/notification-service";
import { SecurityService } from "./Services/security-service";
var routes = [
    { path: "", component: HomeComponent },
    { path: "register", component: RegisterComponent },
    { path: "login", component: LoginComponent },
    { path: "logout", component: LogoutComponent },
    { path: "gigs/create", component: GigCreateComponent },
    { path: "gigs/upcoming", component: GigsUpcomingComponent },
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                HomeComponent,
                HeaderComponent,
                FooterComponent,
                RegisterComponent,
                LoginComponent,
                LogoutComponent,
                GigCreateComponent,
                GigsUpcomingComponent
            ],
            imports: [
                BrowserModule,
                FormsModule,
                HttpClientModule,
                RouterModule.forRoot(routes, { useHash: true, enableTracing: false })
            ],
            providers: [
                NotificationService,
                SecurityService,
                [
                    { provide: HTTP_INTERCEPTORS, useClass: SecurityInterceptor, multi: true },
                    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
                ]
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map