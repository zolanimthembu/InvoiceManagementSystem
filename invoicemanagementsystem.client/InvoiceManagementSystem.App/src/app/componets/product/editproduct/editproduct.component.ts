import { Component } from '@angular/core';
import { ProductService } from '../service/product.service';
import { AuthService } from '../../User/service/auth.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-editproduct',
  templateUrl: './editproduct.component.html',
  styleUrl: './editproduct.component.css'
})
export class EditproductComponent {
  name = '';
  itemsInStock = 0;
  costPerItem = 0;
  productId = 0;
  constructor(private productService: ProductService, private router: Router, private auth: AuthService) { }

  ngOnInit(): void {
    var product: any = JSON.parse(localStorage.getItem('product') || '');
    if (product) {
      this.name = product.name;
      this.itemsInStock = product.itemsInStock;
      this.costPerItem = product.costPerItem;
      this.productId = product.productId
    } else {
      this.auth.logout();
      this.router.navigate(['/user/login']);
    }
  }
  updateProduct() {
    const product = {
      productId: this.productId,
      name: this.name,
      itemsInStock: this.itemsInStock,
      costPerItem: this.costPerItem,
    };
    this.productService.updateProduct(product).subscribe({
      next: (res) => {
        alert('Updated successful')
        this.router.navigate(['/product/products']);
      },
      error: err => {
        console.log(err);
        alert('Error updating');
      }
    });
  }
}
