import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from "src/environments/environment";

// initializare string cu url
const endpoint = `${environment.apiBase}/auth`;

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  public endpoint: string =
    `${environment.apiBase}/auth`;

  constructor(private readonly httpClient: HttpClient) { }

  public register(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/register`, data);
  }


  public login(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/login`, data);
  }
}
