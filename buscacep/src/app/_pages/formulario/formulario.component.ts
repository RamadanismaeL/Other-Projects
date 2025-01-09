import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ViacepService } from '../../_services/viacep.service';
import { CurrencyMaskModule } from 'ng2-currency-mask'

@Component({
  selector: 'app-formulario',
  imports: [ReactiveFormsModule, CurrencyMaskModule],
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
      logradouro: [{value: '', disabled: true}],
      estado: [{value: '', disabled: true}],
      bairro: [{value: '', disabled: true}],
      cidade: [{value: '', disabled: true}],
      frete: ['', [Validators.required]]
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

  submit(){ console.log(this.form.value) }
}
