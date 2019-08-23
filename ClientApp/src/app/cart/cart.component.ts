import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { CartService, CartItem, Product } from '../cart.service';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
    items: CartItem[];
    //checkoutForm;
    constructor(
        private cartService: CartService,
        //private formBuilder: FormBuilder
    ) {
        this.items = this.cartService.getItems();
        //this.checkoutForm = this.formBuilder.group({
        //    name: '',
        //    address: ''
        //});
    }
    //onSubmit(customerData)
    // /*onSubmit(customerId)*/ {
    //// Process checkout data here
    //     console.warn('Your order has been submitted', customerData);
    //     //console.warn('Your order has been submitted', customerId);

  //  this.items = this.cartService.clearCart();
  //  this.checkoutForm.reset();
  //}
    ngOnInit() {
    }
}

