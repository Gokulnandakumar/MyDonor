import { AccountsService } from './../../services/accounts.service';
import { Component, OnInit } from '@angular/core';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-profile',
  templateUrl: './customer-profile.component.html',
  styleUrls: ['./customer-profile.component.css']
})
export class CustomerProfileComponent implements OnInit {

  profile = {
    name: '',
    email: '',
    phone: '',
    address: ''
  }

  constructor(private service: AccountsService, private tokenHelper: TokenHelper, private router: Router) { }

  logout() {
    this.tokenHelper.removeToken();
    this.router.navigate(['/']);
  }
  setProfile(){
    this.router.navigate(['/customer/profile/edit/:id']);
  }
  ngOnInit(): void {

    this.service.getProfile().subscribe({
      next: (response: any) => {
        this.profile.name = response.name;
        this.profile.email = response.email;
        this.profile.phone = response.phone;
        this.profile.address = response.adress;
      }
    })
  }
}