import { HttpHandler, HttpHeaderResponse, HttpHeaders, HttpInterceptor, HttpProgressEvent, HttpRequest, HttpResponse, HttpSentEvent, HttpUserEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { LoaderService } from '../loader.service';

@Injectable()
export class InterceptorService implements HttpInterceptor {
  private totalRequests = 0;
  public isRefreshingToken = false;
  public tokenSubject: BehaviorSubject<string> = new BehaviorSubject<string>(null);

  public constructor(private readonly loaderService: LoaderService, private readonly router: Router) {}

  private getNonAuthHeaders() {
    return new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<|HttpSentEvent | HttpHeaderResponse| HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any> | any> {
    this.totalRequests++;
    this.loaderService.setHttpStatus(true);
    request = request.clone({
      headers: this.getNonAuthHeaders()
    });

    return next.handle(request).pipe(
      tap(res => {
        if (res instanceof HttpResponse) {
          this.decreaseRequests();
        }
      }),
      catchError(err => {
        this.decreaseRequests();

        return throwError(err);
      })
    );
  }

  private decreaseRequests() {
    this.totalRequests--;
    if (this.totalRequests === 0) {
      setTimeout(() => {
        this.loaderService.setHttpStatus(false);
      }, 150);
    }
  }
}
