import { Component } from '@angular/core';
import { ProductService } from '../service/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrl: './addproduct.component.css'
})
export class AddproductComponent {

  name = '';
  itemsInStock = 0;
  costPerItem = 0;

  constructor(private service: ProductService, private router: Router) { }

  addProduct() {
    let product =  {
      name: this.name,
      itemsInStock: this.itemsInStock,
      costPerItem: this.costPerItem
    }
    this.service.addProduct(product).subscribe(
      {
        next: (res) => {
          console.log(res);
          alert('Added successfuly')
          this.router.navigate(['/product/products']);
        },
        error: err => {
          console.log(err);
          alert('Error adding');
        }
      }
    )
  }
}
