import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../user-models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  public email: Subject<string>;
  public username: Subject<string>;

  private endpoint: string = 'https://localhost:5001/api/v1';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) {
    this.username = new Subject<string>();
  }

  getByEmail(email: string): Observable<UserModel> {
    return this.http.get<UserModel>(`https://localhost:5001/api/v1/users/` + encodeURIComponent(email), this.httpOptions);
  }
}
