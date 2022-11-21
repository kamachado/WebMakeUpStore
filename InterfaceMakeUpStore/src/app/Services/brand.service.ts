import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResultListBrand } from '../Models/Brand';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private readonly API = 'http://localhost:5258/brand'

  constructor(private http: HttpClient) { }

  getList(): Observable<ResultListBrand> {
    return this.http.get<ResultListBrand>(this.API)
  }
}
