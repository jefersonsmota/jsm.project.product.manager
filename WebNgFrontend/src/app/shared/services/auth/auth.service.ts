import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { ApiService } from '../api.service';
import { SignIn } from '../../models/auth/signIn';
import { AppConstants } from "src/app/core/app.constants";
import { HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private url: string = AppConstants.API_RESOURCE +  AppConstants.AUTH_RESOURCE;

    constructor(private apiService: ApiService, private router: Router,) {
        this.apiService.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    }

    login(singIn: SignIn) {
        return this.apiService.http.post<any>(this.url, JSON.stringify(singIn), { headers: this.apiService.headers }).pipe(
            map(resp => {
                return resp.data;
            }));
    }

    logout() {
        localStorage.setItem(AppConstants.USERSESSION, '');
        this.router.navigate(['/']);
    }
}
