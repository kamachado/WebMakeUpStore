import { Component, Input, OnInit } from '@angular/core';
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
    bodyPart:'',
    photo:new FormData
 };

 @Input() listBrands:Brand[] = [];

  constructor(private serviceBrand: BrandService, private serviceProduct: ProductService,  ) { }

  createProduct(){
    this.serviceProduct.post(this.product);
    alert(`The product ${this.product.name} has been registered`)
  }

  ngOnInit(): void {
    this.serviceBrand.getList().subscribe((resultBrand) => {
      this.listBrands = resultBrand.result;
    });

  }

  onFileSelected(event: any) {

    const file:File = event.target.files[0];

    if (file) {

        const formData = new FormData();

        formData.append(this.product.name, file);
        this.product.photo = formData;
    }
  }

}
