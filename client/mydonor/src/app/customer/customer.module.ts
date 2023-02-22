import { NgModule } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common';
import { CustomerRoutingModule } from './customer-routing.module';
import { HomepageComponent } from './homepage/homepage.component';
import { CustomerLayoutComponent } from './customer-layout/customer-layout.component';
import { CustomerNavbarComponent } from './customer-navbar/customer-navbar.component';
import { CustomerFeedbackComponent } from './customer-feedback/customer-feedback.component';
import { CustomerPaymentComponent } from './customer-payment/customer-payment.component';
import { CustomerProfileComponent } from './customer-profile/customer-profile.component';
import { CustomerProfileEditComponent } from './customer-profile-edit/customer-profile-edit.component';
import { FormsModule } from '@angular/forms';
import { CustomerBloodPurchaseComponent } from './customer-blood-purchase/customer-blood-purchase.component';
import { CustomerHistoryComponent } from './customer-history/customer-history.component';
import { AppoinmentHolderComponent } from './appoinment-holder/appoinment-holder.component';
import { HistoryHolderComponent } from './history-holder/history-holder.component';
import { CustomerSidebarComponent } from './customer-sidebar/customer-sidebar.component';
import { UserinfoHolderComponent } from './userinfo-holder/userinfo-holder.component';
import { BookingComponent } from './booking/booking.component';

@NgModule({
  declarations: [
    CustomerLayoutComponent,
    CustomerNavbarComponent,
    CustomerFeedbackComponent,
    CustomerPaymentComponent,
    CustomerProfileComponent,
    CustomerProfileEditComponent,
    HomepageComponent,
    CustomerBloodPurchaseComponent,
    CustomerHistoryComponent,
    AppoinmentHolderComponent,
    HistoryHolderComponent,
    CustomerSidebarComponent,
    UserinfoHolderComponent,
    BookingComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FormsModule
  ]
})
export class CustomerModule { }
