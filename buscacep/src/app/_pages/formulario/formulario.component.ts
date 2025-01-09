import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ViacepService } from '../../_services/viacep.service';

@Component({
  selector: 'app-formulario',
  imports: [ReactiveFormsModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.scss'
})
export class FormularioComponent implements OnInit {
  form: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private viacepService: ViacepService)
  {}

  ngOnInit(): void
  {
    this.initializeForm();
    this.observePreenchimentoCep();
  }

  initializeForm()
  {
    this.form = this.fb.group({
      cep: ['', [Validators.required]],
      logradouro: ['', [Validators.required]],
      estado: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      cidade: ['', [Validators.required]]
    })
  }

  observePreenchimentoCep()
  {
    this.form.get('cep')?.valueChanges.subscribe(value => {
      if(value?.length == 8)
      {
        this.buscarCep();
      }
    })
  }

  buscarCep()
  {
    var cep = this.form.get('cep')?.value;
    this.viacepService.getEnderecoByCep(cep).subscribe({
      next: (response) => {
        this.form.patchValue({
          logradouro: response.logradouro,
          estado: response.uf,
          bairro: response.bairro,
          cidade: response.localidade
        })
      },
      error: () => {
        console.log("Erro ao buscar CEP..");
      }
    })
  }
}
