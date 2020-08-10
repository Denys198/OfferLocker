import { OfferModel, OffersModel } from 'src/app/offer/models';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfferService } from 'src/app/offer/services/offer.service';
import { CategoryServiceService } from '../services/category.service.service';
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
  public id: string;
  public category: CategoryModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: CategoryServiceService
  ) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.service.get(this.id).subscribe((data: CategoryModel) => {
      this.category = data;
    });
  }

  goToOffer(id: string): void {
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
