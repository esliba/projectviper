import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpService } from './http/service';

import { QueryParams } from '../models/query-params.model';
import { QContainer } from '../models/qcontainer.model';

@Injectable()
export class LoaderService {

    public constructor(private readonly httpService: HttpService) {}

    public getQContainers(): Observable<QContainer[]> {

        return this.httpService.get('qContainer')
        .pipe(
          map((response: QContainer[]) => {
            return response;
          })
        );
    }

    public getQContainer(params?: QueryParams[]): Observable<QContainer> {
        
        return this.httpService.getWithQueryParams('qContainer', params)
        .pipe(
          map((response: QContainer) => {
            return response;
          })
        );
    }

    public getQContainersTheme(params?: QueryParams[]): Observable<QContainer[]> {
        
        return this.httpService.getWithQueryParams('qContainer/theme', params)
        .pipe(
          map((response: QContainer[]) => {
            return response;
          })
        );
    }
}