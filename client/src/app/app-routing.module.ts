import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './Components/Adminpage/users/users/users.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { AdminComponent } from './Components/Adminpage/Admin/admin/admin.component';
import { AdduserComponent } from './Components/Adminpage/users/adduser/adduser/adduser.component';
import { EdituserComponent } from './Components/Adminpage/users/edituser/edituser/edituser.component';

const routes: Routes = [

  // {path: '',component:  },
  {path: 'admin' , component: AdminComponent, children:[
    { path: 'users', component: UsersComponent},
    { path: 'users/adduser', component: AdduserComponent},
    { path: 'users/:IdUser', component: EdituserComponent}
  ]
  },
  {path: '**', component: PageNotFoundComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
