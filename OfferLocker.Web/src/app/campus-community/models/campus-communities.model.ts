import {CampusCommunityModel} from './campus-community.model';

export type CampusCommunitiesModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results:  CampusCommunityModel[];
}
