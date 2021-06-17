import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AppConstants } from 'src/app/core/app.constants';
import { SignIn } from 'src/app/shared/models/auth/signIn';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
declare const notify: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  singInForm: FormGroup;
  isLoadClass: string = '';

  constructor(private authService: AuthService, private router: Router) { 
    this.singInForm = this.createForm(new SignIn());
  }

  ngOnInit(): void { 
    if(localStorage.getItem(AppConstants.USERSESSION)) {
      this.router.navigate(['/home']).then(x => x);
    }
  }

  onSubmit() {
    this.isLoad(true);
    var singIn = new SignIn();
    singIn.Username = this.singInForm.value.Username;
    singIn.Password = this.singInForm.value.Password;

    this.singInForm.disable();

    this.authService.login(singIn).pipe(first()).subscribe(data => {
      setTimeout(() => {
        localStorage.setItem(AppConstants.USERSESSION, JSON.stringify(data));
        this.router.navigate(['/home']).then(x => x);
      }, 2000);
    }, err => {
      this.isLoad(false);
      notify.error(err.error.message); 
      this.singInForm.enable();
    });
  }

  private createForm(singIn: SignIn) : FormGroup {
    return new FormGroup({
      Username: new FormControl(singIn.Username, Validators.compose([Validators.required])),
      Password: new FormControl(singIn.Password, Validators.compose([Validators.required, Validators.minLength(8)]))
    });
  }

  isLoad(show: boolean) {
    this.isLoadClass = show ? 'is-loading' : '';
  }

}
