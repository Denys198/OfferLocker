import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampusCommunityComponent } from './campus-community.component';

describe('CampusCommunityComponent', () => {
  let component: CampusCommunityComponent;
  let fixture: ComponentFixture<CampusCommunityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampusCommunityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampusCommunityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
