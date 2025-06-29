import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './componets/User/Login/login.component';
import { RegisterComponent } from './componets/User/Register/register.component';
import { LayoutComponent } from './componets/layout/layout.component';
import { UserlistComponent } from './componets/User/userlist/userlist.component';
import { EditUserComponent } from './componets/User/edit-user/edit-user.component';
import { ProductsComponent } from './componets/product/products/products.component';
import { AddproductComponent } from "./componets/product/addproduct/addproduct.component";
import { EditproductComponent } from './componets/product/editproduct/editproduct.component';

const routes: Routes = [
  { path: 'user/login', component: LoginComponent },
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'user/userlist', component: UserlistComponent },
      { path: 'user/register', component: RegisterComponent },
      { path: 'user/edit-user', component: EditUserComponent },
      { path: 'product/products', component: ProductsComponent },
      { path: 'product/addproduct', component: AddproductComponent },
      { path: 'product/editproduct', component: EditproductComponent },

    ]
  },
  { path: '**', redirectTo: 'user/login' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
