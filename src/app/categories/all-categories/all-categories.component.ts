import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { Router } from '@angular/router';
import { Category } from '../models/category'

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css']
})
export class AllCategoriesComponent implements OnInit {

  constructor(private router: Router) { }


  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  ngOnInit(): void {
  }

}
