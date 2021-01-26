import { AbstractControl, ValidatorFn } from '@angular/forms';

export class DateRangeValidators {

  static range(min: string, max: string): ValidatorFn {
    return (c: AbstractControl): { [key: string]: boolean } | null => {

      let minDate =  new Date(min)
      let maxDate =  new Date(max)
      if (c.value && (c.value < minDate || c.value > maxDate)) {
        return { range: true };
      }
      return null;
    };
  }
}