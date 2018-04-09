import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { NgModule } from '@angular/core';


import { GigCreateComponent } from './gig-create.component';



@NgModule({
  declarations: [
    GigCreateComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [GigCreateComponent]
})
export class AppModule { }
