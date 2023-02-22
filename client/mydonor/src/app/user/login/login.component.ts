import { Router } from '@angular/router';
import { AccountsService } from './../../services/accounts.service';
import { Component } from '@angular/core';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    text: string|null = "";
    model: LoginDto = {
        email: '',
        password: ''
    }

    constructor(
        private service: AccountsService,
        private router: Router,
        private tokenHelper: TokenHelper) { }

    onSubmit() {
        this.service.login(this.model).subscribe({
            next: (response: any) => {
                this.tokenHelper.setToken(response.result);
                let role = this.tokenHelper.getDecodedToken();
                if (role.userrole === "Manager") {
                    this.router.navigateByUrl('/manager/home');
                }
                else if (role.userrole === "Customer") {
                    this.router.navigateByUrl('/customer/home');
                }
            }
        })
    }
}
