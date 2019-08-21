import { Component, OnInit,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  public customers: Customer[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Customer[]>(baseUrl + 'api/customers').subscribe(result => {
      this.customers = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Customer {
  id: number,
  userId: string,
  savedAddressId: number,
  //date: string;
  //temperatureC: number;
  //temperatureF: number;
  //summary: string;
}

