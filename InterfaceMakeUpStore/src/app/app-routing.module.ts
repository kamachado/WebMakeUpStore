import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './component/List/product-list/product-list.component';
import { CreateBrandComponent } from './component/registration/create-brand/create-brand.component';
import { CreateProductComponent } from './component/registration/create-product/create-product.component';
import { FirstPageComponent } from './component/registration/first-page/first-page.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'listProduct',
    pathMatch: 'full'
  },
  {
    path: 'createProduct',
    component: CreateProductComponent
  },
  {
    path: 'listProduct',
    component: ProductListComponent
  },
  {
    path: 'createBrand',
    component: CreateBrandComponent
  },
  {
    path: 'registration',
    component: FirstPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
