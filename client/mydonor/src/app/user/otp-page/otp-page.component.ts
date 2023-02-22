import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountsService } from 'src/app/services/accounts.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-otp-page',
  templateUrl: './otp-page.component.html',
  styleUrls: ['./otp-page.component.css']
})
export class OtpPageComponent {
  otp: any;

  constructor(private service: AccountsService, private router: Router, private toastr: ToastrService) { }

  validateOtp() {
    let userid: string | null = localStorage.getItem('userid');
    console.log(userid);
    this.service.authenticate(this.otp, userid).subscribe({
      next: (data) => {
        if (data) {
          this.toastr.success('otp validated', 'otp');
          this.router.navigate(['user/login']);
        }
      }, error: (err) => {
        console.error(err);
        this.toastr.error('server error','Error');
      }
    })
  }
}
