
import { OfferModel, OffersModel } from 'src/app/offer/models';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfferService } from 'src/app/offer/services/offer.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  public offerList: OfferModel[];

  constructor(
    private router: Router,
    private service: OfferService
  ) { }

  ngOnInit(): void {
    this.service.getAll().subscribe((data: OffersModel) => {
      this.offerList = data.results;
    });
  }

  goToOffer(id: string): void {
    console.log(id);
    this.router.navigate(['/offers/${id}']);
  }

}
