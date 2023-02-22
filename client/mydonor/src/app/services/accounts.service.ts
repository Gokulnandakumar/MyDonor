import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  url = "https://localhost:7197/api/accounts";
  feedback = "https://localhost:7197/api/Feedbacks";

  constructor(private http: HttpClient) { }

  authenticate(otp: number, userid: string | null) {
    return this.http.get(this.url + '/customer/' + userid + '/' + otp);
  }

  login(model: LoginDto) {
    return this.http.post(this.url + "/login", model);
  }

  getProfile() {
    return this.http.get(this.url + "/profile");
  }

  updateUser(id: string, model: any) {
    return this.http.put(this.url + "/" + id, model);
  }

  managerRegistration(model: any) {
    return this.http.post(this.url + "/Manager", model);
  }

  feedbackReg(model: any, id: string) {
    return this.http.post(this.feedback + "/" + id, model);
  }

  getFeedback() {
    return this.http.get(this.url + '/admin');
  }

  updateManager(email:string, district: any){
    return this.http.post(this.url + '/ManagerUpdate', {email, district});
  }

  getCustomers(){
    return this.http.get(this.feedback + '/customers');
  }
}