import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  redirectToLogin() {
    this.router.navigate(['/login']);
  }

  submit(): void {
    if (this.form.valid) {
      this.http.post('https://helpdesk-umvwhfsykq-uc.a.run.app/register', this.form.value)
        .subscribe(() => {
          this.router.navigate(['/login']);
        });
    }
  }
}
