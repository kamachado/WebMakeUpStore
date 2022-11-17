import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './component/List/product-list/product-list.component';
import { CreateProductComponent } from './component/registration/create-product/create-product.component';

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

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
