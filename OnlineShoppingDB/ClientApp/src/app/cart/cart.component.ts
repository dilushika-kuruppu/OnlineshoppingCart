import { Component, OnInit } from '@angular/core';
import { CartService } from '../servicers/cart.service';
import { Product } from '../models/products';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  items: Product[];
  payment: any = {};

  constructor(private toastr: ToastrService, private cartservice: CartService, private router: ActivatedRoute) { }

  ngOnInit() {
    //  this.router.data.subscribe( data => {
    //     // tslint:disable-next-line: no-string-literal
    //     this.cart = data['cart'];
    //  });
    this.items = this.cartservice.getItems();
  }

  gettotal() {
    let total = 0;

    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.items.length; i++) {
      if (this.items[i].price) {
        total += this.items[i].price * this.items[i].items;
      }
    }
    return this.payment.totalPrice = total;
  }

  


  removeItem(Item: Product) {
    this.cartservice.removeItems(Item.id);
    this.cartservice.getItems();
    // this.cartservice.removeItemFromCart(this.items.id);
    // console.log(Item.orderProductId);
    // this.toastr.confirm('Are you sure do you want to remove this product?', () => {
    //   this.cartservice.deleteOrderItem(Item.orderProductId).subscribe(() => {
    //     this.cart.splice(this.cart.findIndex(p => p.orderProductId === Item.orderProductId), 1);
    //     this.toastr.success('Product removed from cart');
    //   }, error => { 
    //     this.toastr.error('Failed to remove item from cart');
    //   });
    // });

  }

  makePurchase() {
    this.cartservice.paymentDetails(this.payment);
  }

}
