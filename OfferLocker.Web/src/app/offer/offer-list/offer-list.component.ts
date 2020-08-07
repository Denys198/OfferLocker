import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

import { OfferModel, OffersModel } from '../models'
import { OfferService } from '../services/offer.service';
@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.css'],
  providers: [OfferService],
})

export class OfferListComponent implements OnInit {

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
    this.router.navigate([`/offer/details/${id}`]);
  }

}

