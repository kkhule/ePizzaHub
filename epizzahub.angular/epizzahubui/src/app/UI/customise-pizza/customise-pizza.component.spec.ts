import { Pizzas } from './../../models/pizzas';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CustomisePizzaComponent } from './customise-pizza.component';
import { GbobalEventService } from 'src/app/services/gbobal-event.service';
import { PizzaService } from 'src/app/services/pizza.service';
import { NonPizzaService } from 'src/app/services/NonPizza.service';
import { Nonpizzas } from 'src/app/models/nonpizzas';
import { PizzaSize } from 'src/app/models/pizzaSize';
import { Sauces } from 'src/app/models/sauces';
import { Toppings } from 'src/app/models/toppings';
import { of } from 'rxjs';


export const mockPizza: Pizzas =

{
  id: 1,
  name: "Margherita",
  description: "Cheese, Onion",
  price: 289,
  imageUrl: "images/margherita.jpg",
  sizeId: 1,
  isVeg: false,
  sepcialStatus: "Most Popular",
  ingredientIds: [1, 3]
};

export const mockToppings: Toppings[] =
  [
    {
      id: 1,
      name: "Cheeze",
      description: "",
      price: 5,
      isVeg: false
    }
    ,
    {
      id: 2,
      name: "Spinced Panner",
      description: "",
      price: 10,
      isVeg: false
    }
  ];

export const mockSauces: Sauces[] =
  [
    {
      id: 1,
      name: "Pesto",
      description: "",
      price: 10
    }
    ,
    {
      id: 2,
      name: "Garlic Ranch Sauce",
      description: "",
      price: 13
    }
  ];

export const mockSizes: PizzaSize[] =
  [
    {
      id: 1,
      name: "Small",
      multiplier: 1
    }
    ,
    {
      id: 2,
      name: "Medium",
      multiplier: 1.5
    }
  ];

export const mockNonPizzas: Nonpizzas[] =

  [
    {
      id: 1,
      name: "Pepsi",
      description: "Contains Caffeine",
      price: 67
    }
    ,
    {
      id: 2,
      name: "Mirinda",
      description: "Contains Caffeine",
      price: 80,
    }
  ];

describe('CustomisePizzaComponent', () => {
  let component: CustomisePizzaComponent;
  let fixture: ComponentFixture<CustomisePizzaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [CustomisePizzaComponent],
      providers: [
        GbobalEventService,
        PizzaService,
        NgbActiveModal,
        NonPizzaService
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomisePizzaComponent);
    component = fixture.componentInstance;
    component.selectedPizza = mockPizza;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call ngOnInit', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    let spygetAllPizzas = spyOn(component, "getAllPizzaSizes").and.returnValue([]);
    let spygetAllPizzaToppings = spyOn(component, "getAllPizzaToppings").and.returnValue([]);
    let spygetAllPizzaSauces = spyOn(component, "getAllPizzaSauces").and.returnValue([]);
    let spygetAllNonPizzaItems = spyOn(component, "getAllNonPizzaItems").and.returnValue([]);
    component.ngOnInit();
    expect(component.pizzaSizes$).toEqual([]);
    expect(component.pizzaToppings$).toEqual([]);
    expect(component.pizzaSauces$).toEqual([]);
    expect(component.nonPizzaItems$).toEqual([]);
  })

  it('should call getAllPizzaSizes and get response as array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllPizzaSizes").and.callFake(() => {
      return of(mockSizes);
    });
    component.getAllPizzaSizes();
    expect(component.pizzaSizes$).toEqual(mockSizes);
  });

  it('should call getAllPizzaSizes and get response as empty array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllPizzaSizes").and.callFake(() => {
      return of([]);
    });
    component.getAllPizzaSizes();
    expect(component.pizzaSizes$).toEqual([]);
  });

  it('should call getAllPizzaToppings and get response as array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllToppings").and.callFake(() => {
      return of(mockToppings);
    });
    component.getAllPizzaToppings();
    expect(component.pizzaToppings$).toEqual(mockToppings);
  });

  it('should call getAllPizzaToppings and get response as empty array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllToppings").and.callFake(() => {
      return of([]);
    });
    component.getAllPizzaToppings();
    expect(component.pizzaToppings$).toEqual([]);
  });

  it('should call getAllPizzaSauces and get response as array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllSauces").and.callFake(() => {
      return of(mockSauces);
    });
    component.getAllPizzaSauces();
    expect(component.pizzaSauces$).toEqual(mockSauces);
  });

  it('should call getAllPizzaSauces and get response as empty array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(PizzaService);
    let spygetAllPizzas = spyOn(service, "getAllSauces").and.callFake(() => {
      return of([]);
    });
    component.getAllPizzaSauces();
    expect(component.pizzaSauces$).toEqual([]);
  });

  it('should call getAllNonPizzaItems and get response as array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(NonPizzaService);
    let spygetAllPizzas = spyOn(service, "getAllNonPizzaItems").and.callFake(() => {
      return of(mockNonPizzas);
    });
    component.getAllNonPizzaItems();
    expect(component.nonPizzaItems$).toEqual(mockNonPizzas);
  });

  it('should call getAllNonPizzaItems and get response as empty array', () => {
    const fixture = TestBed.createComponent(CustomisePizzaComponent);
    const component = fixture.debugElement.componentInstance;
    component.selectedPizza = mockPizza;
    const service = fixture.debugElement.injector.get(NonPizzaService);
    let spygetAllPizzas = spyOn(service, "getAllNonPizzaItems").and.callFake(() => {
      return of([]);
    });
    component.getAllNonPizzaItems();
    expect(component.nonPizzaItems$).toEqual([]);
  });

});
