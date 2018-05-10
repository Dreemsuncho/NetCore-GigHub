import { Component, OnInit } from "@angular/core"
import { HttpClient } from "@angular/common/http"

@Component({
    selector: "gigs-upcoming",
    templateUrl: "./gigs-upcoming.component.html"
})
export class GigsUpcomingComponent implements OnInit {

    public pageTitle: string = "Upcoming gigs"
    public gigs: VmGig[] = []
    public showActions: boolean = true

    constructor(
        private http: HttpClient) { }

    ngOnInit() {
        this.http.get<VmGig[]>("api/gigs/upcoming")
            .subscribe(res => {
                this.showActions = res["isAuthenticated"]
                this.gigs = res["gigs"]
                console.dir(res)
            })
    }

    toggleFollow() {
        this.http.post("api/followings/follow", 1003)
            .subscribe(res => {
                alert("SUCCESS FOLLOW!")
                console.dir(res)
            })
    }

    toggleGoing(gigId) {
        this.http.post("api/attendances/attend", gigId)
            .subscribe(res => {
                alert("SUCCESS Attend!")
                console.dir(res)
            })
    }
}

class VmGig {
    id: number
    artist: {
        userName: string,
        id: number
    }
    dateTime: Date
    genre: { name: string }
    venue: string
}