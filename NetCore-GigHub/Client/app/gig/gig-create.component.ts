import { Component, OnInit } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { Router } from "@angular/router"
import { NotificationService } from "../Services/notification-service"

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
    this.http.get("api/gigs/genres")
      .subscribe(res => {
        Object.assign(this.genres, res)
      })
  }

  createGig(formValues) {
    let reqBody = formValues
    reqBody.ArtistId = localStorage.getItem("userId")
    if (reqBody.GenreId === "")
      reqBody.GenreId = "0"

    this.http.post("api/gigs/create", reqBody)
      .subscribe(res => {
        console.dir(res)
        this.router.navigate([""])
        this.notify.showSuccess("Your gig was created!")
      })
  }
}

class Genre {
  id: number
  name: string
}
