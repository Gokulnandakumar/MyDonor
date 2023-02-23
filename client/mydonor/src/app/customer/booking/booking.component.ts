import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookingService } from 'src/app/services/booking.service';
import { DistrictService } from 'src/app/services/district.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  district: any;

  model = {
    districtid: '',
    date: new Date(),
    time: '',
    userid: ''
  };

  data: any;
  constructor(private toastr: ToastrService, private token: TokenHelper, private service: BookingService, private districtservice: DistrictService, private router: Router) { }

  checkBooking(data: any) {
    this.model.userid = this.token.getDecodedToken().nameidentifier;
    console.log(data);
    var inputDate = new Date(data.model);
    var todaysDate = new Date();
    console.log(inputDate);
    console.log(todaysDate);
    if (inputDate <= todaysDate) {
      this.toastr.error('date not possible', 'Date');
    }
    this.service.getBookings(this.model).subscribe({
      next: (Data) => {
        this.data = Data;
      },
      error: (err) => {
        console.error(err);
        this.toastr.error('error showing data', 'bookings');
      }
    })
  }

  saveData() {
    this.model.userid = this.token.getDecodedToken().nameidentifier;
    this.service.saveBookings(this.model).subscribe({
      next: (Data) => {
        this.router.navigate(['/customer/history']);
      },
      error: (err) => {
        console.error(err);
        this.toastr.error('error in booking', 'error');
      }
    })
  }

  ngOnInit() {
    this.districtservice.getDistrict().subscribe({
      next: (data) => {
        this.district = data;
        console.log(this.district);
      },
    })
  }
}
