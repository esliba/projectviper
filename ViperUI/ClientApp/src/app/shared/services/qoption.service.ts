import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpService } from './http/service';

import { QueryParams } from '../models/query-params.model';
import { QOption } from '../models/qoption.model';

@Injectable()
export class LoaderService {

    public constructor(private readonly httpService: HttpService) {}

    public getQOptions(): Observable<QOption[]> {

        return this.httpService.get('qOption')
        .pipe(
          map((response: QOption[]) => {
            return response;
          })
        );
    }

    public getQOption(params?: QueryParams[]): Observable<QOption> {
        
        return this.httpService.getWithQueryParams('qOption', params)
        .pipe(
          map((response: QOption) => {
            return response;
          })
        );
    }
}