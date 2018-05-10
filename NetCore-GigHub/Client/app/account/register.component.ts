import { Component } from "@angular/core"
import { Router } from "@angular/router"

import { NotificationService } from "../Services/notification-service"
import { SecurityService } from "../Services/security-service"


@Component({
    selector: "register",
    templateUrl: "register.component.html"
})
export class RegisterComponent {


    constructor(
        private router: Router,
        private notify: NotificationService,
        private securityService: SecurityService) { }

    register(viewModel) {
        this.securityService.register(viewModel)
            .subscribe(_ => {
                let username: string = viewModel.Username
                let password: string = viewModel.Password
                
                this.notify.showSuccess(`User ${username} registration successfully!`)
                
                this.securityService.login({ username, password })
                    .subscribe(_ => {
                        this.router.navigate(["/"])
                    })
            })
    }
}