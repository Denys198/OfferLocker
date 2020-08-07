
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

  public placeholder: string = "../assets/images/placeholder.png";
  public categoryDescription: string = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

  public categoryName: string = "Electronics";

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
    this.router.navigate(['/offer/details/${id}']);
  }

}
