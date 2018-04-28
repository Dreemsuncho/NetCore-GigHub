
// core
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { Routes } from '@angular/router/src/config';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
// components
import { AppComponent } from './app.component';
import { HeaderComponent } from './common/header.component';
import { FooterComponent } from './common/footer.component';
import { RegisterComponent } from './account/register.component';
import { LoginComponent } from './account/login.component';
import { LogoutComponent } from './account/logout.component';
import { GigCreateComponent } from './gig/gig-create.component';
import { GigsUpcomingComponent } from './gig/gigs-upcoming.component';
// services
import { NotificationService } from './Services/notification-service';
import { SecurityService } from './Services/security-service';


let routes: Routes = [
  { path: "", component: GigsUpcomingComponent },
  { path: "register", component: RegisterComponent },
  { path: "login", component: LoginComponent },
  { path: "logout", component: LogoutComponent },
  { path: "gigs/create", component: GigCreateComponent },
]

@NgModule({
  declarations: [
    AppComponent,
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
    SecurityService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
