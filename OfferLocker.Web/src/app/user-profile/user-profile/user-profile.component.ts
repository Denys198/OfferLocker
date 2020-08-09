import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { OfferModel, OffersModel } from 'src/app/offer/models'
import { OfferService } from 'src/app/offer/services/offer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  public offerList: OfferModel[];

  public placeholder: string = "assets/images/placeholder.png";
  public userDescription: string = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

  public username: string = "John Doe";

  constructor(
    private router: Router,
    private service: OfferService
  ) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: OffersModel) => {
      this.offerList = data.results;
    });
  }

  goToOffer(id: string): void {
    console.log(id);
    this.router.navigate([`/offers/${id}`]);
  }

}
