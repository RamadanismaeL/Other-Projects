import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toUpper'
})
export class ToUpperPipe implements PipeTransform {

  transform(value: string, ...args: any[]): string {
    return value.toUpperCase();
  }

}
