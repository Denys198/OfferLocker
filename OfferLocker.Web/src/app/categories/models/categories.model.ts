import { CategoryModel } from './category';

export type CategoriesModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results: CategoryModel[];
}
