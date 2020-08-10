import { OfferModel, OffersModel } from 'src/app/offer/models';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfferService } from 'src/app/offer/services/offer.service';
import { CategoryService } from '../services/category';
import { CategoryModel } from '../models/category.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  private routeSub: Subscription;
  public offerList: OfferModel[];
  private id: string;
  public category: CategoryModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService,
    private offerService: OfferService
  ) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.categoryService.get(this.id).subscribe((data: CategoryModel) => {
      this.category = data;
    });

    this.categoryService.getOffers(this.id).subscribe((data: OffersModel) => {
      this.offerList = data.results;
    });
  }

  goToOffer(id: string): void {
    console.log(id);
    this.router.navigate(['/offers/${id}']);
  }

  getImage(name: string) {
    if (name.indexOf(' ') != -1) {
      let length = name.indexOf(' ');
      return name.substring(0, length).toLowerCase();
    }
    else return name.toLowerCase();
  }

}
