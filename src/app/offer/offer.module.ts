import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

import { SharedModule } from 'src/app/shared/shared.module';

import { OfferDetailsComponent } from './offer-details/offer-details.component'
import { OfferRoutingModule } from './offer-routing.module';
import { OfferListComponent } from './offer-list/offer-list.component';
import { FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  declarations: [OfferDetailsComponent, OfferListComponent],
  imports: [
    CommonModule,
    OfferRoutingModule,
    FormsModule,
    SharedModule,
    Ng2SearchPipeModule,
  ],
  exports: [OfferDetailsComponent, OfferListComponent],
})
export class OfferModule { }
