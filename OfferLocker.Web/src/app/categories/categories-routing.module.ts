import { CategoryComponent } from './category/category.component';
import { CategoriesModule } from './categories.module';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { AllCategoriesComponent } from './all-categories/all-categories.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: AllCategoriesComponent
  }, {
    path: ':id',
    pathMatch: 'full',
    component: CategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
