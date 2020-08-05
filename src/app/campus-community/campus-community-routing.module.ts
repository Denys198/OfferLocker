import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CampusCommunityComponent } from './campus-community.component';
import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: CampusCommunityComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CampusCommunityRoutingModule { }
