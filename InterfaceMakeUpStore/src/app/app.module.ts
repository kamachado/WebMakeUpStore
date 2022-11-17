import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './component/header/header.component';
import { BaseboardComponent } from './component/baseboard/baseboard.component';
import { CreateProductComponent } from './component/registration/create-product/create-product.component';
import { CreateBrandComponent } from './component/registration/create-brand/create-brand.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BaseboardComponent,
    CreateProductComponent,
    CreateBrandComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
