import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from 'src/app/shared/shared.module';
import { CampusCommunityRoutingModule } from './campus-community-routing.module';

import { CampusDetailsComponent } from './campus-details/campus-details.component';
import { CampusListComponent } from './campus-list/campus-list.component';
import { CreateComponent } from './create/create.component';



@NgModule({
  declarations: [CampusDetailsComponent, CampusListComponent, CreateComponent],
  imports: [
    CommonModule,
    CampusCommunityRoutingModule,
    RouterModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [CampusDetailsComponent, CampusListComponent]
})
export class CampusCommunityModule { }
