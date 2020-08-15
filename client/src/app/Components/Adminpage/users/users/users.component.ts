import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Users } from './../../../../Models/users.class';
import { UsersService } from 'src/app/Services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public Subscription : Subscription;
  public users : Users[] = [];
  public user : Users = null;
  constructor(
    public usersService : UsersService
  ) { }

  ngOnInit() {

  }

  loadData()
  {
    this.Subscription = this.usersService.getAllUsers().subscribe((data:Users[]) => {
      this.users = data;
    }, error => {
      this.usersService.handleError(error);
    });
  }

  ngOnDestroy() {
    if(this.Subscription)
    {
      this.Subscription.unsubscribe();
    }
  }

  edituser(item: Users)
  {
    this.user = item;
  }

  deleteuser(IdUser: number)
  {
    this.Subscription = this.usersService.deleteUser(IdUser).subscribe((data : Users) => {
      this.updateDataAfterDelete(IdUser);
      alert("Xoa thanh cong");
    });
  }

  updateDataAfterDelete(IdUser: number)
  {
    for( var i = 0; i < this.users.length; i++)
    {
      if( this.users[i].IdUser == IdUser)
      {
        this.users.splice(i,1);
        break;
      }
    }
  }


}
