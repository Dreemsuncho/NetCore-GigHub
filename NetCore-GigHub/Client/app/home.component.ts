import { Component } from "@angular/core"


@Component({
    selector:"home",
    template:`
    <div class="jumbotron">
        <h1 class="display-4">
            This is GigHub Application Written in .NET Core & Angular
        </h1>
        <p class="lead mt-1">
            For full feature use, you have to <a routerLink="register">register</a> account, but if you don't want to sign up, you can still look at the public side of GigHub application.
        </p>
        <p class="lead mt-1">
            <a routerLink="gigs/upcoming" class="btn btn-primary btn-lg" role="button">See Upcoming Gigs</a>
        </p>
    </div>`
})
export class HomeComponent {
    
}