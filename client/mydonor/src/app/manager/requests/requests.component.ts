import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { ManagerService } from 'src/app/services/manager.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
  customer: any;
  constructor(private token: TokenHelper, private service: ManagerService){}

  ngOnInit() {
    let managerid = this.token.getDecodedToken().nameidentifier;
    this.service.viewCustomer(managerid).subscribe({
      next:(Data)=>{
        console.log(Data);
        this.customer = Data;
      },
      error:(err)=>{
        console.error(err);
      }
    })
  }
}
