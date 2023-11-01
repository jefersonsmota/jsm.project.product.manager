import { Injectable } from '@angular/core';
import { AppConstants } from "src/app/core/app.constants";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
      const currentUser = localStorage.getItem(AppConstants.USERSESSION);

      if(currentUser) {
        return true;
      } 
      
      this.router.navigate(['/']).then(x => x);
      return true;
  }
  
}
