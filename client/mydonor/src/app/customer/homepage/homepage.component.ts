import { Component , OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { AccountsService } from 'src/app/services/accounts.service';
import { DistrictService } from 'src/app/services/district.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit{
  users : any|null;
  district: any;
  model = {
    districtid: "",
    bloodid: ""
  }
  constructor(private router:Router, private service: DistrictService, private customer: AccountsService ){}
  
  saveData(){
   localStorage.setItem('districtid', this.model.districtid);
   localStorage.setItem('bloodId', this.model.bloodid);
   this.router.navigate(['/customer/purchase']);
  }

  ngOnInit(){
    this.service.getDistrict().subscribe({
      next:(data)=>{
      this.district = data;
      console.log(this.district);
      },
    })

    this.customer.getCustomers().subscribe({
      next:(data)=>{
      this.users = data;
      console.log(this.users);
      },
    })
  }
}
