import { Component } from '@angular/core';
import { AccountsService } from 'src/app/services/accounts.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-feedback',
  templateUrl: './customer-feedback.component.html',
  styleUrls: ['./customer-feedback.component.css']
})
export class CustomerFeedbackComponent {
  model = {
    content: ""
  };

  constructor(private service: AccountsService,private router:Router, private token: TokenHelper,private toastr: ToastrService ) { }

  onSubmit() {
    let id = this.token.getDecodedToken().nameidentifier;
    this.service.feedbackReg(this.model, id).subscribe({
      next: (data) => {
        this.toastr.success('Feedback send', 'Feedback');
        this.router.navigate(['/customer/home']);
      },
      error:(err)=>{
        this.toastr.error('feedback not send','feedback');
      }
    })
  }
}
