import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CampusDetailsComponent } from './campus-details/campus-details.component';
import { CampusListComponent } from './campus-list/campus-list.component';

import { SharedModule } from 'src/app/shared/shared.module';
import { CreateComponent } from './create/create.component';

const routes: Routes = [
  {
    path: '', // communities (list)
    pathMatch: 'full',
    component: CampusListComponent,
  },
  {
    path: ':id', // communities/details/id
    pathMatch: 'full',
    component: CampusDetailsComponent,
  },
  {
    path: 'create', // communities/create
    pathMatch: 'full',
    component: CreateComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CampusCommunityRoutingModule { }
