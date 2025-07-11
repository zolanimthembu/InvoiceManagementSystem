import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { RegisterComponent } from './componets/User/Register/register.component';
import { LoginComponent } from './componets/User/Login/login.component';
import { LayoutComponent } from './componets/layout/layout.component';
import { UserlistComponent } from './componets/User/userlist/userlist.component';
import { EditUserComponent } from './componets/User/edit-user/edit-user.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { ProductsComponent } from './componets/product/products/products.component';
import { AddproductComponent } from './componets/product/addproduct/addproduct.component';
import { EditproductComponent } from './componets/product/editproduct/editproduct.component';
import { InvoicesComponent } from './componets/invoice/invoices/invoices.component'


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    LayoutComponent,
    UserlistComponent,
    EditUserComponent,
    ProductsComponent,
    AddproductComponent,
    EditproductComponent,
    InvoicesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
