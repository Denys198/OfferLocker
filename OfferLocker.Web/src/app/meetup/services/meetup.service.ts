import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { MeetupModel } from '../models';
import { MeetupsModel } from '../models/meetups.model';

@Injectable({
  providedIn: 'root',
})
export class MeetupService {
  private endpoint: string = 'https://localhost:5001/api/v1/meetups';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) {}

  getAll(): Observable<MeetupsModel> {
    return this.http.get<MeetupsModel>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<MeetupModel> {
    return this.http.get<MeetupModel>(
      `${this.endpoint}/${id}`,
      this.httpOptions
    );
  }

  post(meetup: MeetupModel): Observable<any> {
    return this.http.post<any>(this.endpoint, meetup, this.httpOptions);
  }

  patch(meetup: MeetupModel): Observable<any> {
    return this.http.patch(
      `${this.endpoint}/${meetup.id}`,
      meetup,
      this.httpOptions
    );
  }
}
