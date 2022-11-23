import { Product } from './../../../Models/Product';
import { Component, Input, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() product:Product ={
    id:0,
     name:'',
     description:'',
     price:0,
     quantity:0,
     idBrand:0,
     type:'',
     bodyPart:'',
     photo:''
  };

  
  
  constructor(private service:ProductService,private router: Router) {  }

  ngOnInit(): void {
  }


}
