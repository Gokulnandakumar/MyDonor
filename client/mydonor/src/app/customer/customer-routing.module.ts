import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { BookingComponent } from './booking/booking.component';
import { CustomerFeedbackComponent } from './customer-feedback/customer-feedback.component';
import { CustomerProfileComponent } from './customer-profile/customer-profile.component';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';
import { CustomerPaymentComponent } from './customer-payment/customer-payment.component';
import { CustomerBloodPurchaseComponent } from './customer-blood-purchase/customer-blood-purchase.component';
import { CustomerProfileEditComponent } from './customer-profile-edit/customer-profile-edit.component';
import { CustomerHistoryComponent } from './customer-history/customer-history.component';

const routes: Routes = [
  {
    path: '', component: CustomerLayoutComponent, children: [
      { path: 'feedback', component: CustomerFeedbackComponent },
      { path: 'payment', component: CustomerPaymentComponent },
      { path: 'home', component: HomepageComponent },
      { path: 'profile', component: CustomerProfileComponent },
      { path: 'booking', component: BookingComponent },
      { path: 'purchase', component: CustomerBloodPurchaseComponent },
      { path: 'profile/edit/:id', component: CustomerProfileEditComponent },
      { path: 'history', component: CustomerHistoryComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
