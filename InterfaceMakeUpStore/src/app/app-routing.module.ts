import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDeleteComponent } from './component/delete/product-delete/product-delete.component';
import { ProductEditComponent } from './component/edit/product-edit/product-edit.component';
import { FilterComponent } from './component/filter/filter/filter.component';
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
  },
  {
    path: 'filters',
    component: FilterComponent
  },
  {
    path: 'product/deleteProduct/:id',
    component: ProductDeleteComponent
  },
  {
    path: 'product/editProduct/:id',
    component:ProductEditComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
