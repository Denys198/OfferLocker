import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MeetupRoutingModule } from './meetup-routing.module';
import { MeetupComponent } from './meetup/meetup.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [MeetupComponent],
  imports: [
    CommonModule,
    MeetupRoutingModule,
    RouterModule,
    SharedModule
  ],
  exports: [MeetupComponent]
})
export class MeetupModule { }
