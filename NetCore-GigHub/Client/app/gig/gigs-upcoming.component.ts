import { Component, OnInit } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { NotificationService } from "../Services/notification-service"

@Component({
    selector: "gigs-upcoming",
    templateUrl: "./gigs-upcoming.component.html"
})
export class GigsUpcomingComponent implements OnInit {

    private urlApi: string = "api/gigs"

    public pageTitle: string = "Upcoming gigs"
    public gigs: VmGig[] = []
    public showActions: boolean

    constructor(
        private http: HttpClient,
        private notify: NotificationService) { }

    ngOnInit() {
        this.http.get<VmGig[]>(this.urlApi + "/upcoming")
            .subscribe(res => {
                this.showActions = res["isAuthenticated"]
                this.gigs = res["gigs"]
            })
    }

    toggleFollow(followeeId) {
        this.http.post("api/followings/follow", followeeId)
            .subscribe(_ => {
                this.notify.showSuccess("Successfully follow user '" + followeeId + "'")
            })
    }

    toggleGoing(gigId) {
        this.http.post("api/attendances/attend", gigId)
            .subscribe(_ => {
                this.notify.showSuccess("Successfully attend to gig '" + gigId + "'")
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