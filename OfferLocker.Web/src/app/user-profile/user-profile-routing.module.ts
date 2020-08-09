import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserProfileComponent } from './user-profile/user-profile.component';
import { SharedModule } from 'src/app/shared/shared.module';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: UserProfileComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserProfileRoutingModule { }
