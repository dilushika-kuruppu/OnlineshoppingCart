import { Injectable } from "@angular/core";
import { Order } from "../models/order";
import { throwError, Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class OrderService {
  baseUrl = 'api/';

  constructor(private http: HttpClient, private toastr: ToastrService) {
  }
  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.baseUrl + 'orders');
  }

  getOrderDetails(id): Observable<Orderinformation[]> {
    return this.http.get<Orderinformation[]>(this.baseUrl + 'orders/orderinformation/' + id);
  }
  getOrderProductDetails(id): Observable<Orderinformationproduct[]> {
    return this.http.get<Orderinformationproduct[]>(this.baseUrl + 'orders/orderinformationproduct/' + id);
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
