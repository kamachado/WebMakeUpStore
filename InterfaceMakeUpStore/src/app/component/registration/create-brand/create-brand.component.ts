
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Brand } from 'src/app/Models/Brand';
import { listCountrys } from 'src/app/Models/countryArray';
import { BrandService } from 'src/app/Services/brand.service';

@Component({
  selector: 'app-create-brand',
  templateUrl: './create-brand.component.html',
  styleUrls: ['./create-brand.component.css']
})
export class CreateBrandComponent implements OnInit {

  @Input() brand:Brand={
    name:'',
    country:''
 };

 @Input() listCountry = listCountrys;


  constructor(private serviceBrand: BrandService,private router: Router  ) { }


  ngOnInit(): void {
  }

  createBrand(){
    if(this.brand.name == "") alert("The name is required")
    if(this.brand.country == "") alert("The Country is required")
    this.serviceBrand.post(this.brand).subscribe(() => {
       alert(`Brand ${this.brand.name} has been registered`)
       this.router.navigate(['/listProduct'])
     })
   }

}
