import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs/Observable";
import { tap } from "rxjs/operators";
import { NotificationService } from "./notification-service";


@Injectable()
export class SecurityService {

    private readonly urlApiBase: string = "api/account";
    private readonly tokenKey = "bearerToken"
    public authObject: AuthObject = new AuthObject;

    constructor(
        private http: HttpClient,
        private notify: NotificationService) { }

    register(viewModel) {
        return this.http.post(`${this.urlApiBase}/register`, viewModel);
    }

    login(viewModel): Observable<AuthObject> {
        return this.http.post<AuthObject>(`${this.urlApiBase}/login`, viewModel)
            .pipe(tap(res => {
                Object.assign(this.authObject, res);
                localStorage.setItem(this.tokenKey, this.authObject.bearerToken);
            }));
    }

    logout() {
        this.resetAuthObject()
    }

    private resetAuthObject() {
        this.authObject.userName = null
        this.authObject.bearerToken = null
        this.authObject.isAuthenticated = false

        this.authObject.claims = []
        localStorage.removeItem(this.tokenKey)
    }
}

class AuthObject {
    userName: string;
    bearerToken: string;
    isAuthenticated: boolean = false;
    claims: ClaimUser[] = [];
}

class ClaimUser {
    claimId: number;
    userId: number;
    claimType: string;
    claimValue: string;
}