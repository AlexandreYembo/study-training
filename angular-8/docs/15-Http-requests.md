# Http Requests


### Working with Interceptor
When you use interceptor you can handle the request object before it sends the data to the server. This will apply for all actions such: POST, PUT, GET, DELETE and so on. For example you can use interceptors to add to the request header the token of the user and you do not need to add this configuration everytime you want to submit a request.

#### How to implement interceptor
You can create a file: ```myinterceptor.service.ts```
```ts
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';

export class MyInterceptorService implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler){
        //Implement your code here.
        return next.handle(req); // will allow to continue the request.
    }
}
```
Then you might have to register your interceptor on ```app.module.ts```.
```ts
    import { HTTP_INTERCEPTORS } from '@angular/common/http'

    providers:[
        {
            provider: HTTP_INTERCEPTORS, // --> This is the basically understand that every request should be intercepted by your interceptor.
            useClass: MyInterceptorService,
            multi: true // --> Allow to add multiple interceptors
        }
    ]
```

#### Manipulating Request Objects
The request object itself is imutable. So you can modifield by cloning the object.
```ts
    var modifiedRequest = req.clone({url: 'new url', 
            headers: req.headers.append()
            });
```


#### Adding new header to Request Objects to the interceptor
```ts
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';

export class MyInterceptorService implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler){
        var modifiedRequest = req.clone({
            headers: req.headers.append('Auth', 'XYZ')
        });
        return next.handle(modifiedRequest); // will allow to continue the request.
    }
}
```

#### Response interceptors
You can handle an observable.
```ts
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';

export class MyInterceptorService implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler){
        var modifiedRequest = req.clone({
            headers: req.headers.append('Auth', 'XYZ')
        });
        return next.handle(modifiedRequest) // will allow to continue the request.
        .pipe(
            tab(event) => {   // we can use pipe to handle the response on the interceptor.
                if(event.type == HttpEventType.Reponse){
                    Console.log('Response arrived, body data: );
                    console.log(event.body);
                }
        }); 
    }
}
```

#### Multiple interceptors
You can create another interceptor and you have to add in ``app.module.ts```
```ts
    import { HTTP_INTERCEPTORS } from '@angular/common/http'

    providers:[
        {  
            provider: HTTP_INTERCEPTORS, // -> this interceptor will run first
            useClass: MyInterceptorService,
            multi: true // --> Allow to add multiple interceptors
        },
         {
            provider: HTTP_INTERCEPTORS,
            useClass: MySecondInterceptorService,
            multi: true // --> Allow to add multiple interceptors
        }
    ]
```