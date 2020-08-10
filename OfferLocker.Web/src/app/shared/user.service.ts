import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { UserModel } from './user-models/user.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private endpoint: string = 'https://localhost:5001/api/v1';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`,
    }),
  };

  public email: Subject<string>;

  constructor(private readonly http: HttpClient) {
  }

  getByEmail(email: string): Observable<UserModel> {
    return this.http.get<UserModel>(`${this.endpoint}/users/${email}`, this.httpOptions);
  }
}
