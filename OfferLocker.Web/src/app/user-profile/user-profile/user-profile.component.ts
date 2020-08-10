import { Component, OnInit } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';

import { OfferModel, OffersModel } from 'src/app/offer/models'
import { OfferService } from 'src/app/offer/services/offer.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  private routeSub: Subscription;
  public offerList: OfferModel[];
  public id: string;
  public username: string = JSON.parse(localStorage.getItem('userFullName'));

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: OfferService
  ) { }

  public ngOnInit(): void {

    this.routeSub = this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id)

      this.service.getAll().subscribe((data: OffersModel) => {
        this.offerList = data.results;
      });
    });
  }

  isCurrentUser() {
    return (JSON.parse(localStorage.getItem('userFullName')) == this.id) ? true : false;
  }

  goToOffer(id: string): void {
    console.log(id);
    this.router.navigate([`/offers/${id}`]);
  }

}
