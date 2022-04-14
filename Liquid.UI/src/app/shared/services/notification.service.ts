import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  config: any = {
    placement: {
      from: "bottom",
      align: "center"
    },
    animate: {
      enter: 'animated fadeInDown',
      exit: 'animated fadeOutUp'
    }
  }

  constructor() {}

  error(message: string) {
   alert(`Error :${message}`)
  }

  success(message: string) {
    alert(`Success :${message}`)
  }

}
