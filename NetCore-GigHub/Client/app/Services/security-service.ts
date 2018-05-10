import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"

import { Observable } from "rxjs/Observable"
import { tap } from "rxjs/operators"

@Injectable()
export class SecurityService {

    private readonly urlApi: string = "api/account"
    private readonly keyUserName: string = "userName"
    private readonly keyToken: string = "bearerToken"

    public authObject: AuthObject = new AuthObject

    constructor(private http: HttpClient) {
    }

    register(viewModel) {
        return this.http.post(this.urlApi + "/register", viewModel)
    }

    login(viewModel): Observable<AuthObject> {
        return this.http.post<AuthObject>(this.urlApi + "/login", viewModel)
            .pipe(tap(res => {
                Object.assign(this.authObject, res)
                localStorage.setItem(this.keyUserName, this.authObject.userName)
                localStorage.setItem(this.keyToken, this.authObject.bearerToken)
            }))
    }

    logout() {
        this.resetAuthObject()
    }

    getTokenBearer() {
        return localStorage.getItem(this.keyToken)
    }

    private resetAuthObject() {
        this.authObject.userName = null
        this.authObject.bearerToken = null
        this.authObject.isAuthenticated = false

        this.authObject.claims = []
        localStorage.removeItem(this.keyUserName)
        localStorage.removeItem(this.keyToken)
    }
}

class AuthObject {
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