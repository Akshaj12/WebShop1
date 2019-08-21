import { Component, OnInit } from '@angular/core';
import { CartService, CartItem, Product } from '../cart.service';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
    items: CartItem[];

    constructor(
        private cartService: CartService
    ) {
        this.items = this.cartService.getItems();
    }
    ngOnInit() {
    }
}

