import { Component, OnInit } from '@angular/core';
import { AccountsService } from 'src/app/services/accounts.service';
import { DistrictService } from 'src/app/services/district.service';

@Component({
  selector: 'app-manager-management',
  templateUrl: './manager-management.component.html',
  styleUrls: ['./manager-management.component.css']
})
export class ManagerManagementComponent implements OnInit {
  districtid = '';
  districtdata :any|null;

  constructor(private districtservice: DistrictService,private service : AccountsService ){}

  updateManager(){
    console.log(this.districtid);
    localStorage.setItem('district', this.districtid);
  }

    ngOnInit(){
      this.districtservice.getDistrict().subscribe({
        next:(data)=>{
        this.districtdata = data;
        console.log(this.districtdata);
        },
      })
    }
}
