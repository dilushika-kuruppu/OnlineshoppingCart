import { Component, OnInit } from '@angular/core';
import { Payment } from '../models/payment';
import { Product } from '../models/products';
import { Customer } from '../models/customer';
import { AuthService } from '../servicers/auth.service';
import { CartService } from '../servicers/cart.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { OrderPayment } from '../models/orderPayment';
import { PaymentService } from '../servicers/payment.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  payment: Payment;
  items: Product[];
  orderPayment: any = {};
  customer: Customer;


  // tslint:disable-next-line: max-line-length
  constructor(private authService: AuthService, private cartService: CartService, private paymentService: PaymentService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit() {
   this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
     this.customer = data['customer'];
    });
   this.payment = this.cartService.getPaymentDetails();
   this.items = this.cartService.getItems();
  }
  assignValue(): OrderPayment {

    this.orderPayment.userId = this.authService.decodedToken.nameid;
    this.orderPayment.userName = this.customer.userName;
    this.orderPayment.address = this.customer.address1;
    this.orderPayment.total = this.payment.Total;
    this.orderPayment.email = this.customer.email;
    this.orderPayment.OrderProductDto = this.items;
    return this.orderPayment;

  }
  makepayment(){
    this.assignValue();
    this.paymentService.postPayment(this.assignValue()).subscribe(() => {
      this.toastr.success('payment done successfully');
    },
    error => {
      this.toastr.error('error on this');
    });
    this.cartService.cleanCart();
  }
}

