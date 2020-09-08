import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

import { ProductService } from '../servicers/product.service';
import { Category } from '../models/category';
import { Product } from '../models/products';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit, OnChanges {

  @Input() selectedLevel: number;
  products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {

    this.loadProducts();
    //this.products = [];
    //var product = <Product>{};
    //product.name = "TShirt"
    //product.categoryId = 1
    //product.description = "ashdkas dklasjdlas jdklasdkjhaskjd haskjdaslda"
    //product.image = "https://i.ebayimg.com/images/g/134AAOSwFMtcvgcr/s-l300.jpg"
    //this.products.push(product);
  }

  loadProducts() {
    this.productService.getProducts().subscribe(data => {
      console.log(data);
      this.products = data;
    },
      error => {
        this.products = [];
        console.log(error);
      })
  }

  ngOnChanges(change: SimpleChanges) {
    if (this.selectedLevel) {
      console.log("category changed")
      this.productService.getProductstoCategory(this.selectedLevel).subscribe(data => {
        this.products = data;
      }, er => {
        this.products = [];
      });
    }
  }

}
