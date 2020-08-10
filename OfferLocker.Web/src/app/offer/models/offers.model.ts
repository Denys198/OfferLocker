import { OfferModel } from './offer.model';

export type OffersModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results: OfferModel[];
}
