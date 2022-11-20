import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product, ResultListProduct } from '../Models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly API = 'http://localhost:5258/product'

  constructor(private http: HttpClient) { }

  getList(): Observable<ResultListProduct> {
    return this.http.get<ResultListProduct>(this.API)
  }

  post(product: Product): Observable<Product> {
    return this.http.post<Product>(this.API, product)
  }

  update(product: Product): Observable<Product> {
    const url = `${this.API}/${product.id}`
    return this.http.put<Product>(url, product )

  }

  delete(id: number): Observable<Product> {
    const url = `${this.API}/${id}`
    return this.http.delete<Product>(url)
  }

  getById(id: number): Observable<Product> {
    const url = `${this.API}/${id}`
    return this.http.get<Product>(url)
  }
}
