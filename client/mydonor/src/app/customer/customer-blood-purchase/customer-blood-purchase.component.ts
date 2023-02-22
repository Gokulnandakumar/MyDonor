import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-customer-blood-purchase',
  templateUrl: './customer-blood-purchase.component.html',
  styleUrls: ['./customer-blood-purchase.component.css']
})
export class CustomerBloodPurchaseComponent implements OnInit {
  value: any = 1;
  stock: any = 0;
  status = false;

  constructor(private toastr: ToastrService,private service: BookingService, private router: Router) { }

  updateQuantity(symbol: string) {
    if (symbol === '+') {
      this.value++;
    }
    else if (symbol === '-') {
      if (this.value === 1) {
        this.status = true;
      } else {
        this.value--;
      }
    }
  }

  buyBlood() {
    localStorage.setItem("quantity", this.value);
    if (this.value >= this.stock) {
      this.toastr.error('stock not present', 'stock');
    }
    if(this.stock != 0 && this.value <= this.stock){
    this.toastr.success('stock available', '');      
    this.router.navigate(['/customer/payment']);
    }
  }
  ngOnInit() {
    let bloodId = localStorage.getItem('bloodId');
    let district = localStorage.getItem('districtid');
    this.service.getStock(bloodId, district).subscribe({
      next: (Data) => {
        this.stock = Data;
      }
    })
  }
}
