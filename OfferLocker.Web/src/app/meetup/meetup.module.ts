import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MeetupRoutingModule } from './meetup-routing.module';
import { CreateComponent } from './create/create.component';
import { MeetupDetailsComponent } from './meetup-details/meetup-details.component';
import { MeetupListComponent } from './meetup-list/meetup-list.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [CreateComponent, MeetupDetailsComponent, MeetupListComponent],
  imports: [
    CommonModule,
    MeetupRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  exports: [MeetupDetailsComponent, MeetupListComponent]
})
export class MeetupModule { }
