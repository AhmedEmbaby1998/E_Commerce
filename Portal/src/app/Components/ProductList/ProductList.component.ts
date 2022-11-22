import { Component, OnInit } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { ActivatedRoute } from '@angular/router';
import { AddProduct } from 'src/app/Models/AddProduct';
import { LookUpModel } from '../../Models/LookUpModel';
import { ProductService } from '../../Services/ProductService';
@Component({
  selector: 'app-ProductList',
  templateUrl: './ProductList.component.html',
  styleUrls: ['./ProductList.component.css']
})
export class ProductListComponent implements OnInit {

  categories: LookUpModel[] = [];
  color: string = 'primary';
  public constructor(
    private lookUpService: ProductService,
    private ProductService: ProductService,
    private route: ActivatedRoute
  ) {
  }
  ngOnInit(): void {
    this.lookUpService.getProductCategories().subscribe((data) => {
      this.categories = data;
    });
  }

}
