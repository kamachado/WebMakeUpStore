import { Product } from './../../../Models/Product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() product:Product ={
     name:'',
     description:'',
     price:0,
     quantity:0,
     idBrand:0,
     type:'',
     bodyPart:'',
     photo:''
  };

  constructor() { }

  ngOnInit(): void {
  }

}
