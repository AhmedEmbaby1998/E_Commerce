import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateProductComponent } from './Components/create-product/create-product.component';
import { ProductListComponent } from './Components/ProductList/ProductList.component';

const routes: Routes = [
  { path: '', redirectTo: 'products', pathMatch: 'full' },
 { path: 'list', component: ProductListComponent },
  { path: 'addProduct/:id', component: CreateProductComponent },
  { path: 'addProduct', component: CreateProductComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
