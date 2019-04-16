import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpService } from './http/service';

import { QueryParams } from '../models/query-params.model';
import { Theme } from '../models/theme.model';

@Injectable()
export class LoaderService {

    public constructor(private readonly httpService: HttpService) {}

    public getThemes(): Observable<Theme[]> {

        return this.httpService.get('theme')
        .pipe(
          map((response: Theme[]) => {
            return response;
          })
        );
    }

    public getTheme(params?: QueryParams[]): Observable<Theme> {
        
        return this.httpService.getWithQueryParams('theme', params)
        .pipe(
          map((response: Theme) => {
            return response;
          })
        );
    }
}