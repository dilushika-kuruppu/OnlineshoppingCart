import { Component, OnInit } from '@angular/core';
import { AuthService } from '../servicers/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {};

  constructor(private route: Router, private toastr: ToastrService,
    public authService: AuthService) {
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.loggedIn()
      this.route.navigate(['/home']);
      this.toastr.success("Logging Successfully");
    }, error => {
        this.toastr.error(error);
    });
  }

  loggedIn() {
    this.authService.isLoggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.toastr.success("Logged Out");
  }

}
