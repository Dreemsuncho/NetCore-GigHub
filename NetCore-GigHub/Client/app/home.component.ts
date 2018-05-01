import { Component } from "@angular/core";


@Component({
    selector:"home",
    template:`
    <div class="jumbotron">
        <h1 class="display-4">
            This is GigHub Application Written in .NET Core & Angular
        </h1>
        <p class="lead mt-1">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
        </p>
        <p class="lead mt-1">
            <a routerLink="gigs/upcoming" class="btn btn-primary btn-lg" role="button">See Upcoming Gigs</a>
        </p>
    </div>`
})
export class HomeComponent {
    
}