import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpRequest, HttpHandler, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { NotificationService } from '../Services/notification-service';

import { SecurityService } from '../Services/security-service';
import { Observable } from 'rxjs/Observable';
import { tap } from 'rxjs/operators/tap';

@Injectable()
export class SecurityInterceptor implements HttpInterceptor {

  constructor(
    private router: Router,
    private notify: NotificationService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.dir(req)
    return next.handle(req).pipe(
      tap(ev => { }, err => {
        if (err instanceof HttpErrorResponse && err.status === 401) {
          let returnUrl: string = err.url.split("/").pop().replace("get", "");
          this.router.navigate(["login"], { queryParams: { returnUrl: returnUrl } });
          this.notify.showError("You have to login for access this route");
        }
        else if (err.error.values instanceof Array) {
          err.error.values.forEach(msg => this.notify.showError(msg))
          console.dir(err)
        }
      }));
  }
}