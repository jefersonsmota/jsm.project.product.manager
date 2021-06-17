import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Output() logoutAction = new EventEmitter();


  constructor() { 
  }

  ngOnInit(): void {
  }

  logout(): void {
    this.logoutAction.emit();
  }

}
