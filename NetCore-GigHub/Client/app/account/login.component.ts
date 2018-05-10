import { Component, OnInit } from "@angular/core"
import { ActivatedRoute, Router } from "@angular/router"
import { SecurityService } from "../Services/security-service"
import { NotificationService } from "../Services/notification-service"


@Component({
    selector: "login",
    templateUrl: "login.component.html"
})
export class LoginComponent implements OnInit {

    private returnUrl: string

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private securityService: SecurityService,
        private notify: NotificationService) { }

    ngOnInit() {
        this.returnUrl = this.route.snapshot.queryParamMap.get("returnUrl")
    }

    login(viewModel) {
        this.securityService.login(viewModel)
            .subscribe(res => {
                if (this.returnUrl) {
                    this.router.navigate([this.returnUrl])
                } else {
                    this.router.navigate(["/"])
                }
                this.notify.showSuccess(`User ${res.userName} logged in successful`)
            })
    }
}