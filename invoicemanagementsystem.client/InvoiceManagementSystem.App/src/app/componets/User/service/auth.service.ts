import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://localhost:7294/api/auth';

  constructor(private http: HttpClient) { }

  login(data: { email: string; password: string }) {
    return this.http.post(`${this.apiUrl}/login`, data);
  }

  register(data: { email: string; password: string; role: string }) {
    return this.http.post(`${this.apiUrl}/register`, data);
  }

  saveToken(user: any) {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getToken() {
    return localStorage.getItem('user');
  }

  logout() {
    localStorage.removeItem('user');
  }
}
