import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OfferDetailsComponent } from './offer/offer-details/offer-details.component'
import { OfferListComponent } from './offer/offer-list/offer-list.component';

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
  { path: 'offer-list', component: OfferListComponent },
  { path: 'create-offer', component: OfferDetailsComponent },
  {
    path: 'notifications',
    loadChildren: () =>
      import('./notifications/notifications.module').then((m) => m.NotificationsModule),
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
  {
    path: 'user',
    loadChildren: () => import('./user-profile/user-profile.module').then((m) => m.UserProfileModule),
  },
  {
    path: 'community',
    loadChildren: () => import('./campus-community/campus-community.module').then((m) => m.CampusCommunityModule),
  },
  {
    path: 'meetup',
    loadChildren: () => import('./meetup/meetup.module').then((m) => m.MeetupModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
