import { Component, OnInit } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { ActivatedRoute } from '@angular/router';
import { AddProduct } from 'src/app/Models/AddProduct';
import { LookUpModel } from '../../Models/LookUpModel';
import { ProductService } from '../../Services/ProductService';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class CreateProductComponent implements OnInit {
  categories: LookUpModel[] = [];
  request: AddProduct = new AddProduct();
  color: string = 'primary';
  isSubitted: boolean = false;
  isAdd: boolean;
  public constructor(
    private lookUpService: ProductService,
    private ProductService: ProductService,
    private route: ActivatedRoute
  ) {
    this.request.id = this.route.snapshot.params['id'];
    this.isAdd = !this.request.id;
  }
  ngOnInit(): void {
    this.lookUpService.getProductCategories().subscribe((data) => {
      this.categories = data;
    });
    if (!this.isAdd) this.loadData();
  }

  private loadData() {
    this.ProductService.getProduct(this.request.id).subscribe(
      (res) => (this.request = res)
    );
  }
  onSubmit() {
    if(this.isAdd)
    this.ProductService.CreateProduct(this.request).subscribe((a) => {
      this.isSubitted = true;
    });
    else
    this.ProductService.UpdateProduct(this.request).subscribe((a) => {
      debugger
      this.isSubitted = true;
    });
    this.request=new AddProduct()
  }

  changeAvailablity(event: MatCheckboxChange, available: boolean): void {
    this.request.isAvailable = available && event.checked;
  }
}
