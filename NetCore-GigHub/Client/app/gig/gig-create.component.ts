import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Router } from '@angular/router';
import { NotificationService } from '../Services/notification-service';

@Component({
  selector: "gig-create",
  templateUrl: "./gig-create.component.html",
  styles: []
})
export class GigCreateComponent implements OnInit {

  public genres: Genre[] = []

  constructor(
    private http: HttpClient,
    private router: Router,
    private notify: NotificationService) { }

  ngOnInit() {
    this.http.get("gigs/getgenres")
      .subscribe(res => {
        Object.assign(this.genres, res)
      }, err => {
        alert("Error!");
        console.dir(err);
      })
  }

  createGig(formValues) {
    let reqBody = formValues;
    reqBody.ArtistId = localStorage.getItem("userId")
    if (reqBody.GenreId === "")
      reqBody.GenreId = "0";

    this.http.post("gigs/create", reqBody)
      .subscribe(res => {
        console.dir(res)
        this.router.navigate([""])
        this.notify.showSuccess("Your gig was created!")
      }, err => {
        console.dir(err)
        err.error.forEach(msg => this.notify.showError(msg))
      });
  }
}

class Genre {
  id: number
  name: string
}
