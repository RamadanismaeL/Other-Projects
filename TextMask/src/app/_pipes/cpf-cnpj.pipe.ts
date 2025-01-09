import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatCpfCnpj'
})
export class CpfCnpjPipe implements PipeTransform {

  transform(value: string, type: 'cpf' | 'cnpj' | 'moz'): string {
    if (!value) return '';

    value = value.replace(/\D/g, '');

    if(type === 'cpf')
    {
      if(value.length <= 11)
      {
        return value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
      }
    }
    else if(type === 'cnpj')
    {
      if(value.length <=14)
      {
        return value.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
      }
    }
    else if(type === 'moz')
    {
      if(value.length <= 9)
      {
        return value.replace(/(\d{2})(\d{3})(\d{4})/, '$1 $2 $3');
      }
    }

    return value;
  }
}
