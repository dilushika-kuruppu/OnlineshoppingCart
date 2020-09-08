import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order';
import { OrderService } from '../servicers/order.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  order: Order[];
  orderItem: Order[];

  constructor(private orderService: OrderService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.order = data['order'];
    });
  }
  loadOrders(order: Order) {
    this.orderService.getOrders().subscribe((order: Order[]) => {
      this.order = order;
    },
      error => {
        this.toastr.error(error);
      });
  }

}



