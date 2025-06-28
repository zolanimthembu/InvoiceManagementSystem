import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service'
import { Router } from '@angular/router';
import $ from 'jquery';


@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrl: './userlist.component.css'
})
export class UserlistComponent implements OnInit {
  email = '';
  password = '';
  selectedRole = '';
  roles = ['User', 'Manager', 'Admin'];
  users: any;

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.getUsers();
  }


  getUsers() {
    this.auth.getUsers().subscribe({
      next: (response) => {
        this.users = response;
      },
      error: err => alert("Error getting Users")
    })
  }
  editUser(user: any) {
    this.auth.setUser(user);
    this.router.navigate(['/user/edit-user']);

  }
  addUserPopUp() {
    this.router.navigate(['/user/register']);
  }
}
