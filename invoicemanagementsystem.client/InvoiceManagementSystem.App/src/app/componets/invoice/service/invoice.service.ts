import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../../../enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private apiUrl = environment.apiUrl;


  constructor(private http: HttpClient) { }

  getInvoices() {
    return this.http.get(`${this.apiUrl}invoices/GetInvoices`);
  }
  addInvoice(data: { createdByUserEmail: string }) {
    return this.http.post(`${this.apiUrl}invoices/AddInvoice`, data);
  }
}
