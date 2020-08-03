import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferListtComponent } from './offer-listt.component';

describe('OfferListtComponent', () => {
  let component: OfferListtComponent;
  let fixture: ComponentFixture<OfferListtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfferListtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferListtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
