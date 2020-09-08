import { Component, OnInit } from '@angular/core';

import { ProductService } from '../servicers/product.service';
import { error } from '@angular/compiler/src/util';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../models/category';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../models/products';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];
  category: Category[];

  constructor(private productService: ProductService, private toastr: ToastrService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.category = data['category'];
    });
  }
  loadProducts(cat: Category) {
    this.productService.getProductstoCategory(cat).subscribe((product: Product[]) => {
      this.products = product;
    },
    error => {
      this.toastr.error(error);
    });
  }
}
