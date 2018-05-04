import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"

import { Observable } from "rxjs/Observable"
import { tap } from "rxjs/operators"

@Injectable()
export class SecurityService {

    private readonly urlApiBase: string = "api/account"
    private readonly userIdKey: string = "userId"
    private readonly userNameKey: string = "userName"
    private readonly tokenKey: string = "bearerToken"

    public authObject: AuthObject = new AuthObject

    constructor(private http: HttpClient) {
    }

    register(viewModel) {
        return this.http.post(`${this.urlApiBase}/register`, viewModel)
    }

    login(viewModel): Observable<AuthObject> {
        return this.http.post<AuthObject>(`${this.urlApiBase}/login`, viewModel)
            .pipe(tap(res => {
                Object.assign(this.authObject, res)
                localStorage.setItem(this.userIdKey, "" + this.authObject.userId)
                localStorage.setItem(this.userNameKey, this.authObject.userName)
                localStorage.setItem(this.tokenKey, this.authObject.bearerToken)
            }))
    }

    logout() {
        this.resetAuthObject()
    }

    getTokenBearer() {
        return localStorage.getItem(this.tokenKey)
    }

    private resetAuthObject() {
        this.authObject.userId = null
        this.authObject.userName = null
        this.authObject.bearerToken = null
        this.authObject.isAuthenticated = false

        this.authObject.claims = []
        localStorage.removeItem(this.userIdKey)
        localStorage.removeItem(this.userNameKey)
        localStorage.removeItem(this.tokenKey)
    }
}

class AuthObject {
    userId: number
    userName: string
    bearerToken: string
    isAuthenticated: boolean = false
    claims: ClaimUser[] = []
}

class ClaimUser {
    claimId: number
    userId: number
    claimType: string
    claimValue: string
}