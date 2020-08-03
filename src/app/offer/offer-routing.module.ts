import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {OfferDetailsComponent} from './offer-details/offer-details.component'
import {OfferListtComponent } from './offer-listt/offer-listt.component'
const routes: Routes = [
  {
    path: 'list',
    pathMatch: 'full',
    component: OfferListtComponent,
  },
  {
    path: 'details',
    pathMatch: 'full',
    component: OfferDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OfferRoutingModule { }
