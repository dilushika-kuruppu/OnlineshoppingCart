import { Injectable } from "@angular/core";

declare let toastr: any;

@Injectable({
  providedIn: 'root'
})

export class ToastrService {
  constructor() { }

  confirm(message: string, okCallback: () => any) {
    toastr.confirm(message, function (e) {
      if (e) {
        okCallback();
      }
      else {
      }
    });
  }
    success(message: string){
      toastr.success(message);
  }
  error(message: string) {
    toastr.error(message);

  }
  warning(message: string) {
    toastr.warning(message);
  }
  message(message: string) {
    toastr.message(message);
  }
  

  
  
}
