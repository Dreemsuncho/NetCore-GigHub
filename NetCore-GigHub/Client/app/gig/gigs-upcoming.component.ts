import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router, NavigationExtras } from '@angular/router';

@Component({
    selector: "gigs-upcoming",
    templateUrl: "./gigs-upcoming.component.html"
})
export class GigsUpcomingComponent implements OnInit {

    public pageTitle: string = "Upcoming gigs"
    public gigs: VmGig[] = []
    public showActions: boolean = true

    constructor(
        private http: HttpClient,
        private router: Router) { }

    ngOnInit() {
        this.http.get<VmGig[]>("api/gigs/getupcoming")
            .subscribe(res => {
                this.gigs = res
                console.dir(res)
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
    artist: {
        userName: string,
        id: number
    }
    dateTime: Date
    genre: { name: string }
    venue: string
}