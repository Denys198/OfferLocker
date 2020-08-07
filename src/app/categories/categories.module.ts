import { CategoryComponent } from './category/category.component';
import { AllCategoriesComponent } from './all-categories/all-categories.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';

import { CategoriesRoutingModule } from './categories-routing.module';


@NgModule({
  declarations: [AllCategoriesComponent, CategoryComponent],
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    SharedModule
  ],
  exports: [AllCategoriesComponent, CategoryComponent]
})
export class CategoriesModule { }
