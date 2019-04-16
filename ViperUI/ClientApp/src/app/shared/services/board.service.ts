import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpService } from './http/service';

import { QueryParams } from '../models/query-params.model';
import { Board } from '../models/board.model';

@Injectable()
export class LoaderService {

    public constructor(private readonly httpService: HttpService) {}

    public getBoards(): Observable<Board[]> {

        return this.httpService.get('board')
        .pipe(
          map((response: Board[]) => {
            return response;
          })
        );
    }

    public getBoard(params?: QueryParams[]): Observable<Board> {
        
        return this.httpService.getWithQueryParams('board', params)
        .pipe(
          map((response: Board) => {
            return response;
          })
        );
    }
}