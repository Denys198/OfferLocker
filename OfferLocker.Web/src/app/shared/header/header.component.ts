import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { categories } from 'src/app/categories/categories-data';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  public projectTitle: string = "OfferLocker";
  public categories;
  constructor(
    public readonly userService: UserService,
    private readonly router: Router
  ) { }

  ngOnInit() {
    this.categories = categories;
  }

  goToCategory(name: string): void {
    console.log(name);
    this.router.navigate([`/categories/${name}`]);
  }

  logout(): void {
    this.userService.email.next(null);
    this.router.navigate(['authentication']);
  }
}
