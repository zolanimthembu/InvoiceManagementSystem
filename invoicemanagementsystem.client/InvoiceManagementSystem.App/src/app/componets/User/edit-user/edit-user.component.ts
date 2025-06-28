import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css'
})
export class EditUserComponent implements OnInit {
  email = '';
  password = '';
  selectedRole = '';
  firstName = '';
  lastName = '';
  userId = '';
  roles = ['User', 'Manager', 'Admin'];
  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    let user = this.auth.getUser();
    if (user) {
      this.email = user.email;
      this.selectedRole = user.role;
      this.firstName = user.firstName;
      this.lastName = user.lastName;
      this.userId = user.userId;
    } else {
      this.auth.logout();
      this.router.navigate(['/user/login']);
    }
  }
  update() {
    const registerForm = {
      userid: this.userId,
      email: this.email,
      role: this.selectedRole,
      firstName: this.firstName,
      lastName: this.lastName
    };
    this.auth.update(registerForm).subscribe({
      next: (res) => {
        alert('Updated successful')
        this.router.navigate(['/user/userlist']);
      },
      error: err => {
        console.log(err);
        alert('Error updating');
      }
    });
  }
}
