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

  private readonly apiUrl = "api/gigs"
  public genres: Genre[] = []

  constructor(
    private http: HttpClient,
    private router: Router,
    private notify: NotificationService) { }

  ngOnInit() {
    this.http.get(this.apiUrl + "/genres")
      .subscribe(res => {
        Object.assign(this.genres, res)
      })
  }

  createGig(reqBody) {
    reqBody.GenreId = reqBody.GenreId || "0"

    this.http.post(this.apiUrl + "/create", reqBody)
      .subscribe(_ => {
        this.router.navigate(["gigs/upcoming"])
        this.notify.showSuccess("Your gig was created!")
      })
  }
}

class Genre {
  id: number
  name: string
}
