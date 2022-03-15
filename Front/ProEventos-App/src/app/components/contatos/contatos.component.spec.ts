/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { contatosComponent } from './Contatos.component';

describe('ContatosComponent', () => {
  let component: contatosComponent;
  let fixture: ComponentFixture<contatosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ contatosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(contatosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
