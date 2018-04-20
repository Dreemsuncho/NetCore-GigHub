import { Component } from "@angular/core";
import { HttpClient } from "@angular/common/http";


@Component({
    selector: "register",
    templateUrl: "register.component.html"
})
export class RegisterComponent {

    constructor(
        private http: HttpClient) { }

    register(viewModel) {
        window["res"] = viewModel;
        this.http.post("account/register", viewModel)
            .subscribe(res => {
                alert("SUCCESS!!");
                console.dir(res);
            }, err => {
                alert("ERROR!");
                console.dir(err);
            });
    }
}