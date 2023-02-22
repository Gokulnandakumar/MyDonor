import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-manager-navbar',
  templateUrl: './manager-navbar.component.html',
  styleUrls: ['./manager-navbar.component.css']
})
export class ManagerNavbarComponent {
  constructor(private tokenhelper: TokenHelper, private router: Router) { }

  logout() {
    this.tokenhelper.removeToken();
    this.router.navigate(['/']);
  }
}
