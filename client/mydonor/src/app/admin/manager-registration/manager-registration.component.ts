import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountsService } from 'src/app/services/accounts.service';
import { DistrictService } from 'src/app/services/district.service';

@Component({
  selector: 'app-manager-registration',
  templateUrl: './manager-registration.component.html',
  styleUrls: ['./manager-registration.component.css']
})
export class ManagerRegistrationComponent implements OnInit {
  password = "";
  confirmpasssword = "";
  display = false;
  data:any|null;

  model = {
    email: '',
    district: '',
    password: '',
    cpassword: ''
  };

  constructor(private service: AccountsService, private district: DistrictService,private route: Router, private toastr: ToastrService) { }

  onSubmit(form: any) {
    console.log(this.model);
    this.service.managerRegistration(this.model).subscribe({
      next: (Data) => {
        console.log(Data);
        this.toastr.success('updated','manager register');
        this.route.navigate(['/admin/home']);
      },
      error: (err) => {
        this.toastr.success('error','manager register failed');
        console.error(err);
      }
    });
  }

  storePassword(e: any) {
    this.password = e.target.attributes['ng-reflect-model'].value;
  }

  handlePassword(event: any) {
    this.confirmpasssword = event.target.attributes['ng-reflect-model'].value;
    if (this.confirmpasssword !== this.password) {
      this.display = true;
    }
    else {
      this.display = false;
    }
  }

  ngOnInit() {
    this.district.getDistricts().subscribe({
      next:(data)=>{
        this.data = data; 
        console.log(this.data);
      }
    })
  }
}