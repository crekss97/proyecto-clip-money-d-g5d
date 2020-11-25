import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/core/models/usuario';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  loading: Boolean;
  isInvalid: Boolean = false;
  user: User;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
    ) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      name: ["", [Validators.required]],
      password: ["", [Validators.required]]
    });
  }

  async send() {

    if (this.form.valid){
      this.user = {
        Email: this.form.value.name,
        Password: this.form.value.password
      }
      const token = await this.authService.login(this.user);
      if (token !== 'Usuario y/o contraseña incorrectos.'){
        this.authService.setCurrentUser(token);
        this.router.navigateByUrl("/home")
      }
      else{
        alert(token);
      }
    }
  }

  // Getters
  get nameField() {
    return this.form.get("name");
  }
  get passwordField() {
    return this.form.get("password");
  }

  // Getters Validations
  get nameFieldValid() {
    return this.nameField.hasError("required") && this.nameField.touched;
  }
  get passwordFieldValid() {
    return this.passwordField.errors && this.passwordField.touched;
  }

}
