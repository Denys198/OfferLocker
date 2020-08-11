import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { CategoriesModel } from 'src/app/categories/models/categories.model';
import { CategoryService } from 'src/app/categories/services/category';
import { CategoryModel } from 'src/app/categories/models/category';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {

  public username: string;
  public projectTitle: string = "OfferLocker";
  public categories: CategoryModel[];
  public userId: string;

  constructor(
    public readonly userService: UserService,
    private readonly cdRef: ChangeDetectorRef,
    private readonly router: Router,
    private service: CategoryService
  ) { }

  ngOnInit() {
    this.service.getAll().subscribe((data: CategoriesModel) => {
      this.categories = data.results.sort().reverse();
    });

    this.username = JSON.parse(localStorage.getItem('userFullName'));
    this.userId = JSON.parse(localStorage.getItem('userId'));
  }

  goToCategory(name: string): void {
    console.log(name);
    this.router.navigate([`/categories/${name}`]);
  }

  logout(): void {
    this.userService.email = null;
    this.router.navigate(['authentication']);
  }
}
