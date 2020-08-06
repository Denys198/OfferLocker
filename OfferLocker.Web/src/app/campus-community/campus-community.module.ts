import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SharedModule } from 'src/app/shared/shared.module';
import { CampusCommunityRoutingModule } from './campus-community-routing.module';
import { CampusCommunityComponent } from './campus-community.component';


@NgModule({
  declarations: [CampusCommunityComponent],
  imports: [
    CommonModule,
    CampusCommunityRoutingModule,
    RouterModule,
    SharedModule
  ],
  exports: [CampusCommunityComponent]
})
export class CampusCommunityModule { }
