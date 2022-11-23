import { HttpParams } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Brand } from 'src/app/Models/Brand';
import { Product } from 'src/app/Models/Product';
import { BrandService } from 'src/app/Services/brand.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  @Input() filters = {
    type:'',
    name :'',
    bodyPart:'',
    brand:0,
    maxPrice:0,
    minPrice:0
  }

  @Input() listBrands:Brand[] = [];

  @Input() listProducts:Product[] = [];
  
  constructor(private serviceBrand: BrandService, private serviceProduct: ProductService,private router: Router  ) { }

  ngOnInit(): void {
    this.serviceBrand.getList().subscribe((resultBrand) => {
      this.listBrands = resultBrand.result;
    });
  }

  searchProduct(){
    let searchParams = new HttpParams();
    if (this.filters.type != null || this.filters.type != "" ) searchParams = searchParams.append("type", this.filters.type);
    if (this.filters.name != null || this.filters.name != "" ) searchParams = searchParams.append("name", this.filters.name);
    if (this.filters.bodyPart != null || this.filters.bodyPart != "" ) searchParams = searchParams.append("bodyPart", this.filters.bodyPart);
    if (this.filters.brand != 0) searchParams = searchParams.append("brand", this.filters.brand.toString());
    if (this.filters.maxPrice != 0) searchParams = searchParams.append("maxPrice", this.filters.maxPrice.toString());
    if (this.filters.minPrice != 0) searchParams =  searchParams.append("minPrice", this.filters.minPrice.toString());
    this.serviceProduct.getListWithFilters(searchParams).subscribe((result)=>{
      this.listProducts = result.result;
    });
  }

  cancel() {
    this.router.navigate(['/listProduct'])
  }
}
