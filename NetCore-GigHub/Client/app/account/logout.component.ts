import { Component, OnInit } from "@angular/core"
import { Router } from "@angular/router"

import { SecurityService } from "../Services/security-service"
import { NotificationService } from "../Services/notification-service"


@Component({
    selector: "logout",
    templateUrl: "./logout.component.html"
})
export class LogoutComponent implements OnInit {
    constructor(
        private securityService: SecurityService,
        private router: Router,
        private notify: NotificationService) { }

    ngOnInit() {
        this.securityService.logout()
        this.router.navigate["/"]
        this.notify.showSuccess("Logout Successfully")
    }
}