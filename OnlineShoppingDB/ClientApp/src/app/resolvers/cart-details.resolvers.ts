//import { Injectable } from "@angular/core";
//import { Resolve } from "@angular/router";
//import { Cart } from "../models/cart";

//@Injectable()

//export class CartDetailResolvers implements Resolve<Cart[]> {
//  /**
//   *
//   */
//  userId: number;
//  constructor(private authservice: AuthService, private router: Router,
//    private cartservice: CartService, private alertify: AlertifyService) { }


//  resolve(route: ActivatedRouteSnapshot): Observable<Cart[]> {
//    this.userId = this.authservice.decodeToken.nameid;
//    return this.cartservice.getOrder(this.userId).pipe(
//      catchError(error => {
//        this.alertify.error('Problem retrieving data');
//        this.router.navigate(['products']);
//        return of(null);
//      })
//    );
//  }
//}
