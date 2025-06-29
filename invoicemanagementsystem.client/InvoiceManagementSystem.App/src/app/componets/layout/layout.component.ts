import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../User/service/auth.service'; // adjust path if needed

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  userEmail: string | null = '';
  constructor(private auth: AuthService, private router: Router) { }



  ngOnInit(): void {
    // Example: extract from localStorage (assuming you stored it after login)
    const user = this.auth.getToken();
    if (user) {
      const payload = JSON.parse(user);
      this.userEmail = payload.user.email || payload.user.normalizedUserName || '';
    }
    //else {
    //  this.router.navigate(['/user/login'])

    //}
  }

  logout() {
    this.auth.logout();
    this.router.navigate(['/user/login']);
  }
  userList() {
    this.router.navigate(['/user/userlist']);
  }
  products() {
    this.router.navigate(['/product/products']);
  }
}
