import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminFeedbackviewComponent } from './admin-feedbackview/admin-feedbackview.component';
import { ManagerRegistrationComponent } from './manager-registration/manager-registration.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { AdminUsermanagementComponent } from './admin-usermanagement/admin-usermanagement.component';
import { ManagerManagementComponent } from './manager-management/manager-management.component';

const routes: Routes = [
  {
    path: '', component: AdminLayoutComponent, children: [
      { path: 'home', component: ManagerManagementComponent },
      { path: 'managers/register', component: ManagerRegistrationComponent },
      { path: 'feedback', component: AdminFeedbackviewComponent },
      { path: 'customer-manage', component: AdminUsermanagementComponent },
      { path: 'managers', component: ManagerManagementComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
