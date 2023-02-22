import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenHelper } from '../helpers/tokenHelper';

@Injectable({
  providedIn: 'root'
})
export class ManagerGuard implements CanActivate {
  constructor(private tokenHelper:TokenHelper, private router: Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const hasToken = this.tokenHelper.hasToken();
      let role = this.tokenHelper.getDecodedToken();
      if (!hasToken) {
        this.router.navigate(['/user/login']);
        return false;
      }
      if ( role.userrole !== "Manager" ){
        this.router.navigate(['/user/login']);
        return false;
      }
      return true;
    }
  }
