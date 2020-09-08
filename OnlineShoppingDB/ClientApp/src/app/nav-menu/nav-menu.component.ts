import { Component, OnInit } from '@angular/core';
import { AuthService } from '../servicers/auth.service';
import { error } from '@angular/compiler/src/util';
import { Router } from '@angular/router';
import { CartService } from '../servicers/cart.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  registerMode = false;
  loginMode = false;
  loggedUser: string = "Test";

  constructor(public authService: AuthService, private route: Router, private cartService: CartService) {
  }

  ngOnInit() {
    this.cartService.updateCartState();
    this.authService.loginStatus.subscribe(r => {
      this.loginMode = r;
      //this.loggedUser = this.loginMode ? this.authService.decodedToken.unique_name : "Test";
    });

    this.loginMode = this.authService.isLoggedIn();
   // this.loggedUser = this.loginMode ? this.authService.decodedToken.unique_name : "Test";
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  
}
