import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule }  from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './Components/Adminpage/users/users/users.component';
import { from } from 'rxjs';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { AdminComponent } from './Components/Adminpage/Admin/admin/admin.component';
import { AdduserComponent } from './Components/Adminpage/users/adduser/adduser/adduser.component';
import { EdituserComponent } from './Components/Adminpage/users/edituser/edituser/edituser.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    PageNotFoundComponent,
    AdminComponent,
    AdduserComponent,
    EdituserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
