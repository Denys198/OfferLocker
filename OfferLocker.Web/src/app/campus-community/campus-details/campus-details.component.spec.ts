import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampusDetailsComponent } from './campus-details.component';

describe('CampusDetailsComponent', () => {
  let component: CampusDetailsComponent;
  let fixture: ComponentFixture<CampusDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampusDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampusDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
