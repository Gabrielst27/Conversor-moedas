import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardsPage } from './dashboard.page';

describe('Tab3Page', () => {
  let component: DashboardsPage;
  let fixture: ComponentFixture<DashboardsPage>;

  beforeEach(async () => {
    fixture = TestBed.createComponent(DashboardsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
