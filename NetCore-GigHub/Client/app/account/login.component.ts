import { Component, OnInit } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { ActivatedRoute, Router } from "@angular/router"
import { SecurityService } from "../Services/security-service"
import { NotificationService } from "../Services/notification-service"


@Component({
    selector: "login",
    templateUrl: "login.component.html"
})
export class LoginComponent implements OnInit {

    private readonly urlApiBase: string = "api/account"
    private returnUrl: string;

    constructor(
        private http: HttpClient,
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
                    this.router.navigateByUrl(this.returnUrl)
                }
                this.notify.showSuccess(`User ${res.userName} logged in successful`)
                console.dir(res)
            }, err => {
                err.error.forEach(msg => this.notify.showError(msg))
                console.dir(err)
            })
    }
}