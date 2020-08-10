import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { NotificationsModel } from '../models/notifications.model';
//import { NotifyModel } from '../models/notifications';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  private endpoint: string = 'https://localhost:5001/api/v1/notifications';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<NotificationsModel> {
    return this.http.get<NotificationsModel>(this.endpoint, this.httpOptions);
  }

  post(category: NotificationsModel): Observable<any> {
    return this.http.post<any>(this.endpoint, category, this.httpOptions);
  }

  getOffers(id: string): Observable<NotificationsModel> {
    return this.http.get<NotificationsModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }
}
