import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MeetupListComponent } from './meetup-list/meetup-list.component';
import { MeetupDetailsComponent } from './meetup-details/meetup-details.component';
import { CreateComponent } from './create/create.component';

const routes: Routes = [
  {
    path: '', // va fi /meetups 
    pathMatch: 'full',
    component: MeetupListComponent,
  },
  {
    path: '/:id', // meetups/id
    pathMatch: 'full',
    component: MeetupDetailsComponent,
  },
  {
    path: 'create', // meetups/create
    pathMatch: 'full',
    component: CreateComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MeetupRoutingModule { }
