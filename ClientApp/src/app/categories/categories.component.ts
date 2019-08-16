import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  public categories: Category[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Category[]>(baseUrl + 'api/categories').subscribe(result => {
      this.categories = result;
      console.log(result);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Category {
  id: number,
  categoryName: string,
  parentCategoryId: number,
  //date: string;
  //temperatureC: number;
  //temperatureF: number;
  //summary: string;
}
