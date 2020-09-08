import { Component, OnInit } from '@angular/core';
import { error } from '@angular/compiler/src/util';
import { Category } from '../models/category';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories: Category[];

  constructor( private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
    this.categories = data['categories'];
    });
   // this.loadCategories();
  }

  //loadCategories() {
  //this.categoryService.getCategories().subscribe((Categories: Category[]) => {
  //  this.categories = Categories;
  //},
  //   error => {
  //     console.log(error);
  //  })
  //}

}
