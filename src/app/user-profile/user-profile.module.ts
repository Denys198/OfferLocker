import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { UserProfileRoutingModule } from './user-profile-routing.module';
import { UserProfileComponent } from './user-profile.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [UserProfileComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    UserProfileRoutingModule,
    SharedModule
  ],
  exports: [UserProfileComponent]
})
export class UserProfileModule { }
