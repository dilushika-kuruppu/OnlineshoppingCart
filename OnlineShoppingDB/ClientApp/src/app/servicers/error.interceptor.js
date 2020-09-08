"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
//@Injectable()
//export class ErrorIntercepetor implements HttpInterceptor {
//intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//  return next.handle(req).pipe(
//    catchError(error => {
//      if (error instanceof HttpErrorResponse) {
//        if (error.status === 401) {
//          return throwError(error.statusText);
//        }
//        const applicationerror = error.headers.get('Application-Error');
//        if (applicationerror) {
//          console.error(applicationerror);
//          return throwError(applicationerror);
//        }
//        const serverError = error.error;
//        let modelStateErrors = '';
//        if (serverError && typeof serverError === 'object') {
//          for (const key in serverError) {
//            if (serverError[key]) {
//              modelStateErrors += serverError[key] + '\n';
//            }
//          }
//        }
//        return (modelStateErrors || serverError || "Server-Error");
//      }
//    })
//  );
//}
//}
exports.ErrorInterceptorProvider = {
    provide: http_1.HTTP_INTERCEPTORS,
    //useClass: ErrorIntercepetor,
    multi: true
};
//# sourceMappingURL=error.interceptor.js.map