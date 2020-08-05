import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

import { Offer } from '../models/offer'
@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.css']
})

export class OfferListComponent implements OnInit {

  public offerList: Offer[];
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.offerList = [
      {
        id: '1',
        name: 'Oferta1',
        description:
          'E foarte frumos aici sa mai venim. Sunt tantari dar merge',
        backgroundImage: '../../../assets/images/undraw_gifts_btw0.png',
        available: true,
        price: '$$',
      },

      {
        id: '2',
        name: 'Oferta2',
        description: 'E foarte frumos aici sa mai venim. Briza e minunata',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },

      {
        id: '3',
        name: 'Oferta3',
        description:
          'E foarte frumos aici sa mai venim. E asa frumos sa te faci una cu muntele',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },
      {
        id: '1',
        name: 'Oferta4',
        description:
          'E foarte frumos aici sa mai venim. Sunt tantari dar merge',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },

      {
        id: '2',
        name: 'Oferta5',
        description: 'E foarte frumos aici sa mai venim. Briza e minunata',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },

      {
        id: '3',
        name: 'Oferta6',
        description:
          'E foarte frumos aici sa mai venim. E asa frumos sa te faci una cu muntele',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },
      {
        id: '1',
        name: 'Oferta7',
        description:
          'E foarte frumos aici sa mai venim. Sunt tantari dar merge',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },

      {
        id: '2',
        name: 'Oferta8',
        description: 'E foarte frumos aici sa mai venim. Briza e minunata',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },

      {
        id: '3',
        name: 'Oferta9',
        description:
          'E foarte frumos aici sa mai venim. E asa frumos sa te faci una cu muntele',
        backgroundImage: '../../../assets/images/undraw_updated_resume_u4fy.png',
        available: true,
        price: '$$',
      },
    ];
  }

  goToOffer(id: string): void {
    console.log(id);
    this.router.navigate(['/offer/details']);
  }

}

