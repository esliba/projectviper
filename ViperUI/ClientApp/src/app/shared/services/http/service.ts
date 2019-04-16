import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';
import { endpoints } from './config';

import { QueryParams } from '../../models/query-params.model';

@Injectable()
export class HttpService {

  public constructor(private readonly httpClient: HttpClient, ) {}

  public get(name: string): Observable<any> {
    const uri = environment.baseApiUrl + endpoints[name];

    return this.httpClient
      .get(uri)
      .pipe(
        catchError(err => {
          return throwError(err);
        })
      );
  }

  public getWithQueryParams(name: string, queryParams?: any): Observable<any> {
    const uri = environment.baseApiUrl + endpoints[name];
    if (queryParams) {

      return this.httpClient
        .get(uri, {params: this.createHttpParams(queryParams)})
        .pipe(
          catchError(err => {
            return throwError(err);
          })
        );
    }

    return this.httpClient
      .get(uri)
      .pipe(
        catchError(err => {
          return throwError(err);
        })
      );
  }

  private createHttpParams(queryParams: QueryParams[]) {
    let params = new HttpParams();
    queryParams.forEach(qp => {
      params = params.set(qp.key, qp.value);
    });

    return params;
  }
}
