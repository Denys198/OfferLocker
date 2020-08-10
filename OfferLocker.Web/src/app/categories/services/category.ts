import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { CategoriesModel } from '../models/categories.model';
import { CategoryModel } from '../models/category.model';
import { OffersModel } from 'src/app/offer/models';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private endpoint: string = 'https://localhost:5001/api/v1/categories';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<CategoriesModel> {
    return this.http.get<CategoriesModel>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<CategoryModel> {
    return this.http.get<CategoryModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }

  post(category: CategoryModel): Observable<any> {
    return this.http.post<any>(this.endpoint, category, this.httpOptions);
  }

  patch(category: CategoryModel): Observable<any> {
    return this.http.patch<any>(`${this.endpoint}/${category.id}`, category, this.httpOptions);
  }
  getOffers(id: string): Observable<OffersModel> {
    return this.http.get<OffersModel>(`https://localhost:5001/categories/${id}`, this.httpOptions);
  }
}
