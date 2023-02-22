import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private http: HttpClient) { }
  
  url =  "https://localhost:7197/api/ManagerInfo";

  viewStock(manegarId:string){
  return this.http.get(this.url + '/' + manegarId);
  }

  viewCustomer(manegarId:string){
    return this.http.get(this.url + '/customer' + '/' + manegarId);
  }
}
