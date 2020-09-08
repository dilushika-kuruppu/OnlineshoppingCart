//import { Injectable } from "@angular/core";
//import { Product } from "../models/produts";
//import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
//import { ProductService } from "../servicers/product.service";
//import { Observable, of, throwError } from "rxjs";
//import { catchError } from "rxjs/operators";
//import { error } from "selenium-webdriver";

//@Injectable()

//export class CategoryResolvers{

//  constructor(private productService: ProductService, private router: Router) {
//  }
  /*resolve(route: ActivatedRouteSnapshot): Observable<Product[]> {
    return this.productService.getProducts().pipe(
      catchError(error => {
        console.log("problem retiving data");
        this.router.navigate(['./home']);
        return throwError(error);
      })
    );
  }*/
