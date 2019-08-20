import { Component, OnInit,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public products: Product[];

    share() {
        window.alert('The product has been shared!');
    }

    onNotify() {
        window.alert('You will be notified when the product goes on sale');
    }
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'api/products').subscribe(result => {
      this.products = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Product {
  id: number,
  name: string,
  customerId: number,
}

