import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './component/header/header.component';
import { BaseboardComponent } from './component/baseboard/baseboard.component';
import { CreateProductComponent } from './component/registration/create-product/create-product.component';
import { CreateBrandComponent } from './component/registration/create-brand/create-brand.component';
import { ProductListComponent } from './component/List/product-list/product-list.component';
import { ProductComponent } from './component/product/product/product.component';
import { HttpClientModule} from '@angular/common/http';
import { FirstPageComponent } from './component/registration/first-page/first-page.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BaseboardComponent,
    CreateProductComponent,
    CreateBrandComponent,
    ProductListComponent,
    ProductComponent,
    FirstPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
