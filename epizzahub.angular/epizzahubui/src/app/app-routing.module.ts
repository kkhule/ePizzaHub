import { PizzaOrderSummaryComponent } from './UI/pizza-order-summary/pizza-order-summary.component';
import { PizzaOrderConfirmationComponent } from './UI/pizza-order-confirmation/pizza-order-confirmation.component';
import { CustomisePizzaComponent } from './UI/customise-pizza/customise-pizza.component';
import { ContactUsComponent } from './UI/contact-us/contact-us.component';
import { PizzaOrdersComponent } from './UI/pizza-orders/pizza-orders.component';
import { PageNotFoundComponent } from './UI/page-not-found/page-not-found.component';
import { HomePizzaComponent } from './UI/home-pizza/home-pizza.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'app-home-pizza', component: HomePizzaComponent },
  { path: 'app-pizza-orders', component: PizzaOrdersComponent },
  { path: 'app-customise-pizza', component: CustomisePizzaComponent },
  { path: 'app-pizza-order-summary', component: PizzaOrderSummaryComponent },
  { path: 'app-pizza-order-confirmation', component: PizzaOrderConfirmationComponent },
  { path: 'app-contact-us', component: ContactUsComponent },
  { path: '', redirectTo: '/app-home-pizza', pathMatch: 'full' },
  { path: 'app-page-not-found', component: PageNotFoundComponent },
  { path: '404', component: PageNotFoundComponent },
  { path: '**', redirectTo: '/404' }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
