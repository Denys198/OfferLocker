import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// initializare string cu url
const endpoint = 'http://offer-locker.ashbell-platform.com/api/v1/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(private readonly httpClient: HttpClient) {}

public register(data: unknown): Observable<unknown> {
  return this.httpClient.post(`${endpoint}/register`, data);
}


  public login(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${endpoint}/login`, data);
  }
}
