import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DistrictService {
url = "https://localhost:7197/api/District";
  constructor(private http: HttpClient) { }

getDistrict(){
  return this.http.get(this.url);
}  

getDistricts(){
  return this.http.get(this.url + '/registration');
}
}
