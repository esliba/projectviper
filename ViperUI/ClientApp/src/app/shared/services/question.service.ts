import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpService } from './http/service';

import { QueryParams } from '../models/query-params.model';
import { Question } from '../models/question.model';
import { QOption } from '../models/qoption.model';

@Injectable()
export class LoaderService {

    public constructor(private readonly httpService: HttpService) {}

    public getQuestions(): Observable<Question[]> {

        return this.httpService.get('question')
        .pipe(
          map((response: Question[]) => {
            return response;
          })
        );
    }

    public getQuestion(params?: QueryParams[]): Observable<Question> {
        
        return this.httpService.getWithQueryParams('question', params)
        .pipe(
          map((response: Question) => {
            return response;
          })
        );
    }

    public getOptionsForQuestion(params?: QueryParams[]): Observable<QOption> {
        
        return this.httpService.getWithQueryParams('question/options', params)
        .pipe(
          map((response: QOption) => {
            return response;
          })
        );
    }

    public getQuestionsForQContainer(params?: QueryParams[]): Observable<Question[]> {
        
        return this.httpService.getWithQueryParams('question/qcontainer', params)
        .pipe(
          map((response: Question[]) => {
            return response;
          })
        );
    }
}