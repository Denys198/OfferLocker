import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Campus } from '../models/campus'
import { Category } from '../models/category'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})

export class DashboardComponent implements OnInit {
  constructor(private router: Router) { }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  public campusList: Campus[];
  public categoryList: Category[];

  ngOnInit(): void {
  }

  goToCampus(id: string): void {
    console.log(id);
    this.router.navigate(['/communities/${id}']);
  }

  goToCategory(id: string): void {
    console.log(id);
    this.router.navigate(['/categories/${id}']);
  }
}
