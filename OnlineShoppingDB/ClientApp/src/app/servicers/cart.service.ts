
import { Injectable } from "@angular/core";
import { Product } from "../models/products";
import { Observable } from "rxjs";
import { Cart } from "../models/cart";
import { Payment } from "../models/payment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CartService {
  items: Array<Product> = [];
  baseUrl = 'api/';
  checkout: Payment;

  constructor(private http: HttpClient) { }

  addToCart(productitem: Product): boolean {
    // tslint:disable-next-line: whitespace
    if (this.items.filter(x => x.id === productitem.id).length > -1) {
      this.items.push(productitem);
      return true;
    }
   
    
    return false;
  }

  getItems() {
    return this.items;
  }
  cleanCart() {
    this.items = [];
    return this.items;
  }
  paymentDetails(payment: Payment) {
    this.checkout = payment;
  }
  getPaymentDetails() {
    return this.checkout;
  }
  removeItems(id: number) {
    //this.items.splice(this.items.findIndex(x => x.id === id), 1);
  }
  postOrder(model: any) {
    return this.http.post(this.baseUrl + 'orders', model);
  }
  getOrder(id): Observable<Cart[]> {
    return this.http.get<Cart[]>(this.baseUrl + 'orders/' + id);
  }
  getOrders(): Observable<Cart[]> {
    return this.http.get<Cart[]>(this.baseUrl + 'orders' );
  }
  deleteOrderItem(id: number) {
    return this.http.delete(this.baseUrl + 'orders/' + id);
  }
}
