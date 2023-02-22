import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { FormsModule } from "@angular/forms";
import { LandingpageComponent } from './landingpage/landingpage.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { LandingNavbarComponent } from './landing-navbar/landing-navbar.component';
import { NotfoundPageComponent } from './notfound-page/notfound-page.component';
import { OtpPageComponent } from './otp-page/otp-page.component';
import { LandingSidebarComponent } from './landing-sidebar/landing-sidebar.component';
import { SignupComponent } from './signup/signup.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    LandingpageComponent,
    UserLayoutComponent,
    LoginComponent,
    LandingNavbarComponent,
    NotfoundPageComponent,
    OtpPageComponent,
    LandingSidebarComponent,
    OtpPageComponent,
    SignupComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    NgbModule,
  ]
})
export class UserModule { }
