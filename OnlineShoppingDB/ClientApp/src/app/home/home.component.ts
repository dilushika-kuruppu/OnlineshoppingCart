import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../servicers/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  category: Category[];
  selectedLevel: Category;
  
  constructor(private route: ActivatedRoute, private productService: ProductService) {
   
  }
  
ngOnInit() {
  //this.route.data.subscribe(data => {
  //  this.category = data['categories'];
  //});

  this.productService.getCategory().subscribe(data => {
    this.category = data;
  }, er => {
      this.category = [];
  });
  }

}

//constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//  http.get<Category[]>(baseUrl + 'api/Category').subscribe(result => {
//    this.category = result;
//  }, error => console.error(error));

