import { Component } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  email: string = '';
  password: string = '';

  constructor(private auth: AuthService, private router: Router) { }

  login() {
    var registerForm = {
      email: this.email,
      password: this.password,
    };

    this.auth.login(registerForm).subscribe({
      next: (response) => {
        this.auth.saveToken(response)
        this.router.navigate(['/'])
      }          ,
      error: err => alert('Error: ' + err.error?.title ?? err.message)
    });
  }
}
