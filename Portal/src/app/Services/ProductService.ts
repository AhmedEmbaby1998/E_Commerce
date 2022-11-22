import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AddProduct } from "../Models/AddProduct";
import { LookUpModel } from "../Models/LookUpModel";
const Base_URL='https://localhost:7275/api/'

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) {

  }

  CreateProduct(input:AddProduct):Observable<any>{
    const url=`${Base_URL}product/addProduct`
    return this.httpClient.post(url,input) as Observable<any>
  }

  UpdateProduct(input:AddProduct):Observable<any>{
    const url=`${Base_URL}product/updateProduct`
    return this.httpClient.put(url,input) as Observable<any>
  }


  getProduct(id:number):Observable<AddProduct>{
    const url=`${Base_URL}product/GetAProduct/${id}`
    return this.httpClient.get(url) as Observable<AddProduct>
  }

  getProductCategories():Observable<LookUpModel[]>{
    const url=`${Base_URL}LookUp/getProductCategories`
    return this.httpClient.get(url) as Observable<LookUpModel[]>
  }




}

