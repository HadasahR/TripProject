import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './comps/home-page/home-page.component';
import { RegisterComponent } from './comps/register/register.component';
import { LoginComponent } from './comps/login/login.component';
import { NavComponent } from './comps/nav/nav.component';
import { AllTripsComponent } from './comps/all-trips/all-trips.component';
import { TripDetailsComponent } from './comps/trip-details/trip-details.component';
import { EditUserComponent } from './comps/edit-user/edit-user.component';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MatCardImage, MatCardModule} from '@angular/material/card';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AllTypesComponent } from './comps/all-types/all-types.component';
import { AllUsersComponent } from './comps/all-users/all-users.component';
import {MatListModule} from '@angular/material/list';
import { UserTripComponent } from './comps/user-trip/user-trip.component';
import { UserDetailsComponent } from './comps/user-details/user-details.component';

@NgModule({
  declarations: [
    AppComponent,
     HomePageComponent,
    RegisterComponent,
     LoginComponent,
    NavComponent,
    AllTripsComponent,
    TripDetailsComponent,
    EditUserComponent,
    AllTypesComponent,
    TripDetailsComponent,
    AllUsersComponent,
    UserTripComponent,
    UserDetailsComponent
      ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule, 
    FormsModule,
     ReactiveFormsModule,
     MatSelectModule,
     MatIconModule,
     MatButtonModule,
     MatCardModule,
     MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
