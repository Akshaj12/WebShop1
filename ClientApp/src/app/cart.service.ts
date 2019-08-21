import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CartService {
    items: CartItem[] = [];
     
    addToCart(product) {
        this.items.push(product);
        console.log(this.items);
    }

    getItems() {
        return this.items;
    }

    clearCart() {
        this.items = [];
        return this.items;
    }
    constructor() { }
}

export interface Product {
    id: number,
    name: string,
    description: string,
    price: number,
}

export interface CartItem {
    product: Product,
    quantity: number,
}


