import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// initializare string cu url
const endpoint = 'https://localhost:5001/api/v1/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  public endpoint: string =
    'https://localhost:5001/api/v1/auth';

  constructor(private readonly httpClient: HttpClient) {}

public register(data: unknown): Observable<unknown> {
  return this.httpClient.post(`${this.endpoint}/register`, data);
}


  public login(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/login`, data);
  }
}
