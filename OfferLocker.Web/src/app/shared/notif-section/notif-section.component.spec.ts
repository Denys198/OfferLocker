import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotifSectionComponent } from './notif-section.component';

describe('NotifSectionComponent', () => {
  let component: NotifSectionComponent;
  let fixture: ComponentFixture<NotifSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotifSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotifSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
