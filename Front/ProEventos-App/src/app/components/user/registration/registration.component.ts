import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void{
this.form = this.fb.group({
primeiroNome:['', Validators.required],
ultimoNome:['', Validators.required],
email:['',
 [Validators.required, Validators.email]],
userName:['', Validators.required],
senha:['',
[Validators.required, Validators.minLength(6)]],
confirmeSenha:['', Validators.required],

});
  }
}
