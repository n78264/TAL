import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment.prod';
let HttpService = class HttpService {
    constructor(http) {
        this.http = http;
    }
    get() {
        return this.http.get(environment.baseUrl)
            .pipe(tap(data => console.log(JSON.stringify(data))), catchError(this.handleError));
    }
    handleError(err) {
        let errorMessage;
        if (err.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${err.error.message}`;
        }
        else {
            errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
        }
        console.error(err);
        return throwError(errorMessage);
    }
};
HttpService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], HttpService);
export { HttpService };
//# sourceMappingURL=http-service.js.map