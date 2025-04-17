import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login.component';
import { ListComponent } from './mood/list.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'moods', component: ListComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];
