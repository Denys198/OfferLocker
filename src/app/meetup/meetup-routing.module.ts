import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MeetupComponent } from './meetup/meetup.component';
import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: MeetupComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetupRoutingModule { }
