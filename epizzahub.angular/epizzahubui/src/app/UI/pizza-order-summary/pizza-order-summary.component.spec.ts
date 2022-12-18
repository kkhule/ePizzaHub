import { of } from 'rxjs';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PizzaOrderSummaryComponent } from './pizza-order-summary.component';
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { OrderService } from 'src/app/services/order.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GlobalVars } from 'src/app/services/app.global.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Order } from 'src/app/models/order';
import { Observable } from 'rxjs';

let mockOrders: Order[] =
  [
    {
      id: 4,
      userId: 1,
      orderDate: new Date(),
      pizza: {
        id: 1,
        name: "Margherita",
        price: 289,
        sizeId: 1,
        isVeg: true,
        imageUrl: "http://localhost:5000/images/margherita.jpg",
        description: "Cheese, Onion",
        sepcialStatus: "Most Popular",
        ingredientIds: [
          1,
          3
        ]
      },
      pizzaToppings: [
        {
          id: 1,
          name: "Cheese",
          description: "",
          price: 5,
          isVeg: true
        },
        {
          id: 3,
          name: "Onion",
          description: "",
          price: 6,
          isVeg: true
        },
        {
          id: 0,
          name: "Extra Cheese",
          description: "",
          price: 5,
          isVeg: true
        }
      ],
      pizzaSauces: [
        {
          id: 1,
          name: "Pesto",
          description: "",
          price: 5
        }
      ],
      nonPizzas: [
        {
          id: 4,
          name: "Choco Sundae",
          description: "Choco Sundae Cup (100 ml)",
          price: 29
        }
      ],
      totalPrice: 339,
      numberOfPizza: 1
    }
    ,

    {
      id: 4,
      userId: 1,
      orderDate: new Date(),
      pizza: {
        id: 1,
        name: "Margherita",
        price: 289,
        sizeId: 1,
        isVeg: true,
        imageUrl: "http://localhost:5000/images/margherita.jpg",
        description: "Cheese, Onion",
        sepcialStatus: "Most Popular",
        ingredientIds: [
          1,
          3
        ]
      },
      pizzaToppings: [
        {
          id: 1,
          name: "Cheese",
          description: "",
          price: 5,
          isVeg: true
        },
        {
          id: 3,
          name: "Onion",
          description: "",
          price: 6,
          isVeg: true
        },
        {
          id: 0,
          name: "Extra Cheese",
          description: "",
          price: 5,
          isVeg: true
        }
      ],
      pizzaSauces: [
        {
          id: 1,
          name: "Pesto",
          description: "",
          price: 5
        }
      ],
      nonPizzas: [
        {
          id: 4,
          name: "Choco Sundae",
          description: "Choco Sundae Cup (100 ml)",
          price: 29
        }
      ],
      totalPrice: 339,
      numberOfPizza: 1
    }

  ];

export const mockOrderConfirmation: boolean = false;

export const mockGlobalVars: GlobalVars = new GlobalVars();
mockGlobalVars.appName = "ePizzaHub";
mockGlobalVars.userid = 1;

describe('PizzaOrderSummaryComponent', () => {
  let component: PizzaOrderSummaryComponent;
  let fixture: ComponentFixture<PizzaOrderSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [PizzaOrderSummaryComponent],
      providers: [
        GbobalEventService,
        OrderService,
        NgbActiveModal,
        { provide: GlobalVars, useValue: mockGlobalVars }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PizzaOrderSummaryComponent);
    component = fixture.componentInstance;
    component.isOrderConfirmation = mockOrderConfirmation;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call ngOnInit', () => {
    const fixture = TestBed.createComponent(PizzaOrderSummaryComponent);
    const component = fixture.debugElement.componentInstance;
    let spyloadMyOrders = spyOn(component, "loadMyOrders").and.returnValue([]);
    component.ngOnInit();
    expect(component.myOrders$).toEqual([]);
  })

  it('should call loadMyOrders and get response as array', () => {
    const fixture = TestBed.createComponent(PizzaOrderSummaryComponent);
    const component = fixture.debugElement.componentInstance;
    component.isOrderConfirmation = mockOrderConfirmation;
    //component.myOrders$=mockOrders;
    //spyOn(component, "globalVars.userid").and.returnValue(1);
    const service = fixture.debugElement.injector.get(OrderService);
    //let spyloadMyOrders = spyOn(component,"loadMyOrders").and.returnValue([]);
    let spyloadMyOrders = spyOn(service, "getUserOrders").and.callFake(() => {
      return of(mockOrders);
      //Rx.of([{postId : 100}]).pipe(delay(2000));
    });
    component.loadMyOrders();
    expect(component.myOrders$).toEqual(mockOrders);
  });

  it('should call loadMyOrders and get response as empty array', () => {
    const fixture = TestBed.createComponent(PizzaOrderSummaryComponent);
    const component = fixture.debugElement.componentInstance;
    component.isOrderConfirmation = mockOrderConfirmation;
    const service = fixture.debugElement.injector.get(OrderService);
    let spyloadMyOrders = spyOn(service, "getUserOrders").and.callFake(() => {
      return of([]);
    });
    component.loadMyOrders();
    expect(component.myOrders$).toEqual([]);
  });

});
