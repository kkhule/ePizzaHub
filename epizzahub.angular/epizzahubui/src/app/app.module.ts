import { NgModule, CUSTOM_ELEMENTS_SCHEMA, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModel, ValidationErrors } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import { NgbModal, NgbActiveModal, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PizzaOrdersComponent } from './UI/pizza-orders/pizza-orders.component';
import { PageNotFoundComponent } from './UI/page-not-found/page-not-found.component';
import { AppHeaderComponent } from './UI/app-header/app-header.component';
import { HomePizzaComponent } from './UI/home-pizza/home-pizza.component';
import { CustomisePizzaComponent } from './UI/customise-pizza/customise-pizza.component';
import { ContactUsComponent } from './UI/contact-us/contact-us.component';
import { AppContentComponent } from './UI/app-content/app-content.component';
import { PizzaOrderConfirmationComponent } from './UI/pizza-order-confirmation/pizza-order-confirmation.component';
import { PizzaOrderSummaryComponent } from './UI/pizza-order-summary/pizza-order-summary.component';

import { AppHttpInterceptorService } from './services/app-http-interceptor-.service';
import { GbobalEventService } from './services/gbobal-event.service';
import { NonPizzaService } from './services/NonPizza.service';
import { OrderService } from './services/order.service';
import { PizzaService } from './services/pizza.service';
import { GlobalVars } from './services/app.global.service';
import { GlobalErrorHandleService } from './services/global-error-handle.service';


@NgModule({
  declarations: [
    AppComponent,
    PizzaOrdersComponent,
    PageNotFoundComponent,
    AppHeaderComponent,
    HomePizzaComponent,
    CustomisePizzaComponent,
    ContactUsComponent,
    AppContentComponent,
    PizzaOrderSummaryComponent,
    PizzaOrderConfirmationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbDropdownModule,
    NgxSpinnerModule,
    ToastrModule.forRoot(
      {
        positionClass: 'toast-center-center',
        closeButton: true,
        progressBar: true,
        preventDuplicates: true,
        timeOut: 15000
      }
    )

  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    GbobalEventService,
    NonPizzaService,
    OrderService,
    PizzaService,
    GlobalVars,
    { provide: HTTP_INTERCEPTORS, useClass: AppHttpInterceptorService, multi: true },
    { provide: ErrorHandler, useClass: GlobalErrorHandleService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
