import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-customer-payment',
  templateUrl: './customer-payment.component.html',
  styleUrls: ['./customer-payment.component.css']
})

export class CustomerPaymentComponent {
  title = 'rough';
  unit: number|any = localStorage.getItem('quantity');
  price: number|any = this.unit * 200;
  model = {
    cardnumber: '',
    cardholder: '',
    expirydate: '',
    cvv: ''
  };

  data = {
    quantity : this.unit,
    amount : this.price,
    districtId : localStorage.getItem('districtid'),
    bloodId : localStorage.getItem('bloodId'),
    userid : this.token.getDecodedToken().nameidentifier
  }

  minDate: any = "2023-02";
  constructor( private toastr: ToastrService,private router:Router, private service: BookingService, private token: TokenHelper){}
  getDate() {
    var date = new Date();
    var toDate = date.getDate();
  }

  payment() {
    console.log(this.model);
  }
   buyBlood(){
    this.service.buy(this.data).subscribe({
      next:(Data)=>{
        this.toastr.success('payment sucess','payment');
        this.router.navigate(['/customer/home']);
      },
      error:(err)=>{
        console.error(err);
        this.toastr.error('payment failed','payment');
      }
    })
   }
}

