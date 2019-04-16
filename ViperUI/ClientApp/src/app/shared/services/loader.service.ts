import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class LoaderService {

    public status: BehaviorSubject<boolean>;

    public constructor() {
        this.status = new BehaviorSubject(false);
    }

    public setHttpStatus(value: boolean) {
        this.status.next(value);
    }

    public getHttpStatus(): Observable<boolean> {
        return this.status.asObservable();
    }
}