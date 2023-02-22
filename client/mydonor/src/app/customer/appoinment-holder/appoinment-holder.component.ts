import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-appoinment-holder',
  templateUrl: './appoinment-holder.component.html',
  styleUrls: ['./appoinment-holder.component.css']
})
export class AppoinmentHolderComponent implements OnInit {
  appointment: any | null;
  userid = this.token.getDecodedToken().nameidentifier;
  constructor(private toastr: ToastrService,private token: TokenHelper, private service: BookingService) { }

  deleteAppointment() {
    this.service.deleteAppointments(this.userid).subscribe({
      next: (Data) => {
        this.appointment = null;
        this.toastr.success('Deleted', 'appointment');
        window.location.reload();
      },
      error: (err) => {
        console.error(err);
        this.toastr.error('error occured', 'error');
      }
    })
  }

  ngOnInit() {
    this.service.getAppointment(this.userid).subscribe({
      next: (Data) => {
        if (Data) {
          this.appointment = Data;
        }
      },
      error: (err) => {
        console.error(err);
      }
    })
  }
}
