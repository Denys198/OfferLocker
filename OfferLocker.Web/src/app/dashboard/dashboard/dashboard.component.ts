import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Campus } from '../models/campus'
import {Category} from '../models/category'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})

export class DashboardComponent implements OnInit{
  constructor(private router: Router) {}

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  public campusList: Campus[];
  public categoryList: Category[];

  ngOnInit(): void {
    this.campusList = [
      {
        id: '1',
        name: 'Campus1',
        description:
          'Campus1',
        backgroundImage: '../../../assets/images/undraw_gifts_btw0.png',
      },

      {
        id: '2',
        name: 'Campus2',
        description: 'Campus2',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
      },];

    this.categoryList = [
        {
          id: '1',
          name: 'Categoria1',
          description:
            'Campus1',
          backgroundImage: '../../../assets/images/undraw_gifts_btw0.png',
        },

        {
          id: '2',
          name: 'Categoria2',
          description: 'Campus2',
          backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        },
    ];
  }

  goToCampus(id:string) : void{
    console.log(id);
    this.router.navigate(['/campus/details']);
  }

  goToCategory(id:string) : void{
    console.log(id);
    this.router.navigate(['/category/details']);
  }
}
