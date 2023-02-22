import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  url = "https://localhost:7197/api/Accounts/customer/register";
  constructor(private http: HttpClient) { }

  signup(model: signupCreate) {
    return this.http.post<signupView>(this.url, model);
  }
}
