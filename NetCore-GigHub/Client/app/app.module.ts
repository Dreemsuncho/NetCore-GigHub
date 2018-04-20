import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";


import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header.component';
import { FooterComponent } from './shared/footer.component';
import { RegisterComponent } from './account/register.component';
import { LoginComponent } from './account/login.component';
import { GigCreateComponent } from './gig-create.component';

let routes = [
  { path: "register", component: RegisterComponent },
  { path: "login", component: LoginComponent }
]
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    RegisterComponent,
    LoginComponent,
    GigCreateComponent
  ],
  imports: [        
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes, { useHash: true, enableTracing: false })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
