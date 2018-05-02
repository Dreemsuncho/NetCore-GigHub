
// Angular
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { Routes } from '@angular/router/src/config';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
// Interceptors
import { SecurityInterceptor } from './Middleware/security.interceptor';
import { JwtInterceptor } from "./Middleware/jwt.interceptor";
// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home.component';
import { HeaderComponent } from './common/header.component';
import { FooterComponent } from './common/footer.component';
import { RegisterComponent } from './account/register.component';
import { LoginComponent } from './account/login.component';
import { LogoutComponent } from './account/logout.component';
import { GigCreateComponent } from './gig/gig-create.component';
import { GigsUpcomingComponent } from './gig/gigs-upcoming.component';
// Services
import { NotificationService } from './Services/notification-service';
import { SecurityService } from './Services/security-service';


let routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "register", component: RegisterComponent },
  { path: "login", component: LoginComponent },
  { path: "logout", component: LogoutComponent },
  { path: "gigs/create", component: GigCreateComponent },
  { path: "gigs/upcoming", component: GigsUpcomingComponent },
]

@NgModule({
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
export class AppModule { }
