import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {OfferDetailsComponent} from './offer/offer-details/offer-details.component'
import {OfferListtComponent} from './offer/offer-listt/offer-listt.component'
import { AuthenticationComponent } from './authentication/authentication/authentication.component';
const routes: Routes = [

  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'authentication',
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  { path: 'list', component: OfferListtComponent },
  { path: 'create-offer', component: OfferDetailsComponent },
  {
    path: 'notifications',
    loadChildren: () =>
      import('./notifications/notifications.module').then(
        (m) => m.NotificationsModule
      ),
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
  },
  {
    path: 'offer',
    loadChildren: () => import('./offer/offer.module').then((m) => m.OfferModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
