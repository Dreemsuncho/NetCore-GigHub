import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";


@Component({
    selector: "gigs-upcoming",
    templateUrl: "./gigs-upcoming.component.html"
})
export class GigsUpcomingComponent implements OnInit {

    public pageTitle:string = "Upcoming gigs"
    public gigs: VmGig[] = []
    public showActions: boolean = true

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.http.get<VmGig[]>("gigs/getupcoming")
            .subscribe(res => {
                this.gigs = res
                console.dir(res)
                console.dir(this.gigs)
            }, err => {
                console.dir(err)
            });
    }

    toggleFollow(gigId) {
        alert(gigId)
    }
    toggleGoing(gigId) {
        alert(gigId)
    }

}

class VmGig {
    id: number
    artist: { userName: string }
    dateTime: Date
    genre: { name: string }
    venue: string
}