import { Component, OnInit } from '@angular/core';
import { Users } from './../../../../../Models/users.class'
import { Subscription } from 'rxjs';
import { from } from 'rxjs';
import { UsersService } from 'src/app/Services/users.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css']
})
export class AdduserComponent implements OnInit {

  public users : Users[] = [];
  public Subscription : Subscription;
  public IdUser: number;
  public Usernames: string;
  public Passwords: string;
  public Phone: string;
  public Diachi: string;
  public Ngaysinh: Date;
  public Gioitinh: boolean;
  public Roles:  string;
  
  constructor(
    public usersService : UsersService,
    public routerService : Router,
  ) { }

  ngOnInit(): void {
  }


  ngOnDestroy() {
    if(this.Subscription)
    {
      this.Subscription.unsubscribe();
    }
  }

  add()
  {
    let adduser : Users = 
    {
      IdUser: this.IdUser,
      Usernames: this.Usernames,
      Passwords: this.Passwords,
      Phone: this.Phone,
      Diachi: this.Diachi,
      Ngaysinh: this.Ngaysinh,
      Gioitinh: this.Gioitinh,
      Roles: this.Roles
    };
    console.log(adduser)
    this.Subscription = this.usersService.getAdd(adduser).subscribe( data => {
      this.users.push(data);
      console.log(data);
      (<any>this.routerService).navigateById('/admin/users');
    }, error => {
        this.usersService.handleError(error);
    });

  }
}
