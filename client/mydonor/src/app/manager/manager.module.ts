import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerRoutingModule } from './manager-routing.module';
import { ManagerHomepageComponent } from './manager-homepage/manager-homepage.component';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';
import { ManagerNavbarComponent } from './manager-navbar/manager-navbar.component';
import { RequestsComponent } from './requests/requests.component';
import { RequestClickedComponent } from './request-clicked/request-clicked.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ManagerHomepageComponent,
    ManagerLayoutComponent,
    ManagerNavbarComponent,
    RequestsComponent,
    RequestClickedComponent
  ],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    FormsModule
  ]
})
export class ManagerModule { }
