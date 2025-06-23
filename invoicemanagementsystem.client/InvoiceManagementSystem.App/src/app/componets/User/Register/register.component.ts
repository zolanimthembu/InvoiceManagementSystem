import { Component } from '@angular/core';
import { FormBuilder, Validators, NgModel } from '@angular/forms';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  roles = ['User', 'Manager', 'Admin'];
  email: string  = '';
  passwrod: string = '';
  selectedRole: string = '';

  constructor(private fb: FormBuilder, private auth: AuthService, private model: NgModel) { }
  
  onSubmit() {
    var registerForm = {
      email: this.email,
      password: this.passwrod,
      role: this.selectedRole
    };

    this.auth.register(registerForm).subscribe({
      next: () => alert('Registration successful'),
      error: err => alert('Error: ' + err.error?.title ?? err.message)
    });
  }
}

