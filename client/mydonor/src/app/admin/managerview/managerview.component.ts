import { Component } from '@angular/core';
import { AccountsService } from 'src/app/services/accounts.service';

@Component({
  selector: 'app-managerview',
  templateUrl: './managerview.component.html',
  styleUrls: ['./managerview.component.css']
})
export class ManagerviewComponent  {
  email = "";

  constructor(private service: AccountsService){}

  managerUpdate(){
    let district = localStorage.getItem('district');
    this.service.updateManager(this.email, district).subscribe({
      next:(data)=>{
        alert("sucess");
      }
    })
  }
}
