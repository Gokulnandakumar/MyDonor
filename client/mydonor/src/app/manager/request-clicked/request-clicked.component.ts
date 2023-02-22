import { Component } from '@angular/core';
import { ManagerService } from 'src/app/services/manager.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-request-clicked',
  templateUrl: './request-clicked.component.html',
  styleUrls: ['./request-clicked.component.css']
})
export class RequestClickedComponent {
  data: any|null;
  district: any|null
  constructor(private toastr: ToastrService,private token: TokenHelper, private service: ManagerService) { }

  viewStock() {
    let managerId = this.token.getDecodedToken().nameidentifier;
    this.service.viewStock(managerId).subscribe({
      next: (Data) => {
        console.log(Data);
        this.data = Data;
      },
      error: (err) => {
        console.error(err);
        this.toastr.error('error ', 'error in stock');
      }
    })
  }
}
