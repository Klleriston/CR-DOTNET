import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  constructor(public authService: AuthService, private router: Router) {}
  title = 'UI';

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

}

