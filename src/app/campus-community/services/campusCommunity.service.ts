import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { CampusCommunityModel } from '../models';
import { CampusCommunitiesModel } from '../models/campus-communities.model';

@Injectable({
  providedIn: 'root'
})
export class CampusCommunityService {

  private endpoint: string = 'https://localhost:5001/api/v1/CampusCommunities';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<CampusCommunitiesModel> {
    return this.http.get<CampusCommunitiesModel>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<CampusCommunityModel> {
    return this.http.get<CampusCommunityModel>('${this.endpoint}/${id}', this.httpOptions);
  }

  post(community: CampusCommunityModel): Observable<any> {
    return this.http.post<any>(this.endpoint, community, this.httpOptions);
  }

  patch(community: CampusCommunityModel): Observable<any> {
    return this.http.patch<any>('${this.endpoint}/${offer.id}', community, this.httpOptions);
  }
}
