import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../../../enviroments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = environment.apiUrl;
  private selectedUser!: any;
  constructor(private http: HttpClient) { }

  login(data: { email: string; password: string }) {
    return this.http.post(`${this.apiUrl}auth/login`, data);
  }

  register(data: { firstName: string, lastName: string, email: string; password: string; role: string }) {
    return this.http.post(`${this.apiUrl}auth/register`, data);
  }
  update(data: { userid: string; firstName: string, lastName: string, email: string; role: string }) {
    return this.http.put(`${this.apiUrl}Users/UpdateUser`, data,    );
  }


  getUsers() {
    return this.http.get(`${this.apiUrl}users/GetUsers`);

  }

  saveToken(user: any) {
    localStorage.setItem('token', user.token);
    localStorage.setItem('user', JSON.stringify(user));
  }

  getToken() {
    return localStorage.getItem('user');
  }

  logout() {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
  }
  setUser(user: any) {
    this.selectedUser = user;
  }

  getUser() {
    return this.selectedUser;
  }
}
