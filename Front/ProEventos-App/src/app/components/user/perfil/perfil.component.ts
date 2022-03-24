import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;
  constructor(private fb:FormBuilder) { }
  get f(): any {
  return this.form.controls;
  }
  ngOnInit() {
    this.validation();
  }

  private validation(): void{

    const formOption: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group({
    titulo:['', Validators.required],
    primeiroNome:['', Validators.required],
    ultimoNome:['', Validators.required],
    email:['',
     [Validators.required, Validators.email]],
    telefone:['', Validators.required],
    funcao:['', Validators.required],
    descricao:['', Validators.required],
    senha:['',
    [Validators.required, Validators.minLength(6)]],
    confirmeSenha:['', Validators.required],

    }, formOption);
      }

      onSubmition(): void{
        if(this.form.invalid){
          return;
        }
      }

      public resetForm(event : any): void{
        event.preventDefault();
        this.form.reset();
      }
}
