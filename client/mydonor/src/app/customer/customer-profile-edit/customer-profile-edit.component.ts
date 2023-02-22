import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountsService } from 'src/app/services/accounts.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-profile-edit',
  templateUrl: './customer-profile-edit.component.html',
  styleUrls: ['./customer-profile-edit.component.css']
})

export class CustomerProfileEditComponent implements OnInit {
  updateModel = {
    name: '',
    email: '',
    phone: '',
    adress: '',
  };
  id: string | null;
  
  constructor(private toastr: ToastrService,private router: Router, private token: TokenHelper, private service: AccountsService, private route: ActivatedRoute) {
    this.id = this.token.getDecodedToken().nameidentifier;
  }

  update() {
    this.service.updateUser(this.id as string, this.updateModel).subscribe({
      next: (Data) => {
        this.toastr.success('updated','profile');
        this.router.navigate(['/customer/profile']);
      }
    });
  }

  ngOnInit(): void {

    this.service.getProfile().subscribe({
      next: (response: any) => {
        this.updateModel.name = response.name;
        this.updateModel.email = response.email;
        this.updateModel.phone = response.phone;
        this.updateModel.adress = response.adress;
      }
    })
  }
}
