import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product, ProductData, ResultListProduct } from '../Models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly API = 'http://localhost:5258/product'

  constructor(private http: HttpClient) { }

  getList(): Observable<ResultListProduct> {
    return this.http.get<ResultListProduct>(this.API)
  }

  post(product: ProductData): Observable<ProductData> {
    const url = `${this.API}`
    return this.http.post<ProductData>(url, product);
  }

  update(product: Product): Observable<Product> {
    const url = `${this.API}/update/${product.id}`
    return this.http.post<Product>(url, product.quantity)
  }

  delete(id: number): Observable<Product> {
    const url = `${this.API}/${id}`
    return this.http.delete<Product>(url)
  }

  getById(id: number): Observable<Product> {
    const url = `${this.API}/${id}`
    return this.http.get<Product>(url)
  }

  getListWithFilters(params: HttpParams): Observable<any> {
    const url = `${this.API}`
    return this.http.get<ResultListProduct>(this.API,{params});
  }

}
