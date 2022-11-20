import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  listProducts: Product[] = [];
  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.service.getList().subscribe((resultProducts) => {
      this.listProducts = resultProducts.result;
    });
  }

}
