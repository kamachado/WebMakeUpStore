import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaseboardComponent } from './baseboard.component';

describe('BaseboardComponent', () => {
  let component: BaseboardComponent;
  let fixture: ComponentFixture<BaseboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaseboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BaseboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
