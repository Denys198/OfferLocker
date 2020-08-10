import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { CategoryModel } from 'src/app/categories/models/category.model';
import { CategoriesModel } from 'src/app/categories/models/categories.model';
import { CategoryServiceService } from 'src/app/categories/services/category.service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {

  public projectTitle: string = "OfferLocker";
  public categories: CategoryModel[];

  constructor(
    public readonly userService: UserService,
    private readonly router: Router,
    private service: CategoryServiceService
  ) { }

  ngOnInit() {
    this.service.getAll().subscribe((data: CategoriesModel) => {
      this.categories = data.results.sort().reverse();
    });
  }

  goToCategory(name: string): void {
    console.log(name);
    this.router.navigate([`/categories/${name}`]);
  }

  logout(): void {
    this.userService.email.next(null);
    this.router.navigate(['authentication']);
  }

  getImage(name: string) {
    if (name.indexOf(' ') != -1) {
      let length = name.indexOf(' ');
      return name.substring(0, length).toLowerCase();
    }
    else return name.toLowerCase();
  }
}
