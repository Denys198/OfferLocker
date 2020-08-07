import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MeetupListComponent } from './meetup-list/meetup-list.component';
import { MeetupDetailsComponent } from './meetup-details/meetup-details.component';

const routes: Routes = [
  {
    path: 'meetup-list',
    pathMatch: 'full',
    component: MeetupListComponent,
  },
  {
    path: 'details/:id',
    pathMatch: 'full',
    component: MeetupDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MeetupRoutingModule { }
