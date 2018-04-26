import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { NotificationService } from "../Services/notification-service";
import { SecurityService } from "../Services/security-service";


@Component({
    selector: "register",
    templateUrl: "register.component.html"
})
export class RegisterComponent {

    private readonly urlApiBase: string = "api/account";

    constructor(
        private http: HttpClient,
        private router: Router,
        private notify: NotificationService,
        private securityService: SecurityService) { }

    register(viewModel) {
        this.securityService.register(viewModel)
            .subscribe(res => {
                let username: string = viewModel.Username
                let password: string = viewModel.Password
                this.securityService.login({ username, password })
                    .subscribe(res => {
                        this.notify.showSuccess(`User ${res.userName} registration successfully!`)
                        console.dir(res);
                    }, err => {
                        err.error.forEach(msg => this.notify.showError(msg))
                    })
            }, err => {
                err.error.forEach(msg => this.notify.showError(msg))
            });
    }
}