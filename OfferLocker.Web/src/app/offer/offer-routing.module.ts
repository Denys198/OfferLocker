import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OfferDetailsComponent } from './offer-details/offer-details.component';
import { OfferListComponent } from './offer-list/offer-list.component';
import { CreateComponent } from './create/create.component';
import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
    path: 'offer-list',
    pathMatch: 'full',
    component: OfferListComponent,
  },
  {
    path: 'details/:id',
    pathMatch: 'full',
    component: OfferDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OfferRoutingModule { }
