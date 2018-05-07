import { Component } from "@angular/core"
import { NotificationService } from "../Services/notification-service"
import { SecurityService } from "../Services/security-service"


@Component({
    selector: "register",
    templateUrl: "register.component.html"
})
export class RegisterComponent {


    constructor(
        private notify: NotificationService,
        private securityService: SecurityService) { }

    register(viewModel) {
        this.securityService.register(viewModel)
            .subscribe(() => {
                    let username: string = viewModel.Username
                    let password: string = viewModel.Password

                    this.securityService.login({ username, password })
                        .subscribe(res => {
                            this.notify.showSuccess(`User ${res.userName} registration successfully!`)
                            console.dir(res)
                        })
                        
                })
    }
}