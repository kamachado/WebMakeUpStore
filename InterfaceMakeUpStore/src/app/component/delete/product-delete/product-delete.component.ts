import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-delete',
  templateUrl: './product-delete.component.html',
  styleUrls: ['./product-delete.component.css']
})
export class ProductDeleteComponent implements OnInit {

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

  deleteProduct() {
    if(this.product.id) {
      this.service.delete(this.product.id).subscribe(() => {
        this.router.navigate(['/listProduct'])
      })
    }
  }

  cancel() {
    this.router.navigate(['/listProduct'])
  }

}

