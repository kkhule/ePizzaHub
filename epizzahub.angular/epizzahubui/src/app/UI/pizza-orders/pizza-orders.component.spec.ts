/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PizzaOrdersComponent } from './pizza-orders.component';

describe('PizzaOrdersComponent', () => {
  let component: PizzaOrdersComponent;
  let fixture: ComponentFixture<PizzaOrdersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PizzaOrdersComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PizzaOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
