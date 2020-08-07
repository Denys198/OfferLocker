import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CampusDetailsComponent } from './campus-details/campus-details.component';
import { CampusListComponent } from './campus-list/campus-list.component';

import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
    path: 'community-list',
    pathMatch: 'full',
    component: CampusListComponent,
  },
  {
    path: 'community-details/:id',
    pathMatch: 'full',
    component: CampusDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CampusCommunityRoutingModule { }
