import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';

import {OfferDetailsComponent} from './offer-details/offer-details.component'
import { OfferRoutingModule } from './offer-routing.module';
import { OfferListtComponent } from './offer-listt/offer-listt.component';
import { FormsModule } from '@angular/forms';
import {Ng2SearchPipeModule} from 'ng2-search-filter';

@NgModule({
  declarations: [OfferDetailsComponent, OfferListtComponent],
  imports: [
    CommonModule,
    OfferRoutingModule,
    FormsModule,
    SharedModule,
    Ng2SearchPipeModule,
  ],
  exports: [OfferDetailsComponent, OfferListtComponent],
})
export class OfferModule { }
