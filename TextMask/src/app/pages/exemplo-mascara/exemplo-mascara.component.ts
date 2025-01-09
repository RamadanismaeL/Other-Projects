import { Component, OnInit } from '@angular/core';
import { ToUpperPipe } from '../../_pipes/to-upper.pipe';
import { CpfCnpjPipe } from '../../_pipes/cpf-cnpj.pipe';

@Component({
  selector: 'app-exemplo-mascara',
  imports: [ToUpperPipe, CpfCnpjPipe],
  templateUrl: './exemplo-mascara.component.html',
  styleUrl: './exemplo-mascara.component.scss'
})
export class ExemploMascaraComponent
{

  cpf: string = '11111111111';
  cnpj: string = '11111111111111';
  text: string = 'test';
  cell: string = "849626719"
}
