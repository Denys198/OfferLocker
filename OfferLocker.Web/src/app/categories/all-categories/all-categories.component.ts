import { categories } from 'src/app/categories/categories-data';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { Router } from '@angular/router';
import { CategoryModel } from '../models/category';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css']
})
export class AllCategoriesComponent implements OnInit {

  public categories;

  constructor(private router: Router) { }


  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  ngOnInit(): void {
    this.categories = categories;
  }

  goToCategory(name: string): void {
    console.log(name);
    this.router.navigate([`/categories/${name}`]);
  }

}
