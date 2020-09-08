import { Injectable } from "@angular/core";

import { Observable, throwError } from "rxjs";
import { Product } from "../models/products";
import { HttpClient } from "@angular/common/http";
import { Category } from "../models/category";
import { catchError } from "rxjs/operators";
import { ToastrService } from "ngx-toastr";


@Injectable({
  providedIn: "root"
})

export class ProductService {
  baseUrl = 'api/';


  constructor(private http: HttpClient, private toastr: ToastrService) {
  }
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'products');
  }
  getProduct(id): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + id);
  }
  getCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'categories');
  }

  getProductstoCategory(id): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'products/category/' + id);
  }



  handleError(error) {

    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {

      // client-side error

      errorMessage = `Error: ${error.error.message}`;

    } else {

      // server-side error

      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;

    }
    this.toastr.error(errorMessage);

    return throwError(error);

  }

}
