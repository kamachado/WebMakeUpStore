import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product: Product = {
    id:0,
    name:'',
    description:'',
    price:0,
    quantity:0,
    idBrand:0,
    type:'',
    bodyPart:'',
    photo:''
  }

  constructor(
    private service: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')
    this.service.getById(parseInt(id!)).subscribe((product) => {
      this.product = product
    })
  }

  editProduct() {
    this.service.update(this.product).subscribe(() => {
      this.router.navigate(['/listProduct'])
    })

  }

  cancel() {
    this.router.navigate(['/listProduct'])
  }

}
