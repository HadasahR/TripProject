import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllTripsComponent } from './comps/all-trips/all-trips.component';
import { RegisterComponent } from './comps/register/register.component';
import { LoginComponent } from './comps/login/login.component';
import { HomePageComponent } from './comps/home-page/home-page.component';
import { TripDetailsComponent } from './comps/trip-details/trip-details.component';
import { EditUserComponent } from './comps/edit-user/edit-user.component';
import { AllUsersComponent } from './comps/all-users/all-users.component';
import { UserTripComponent } from './comps/user-trip/user-trip.component';
import { UserDetailsComponent } from './comps/user-details/user-details.component';

const routes: Routes = [
  { path: 'AllTrips', component: AllTripsComponent },
  { path: 'Register', component: RegisterComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'HomePage', component: HomePageComponent },
  {
    path: 'EditUser', component: EditUserComponent
    , children: [{ path: 'userTrip', component: UserTripComponent },
    { path: 'userDetails', component: UserDetailsComponent }
    ]
  },
  { path: 'deatails/:tripId', component: TripDetailsComponent },
  { path: 'AllUsers', component: AllUsersComponent },
  { path: '', component: HomePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
