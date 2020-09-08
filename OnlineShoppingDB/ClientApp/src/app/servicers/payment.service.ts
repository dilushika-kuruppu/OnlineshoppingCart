import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { OrderPayment } from "../models/orderPayment";

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
   baseUrl = 'api/';

  constructor(private http: HttpClient) { }

  postPayment(orderPayment: OrderPayment) {
    return this.http.post(this.baseUrl + 'order', orderPayment);
  }
}
