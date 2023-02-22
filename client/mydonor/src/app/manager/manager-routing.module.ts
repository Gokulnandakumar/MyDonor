import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerHomepageComponent } from './manager-homepage/manager-homepage.component';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';

const routes: Routes = [
  {
    path: '', component: ManagerLayoutComponent, children: [
      { path: 'home', component: ManagerHomepageComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagerRoutingModule { }
