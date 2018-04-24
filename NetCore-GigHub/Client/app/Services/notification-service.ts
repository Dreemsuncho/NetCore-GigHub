import { Injectable } from "@angular/core";


@Injectable()
export class NotificationService {

    toastr: any = window["toastr"];

    showError(message) {
        this.toastr.error(message);
    }

    showInfo(message) {
        this.toastr.info(message);
    }

    showSuccess(message) {
        this.toastr.success(message);
    }
}