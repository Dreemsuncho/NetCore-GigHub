import { Component, ElementRef } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http"

@Component({
  selector: "gig-create",
  templateUrl: "./gig-create.component.html",
  styles: []
})
export class GigCreateComponent {

  public genres: any = JSON.parse(this.elementRef.nativeElement.getAttribute("genres"));

  constructor(
    private http: HttpClient,
    private elementRef: ElementRef) {
  }

  createGig(formValues) { 
    let url: string = "Create";
    let reqBody = formValues;

    this.http.post(url, reqBody)
      .subscribe(res => {
        alert("SUCESS!!");
        window["res"] = res || "NO RESUL T!";
        console.log(res)
      }, err => {
        alert("ERROR");
        window["err"] = err.error;
        console.log(window["err"])
      });
  }
}
