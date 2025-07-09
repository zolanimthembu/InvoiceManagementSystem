import { Component, OnInit } from '@angular/core';
import { ProductService } from '../service/product.service';
import { Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {

  products: any = [];
  data: any;

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit(): void {
    this.getProducts();
  }
  getProducts() {
    this.productService.getProducts().subscribe({
      next: (response) => {
        this.data = response
        if (this.data.responseCode == 200) {
          this.products = this.data.responseObject;
        }
      },
      error: err => alert("Error getting products")
    })
  }
  addProduct() {
    this.router.navigate(['/product/addproduct']);
  }
  updateProduct(product: any) {
    localStorage.setItem('product', JSON.stringify(product));
    this.router.navigate(['/product/editproduct']);
  }
}
