import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Brand } from 'src/app/Models/Brand';
import { ProductData } from 'src/app/Models/Product';
import { BrandService } from 'src/app/Services/brand.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

   product:ProductData ={
    name:'',
    description:'',
    price:0,
    quantity:0,
    idBrand:0,
    type:'',
    bodyPart:''
 };

 @Input() listBrands:Brand[] = [];

  constructor(private serviceBrand: BrandService, private serviceProduct: ProductService,private router: Router  ) { }

  

  ngOnInit(): void {
    this.serviceBrand.getList().subscribe((resultBrand) => {
      this.listBrands = resultBrand.result;
    });

  }

  createProduct(){
   this.serviceProduct.post(this.product).subscribe(() => {
      alert(`Product ${this.product.name} has been registered`)
      this.router.navigate(['/listProduct'])
    })
  }


}
