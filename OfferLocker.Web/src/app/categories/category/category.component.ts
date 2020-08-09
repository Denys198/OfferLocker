import { OfferModel, OffersModel } from 'src/app/offer/models';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfferService } from 'src/app/offer/services/offer.service';
import { CategoryService } from '../services/category';
import { CategoryModel } from '../models/category';
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
  public category;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: CategoryService
  ) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
    });

    this.service.get(this.id).subscribe((data: CategoryModel) => {
      this.category = data;
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
