import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-manager-homepage',
  templateUrl: './manager-homepage.component.html',
  styleUrls: ['./manager-homepage.component.css']
})
export class ManagerHomepageComponent implements OnInit {
  appointment: any | null;
  booking: any | null;
  constructor(private service: BookingService, private token: TokenHelper) { }

  approveAppointment(id: any) {
    console.log(id.model);
    this.service.updateAppointment(id.model).subscribe({
      next:(data)=>{
      }
    })
  }

  ngOnInit() {
    let managerid = this.token.getDecodedToken().nameidentifier;
    console.log(managerid);
    this.service.getCustomerAppointments(managerid).subscribe({
      next: (data) => {
        console.log(data);
        this.appointment = data;
      }
    })

    this.service.getCustomerBooking(managerid).subscribe({
      next:(data)=>{
        this.booking = data;
        console.log(this.booking);
      }
    })
  }
}
