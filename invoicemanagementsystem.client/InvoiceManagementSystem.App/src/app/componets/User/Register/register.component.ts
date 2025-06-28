import { Component } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  email = '';
  password = '';
  selectedRole = '';
  firstName = '';
  lastName = '';
  roles = ['User', 'Manager', 'Admin'];

  constructor(private auth: AuthService, private router: Router) { }

  register() {
    const registerForm = {
      email: this.email,
      password: this.password,
      role: this.selectedRole,
      firstName: this.firstName,
      lastName: this.lastName
    };
    this.auth.register(registerForm).subscribe({
      next: () => {
        alert('Registration successful')
        this.router.navigate(['/user/userlist']);

      }          ,
      error: err => {
        alert('Error: ' + (err.error?.title ?? err.error[0].description))
      }
    });
  }
}
