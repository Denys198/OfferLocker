import { CategoryModel } from './../models/category.model';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { Router } from '@angular/router';
import { CategoriesModel } from '../models/categories.model';
import { CategoryService } from '../services/category';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css']
})
export class AllCategoriesComponent implements OnInit {

  public categories: CategoryModel[];

  constructor(
    private router: Router,
    private service: CategoryService
  ) { }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: CategoriesModel) => {
      this.categories = data.results.sort().reverse();
    });
  }

  goToCategory(name: string): void {
    console.log(name);
    this.router.navigate([`/categories/${name}`]);
  }

  getImage(name: string) {
    if (name.indexOf(' ') != -1) {
      let length = name.indexOf(' ');
      return name.substring(0, length).toLowerCase();
    }
    else return name.toLowerCase();
  }
}
