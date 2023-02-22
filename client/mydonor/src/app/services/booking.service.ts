import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  url = "https://localhost:7197/api/CustomerBuyAndBookings/Customer";
  stock = "https://localhost:7197/api/CustomerBuyAndBookings";
  manager = "https://localhost:7197/api/ManagerInfo";

  constructor(private http: HttpClient) { }

  deleteAppointments(userid: string) {
    return this.http.delete(this.stock + '/' + userid);
  }

  getBookings(model: any) {
    return this.http.post(this.url + "/BookingDetail", model);
  }

  saveBookings(model: any) {
    return this.http.post(this.url + "/Booking", model)
  }

  buy(data: any) {
    return this.http.post(this.url + '/Buying', data);
  }

  getStock(bloodId: any, district: any) {
    return this.http.get(this.stock + '/' + bloodId + '/' + district);
  }

  getAppointment(userid: string) {
    return this.http.get(this.stock + '/' + 'appointment' + '/' + userid);
  }

  getCustomerAppointments(managerid:string){
    return this.http.get(this.manager + '/Approve' + '/' + managerid);
  }

  updateAppointment(id:number){
   return this.http.get(this.manager + '/Appointment/' + id);
  }

  getCustomerBooking(managerid:string){
    return this.http.get(this.manager + '/Booking/' + managerid);
  }
}
