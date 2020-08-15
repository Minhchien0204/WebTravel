import { Component, OnInit } from '@angular/core';
import { Users } from './../../../../Models/users.class';
import { UsersService } from './../../../../Services/users.service';
import { from } from 'rxjs';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  users: Users[] = [];

  constructor(
   private userService: UsersService 
  ) { }

  ngOnInit(): void {
  }

}
