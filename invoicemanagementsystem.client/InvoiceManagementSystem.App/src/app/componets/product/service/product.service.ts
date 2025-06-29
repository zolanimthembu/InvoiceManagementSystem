import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../../../enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = environment.apiUrl;


  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get(`${this.apiUrl}product/GetProducts`);
  }
  addProduct(data: { name: string, costPerItem: number, itemsInStock: number; }) {
      return this.http.post(`${this.apiUrl}product/addProduct`, data);
  }
  updateProduct(data: { productId: number, name: string, costPerItem: number, itemsInStock: number; }) {
    return this.http.put(`${this.apiUrl}product/UpdateProduct`, data);
  }
}
