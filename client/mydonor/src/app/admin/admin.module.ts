import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { StockviewComponent } from './stockview/stockview.component';
import { AdminNavbarComponent } from './admin-navbar/admin-navbar.component';
import { ManagerRegistrationComponent } from './manager-registration/manager-registration.component';
import { FormsModule } from '@angular/forms';
import { AdminFeedbackviewComponent } from './admin-feedbackview/admin-feedbackview.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { AdminUsermanagementComponent } from './admin-usermanagement/admin-usermanagement.component';
import { UsersviewComponent } from './usersview/usersview.component';
import { ManagerManagementComponent } from './manager-management/manager-management.component';
import { ManagerviewComponent } from './managerview/managerview.component';
import { AdminSidebarComponent } from './admin-sidebar/admin-sidebar.component';

@NgModule({
  declarations: [
    AdminHomeComponent,
    StockviewComponent,
    AdminNavbarComponent,
    ManagerRegistrationComponent,
    AdminFeedbackviewComponent,
    AdminLayoutComponent,
    FeedbacksComponent,
    AdminUsermanagementComponent,
    UsersviewComponent,
    ManagerManagementComponent,
    ManagerviewComponent,
    AdminSidebarComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule
  ]
})
export class AdminModule { }
