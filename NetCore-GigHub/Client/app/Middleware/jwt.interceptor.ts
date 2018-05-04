
import { Injectable } from "@angular/core"
import { HttpInterceptor, HttpRequest, HttpHandler } from "@angular/common/http"

import { SecurityService } from "../Services/security-service"
import { Observable } from "rxjs/Observable"


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private serviceSecurity: SecurityService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
        let authToken: string = this.serviceSecurity.getTokenBearer()

        if (authToken !== null) {
            let newReq = req.clone({
                setHeaders: { Authorization: "Bearer " + authToken }
            })
            return next.handle(newReq)
        } else {
            return next.handle(req)
        }
    }
}