import { Component } from '@angular/core';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  email = '';
  password = '';
  selectedRole = '';
  roles = ['User', 'Manager', 'Admin'];

  constructor(private auth: AuthService) { }

  register() {
    const registerForm = {
      email: this.email,
      password: this.password,
      role: this.selectedRole
    };

    this.auth.register(registerForm).subscribe({
      next: () => alert('Registration successful'),
      error: err => {
        alert('Error: ' + (err.error?.title ?? err.error[0].description))
      }
    });
  }
}
