import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/users/login/login.component';
import { RegisterComponent } from './components/users/register/register.component';
import { TicketListComponent } from './components/tickets/ticket-list/ticket-list.component';
import { TicketCreateComponent } from './components/tickets/ticket-create/ticket-create.component';
import { TicketEditComponent } from './components/tickets/ticket-edit/ticket-edit.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'tickets', component: TicketListComponent, canActivate: [AuthGuard]  },
  { path: 'tickets/create', component: TicketCreateComponent, canActivate: [AuthGuard] },
  { path: 'tickets/:id/edit', component: TicketEditComponent,canActivate: [AuthGuard] },
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
