//import { Injectable } from "@angular/core";
//import { Product } from "../models/products";
//import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
//import { ProductService } from "../servicers/product.service";
//import { Observable, of, throwError } from "rxjs";
//import { catchError } from "rxjs/operators";
//import { error } from "selenium-webdriver";

//@Injectable()

//export class ProductDetailsResolvers implements Resolve<Product>{

//  constructor(private productService: ProductService, private router: Router) {
//  }
//  resolve(route: ActivatedRouteSnapshot): Observable<Product> {
//    return this.productService.getProduct(route.params['id']).pipe(
//      catchError(error => {
//        console.log("problem retiving data");
//        this.router.navigate(['./product']);
//        return throwError(error);
//      })
//    );
//  }
//}
