import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OfferDetailsComponent } from './offer/offer-details/offer-details.component';
import { OfferListComponent } from './offer/offer-list/offer-list.component';
import { CampusListComponent } from './campus-community/campus-list/campus-list.component';
import { CampusDetailsComponent } from './campus-community/campus-details/campus-details.component';
import { MeetupListComponent } from './meetup/meetup-list/meetup-list.component';
import { MeetupDetailsComponent } from './meetup/meetup-details/meetup-details.component';
import { CreateComponent } from './offer/create/create.component';

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
  {
    path: 'communities',
    loadChildren: () =>
      import('./campus-community/campus-community.module').then(
        (m) => m.CampusCommunityModule
      ),
  },
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
    path: 'offers',
    loadChildren: () =>
      import('./offer/offer.module').then((m) => m.OfferModule),
  },
  {
    path: 'user',
    loadChildren: () =>
      import('./user-profile/user-profile.module').then(
        (m) => m.UserProfileModule
      ),
  },
  {
    path: 'meetups',
    loadChildren: () =>
      import('./meetup/meetup.module').then((m) => m.MeetupModule),
  },
  {
    path: 'categories',
    loadChildren: () => import('./categories/categories.module').then((m) => m.CategoriesModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
