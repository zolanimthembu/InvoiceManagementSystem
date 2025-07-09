import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InvoiceService } from '../service/invoice.service';
declare var $: any;

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrl: './invoices.component.css'
})
export class InvoicesComponent implements OnInit {

  invoices: any = [];
  user: any;

  constructor(private router: Router, private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem("user") || '');
    if (this.user) {
      this.getInvoices();
    }
  }
  addInvoice() {
    this.user = JSON.parse(localStorage.getItem("user") || '');
    var userid = {
      createdByUserEmail: this.user.user.id
    };
    this.invoiceService.addInvoice(userid).subscribe({
      next: (response) => {
        let data: any = response
        if (data.responseCode == 200) {
          this.invoices = data.responseObject;
          this.getInvoices();
        }
      },
      error: err => alert("Error getting invoices")
    }
    );
  }
  getInvoices() {
    this.invoiceService.getInvoices().subscribe({
      next: (response) => {
        let data: any = response
        if (data.responseCode == 200) {
          this.invoices = data.responseObject;
        }
      },
      error: err => alert("Error getting invoices")
    }
    )
  }
  invoiceItems() { }
}
