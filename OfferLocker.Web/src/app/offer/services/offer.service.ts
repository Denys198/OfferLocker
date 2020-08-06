import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { OfferModel } from '../models';
import { OffersModel } from '../models/offers.model';

@Injectable({
  providedIn: 'root'
})
export class OfferService {

  private endpoint: string = 'https://localhost:5001/api/v1/offers';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<OffersModel> {
    return this.http.get<OffersModel>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<OfferModel> {
    return this.http.get<OfferModel>('${this.endpoint}/${id}', this.httpOptions);
  }

  post(offer: OfferModel): Observable<any> {
    return this.http.post<any>(this.endpoint, offer, this.httpOptions);
  }

  patch(offer: OfferModel): Observable<any> {
    return this.http.patch<any>('${this.endpoint}/${offer.id}', offer, this.httpOptions);
  }
}
