import { MeetupModel } from './meetup.model';

export type MeetupsModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results: MeetupModel[];
};
