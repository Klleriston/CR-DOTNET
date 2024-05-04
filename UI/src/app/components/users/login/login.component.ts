import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  errorMessage!: string;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }
  redirectToRegister() {
    this.router.navigate(['/register']);
  }
  redirectToTickets() {
    this.router.navigate(['/tickets']);
  }

  submit(): void {
    if (this.form.valid) {
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      this.http.post<any>('https://helpdesk-umvwhfsykq-uc.a.run.app/login', this.form.value, { headers })
        .subscribe(
          (response) => {
            localStorage.setItem('token', response.token);
            this.router.navigate(['/dashboard']);
          },
          error => {
            this.errorMessage = error.error.message || 'Unknown error occurred.';
          }
        );
    } else {
      this.errorMessage = 'Please enter valid email and password.';
    }
  }
}
