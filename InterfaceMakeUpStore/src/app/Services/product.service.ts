import { HttpClient } from '@angular/common/http';
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

  post(product: ProductData): void {
    const url = `${this.API}/?Name=${product.name}&IdBrand=${product.idBrand}&Description=${product.description}&Type=${product.type}&BodyPart=${product.bodyPart}&Price=${product.price}&Quantity=${product.quantity}`
    this.http.post<ProductData>(url, product.photo)
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
