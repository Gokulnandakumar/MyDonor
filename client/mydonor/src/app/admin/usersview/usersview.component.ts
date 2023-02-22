import { Component, OnInit } from '@angular/core';
import { AccountsService } from 'src/app/services/accounts.service';

@Component({
  selector: 'app-usersview',
  templateUrl: './usersview.component.html',
  styleUrls: ['./usersview.component.css']
})
export class UsersviewComponent implements OnInit {
  users:any|null;
  constructor(private service: AccountsService){}

  ngOnInit(){
    this.service.getCustomers().subscribe({
      next:(data)=>{
        this.users = data;
      }
    })
  }
}
