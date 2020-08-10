import { CategoryModel } from 'src/app/categories/models/category.model';

export type CategoriesModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results: CategoryModel[];
}
