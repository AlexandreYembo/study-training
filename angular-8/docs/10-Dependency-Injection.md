# 10-Dependency Injection
### What are services?
Service is basically just another piece in Angular app.
    - Can act as central repository.
    - As central business unity.
    - Something you can store
    - Place where you can centralize your code. 

When you want to use in your component a service you should not create the instance of service class. Instead you should use by dependency injector.

### How to implement dependency injector

```ts
export class MyServiceClass {
    .....
}

```
Now to implement ```MyService``` by using dependency injector:
```ts
export class MyComponent {
    constructor(private myService: MyServiceClass){ }
}

```
Where ```MyServiceClass``` imports from your service folder.

and now we need to provide a service, by telling to Angular how to create it.
```ts
@Component({
    ...
    providers: [MyServiceClass]   <-- give instance for the service>
})
```

### Hierarchial Injector
When you inject the service in a specific component, so Angular nows how to create the instance of this service and also in all chidren components.

 - AppModule --> The highest possible level. The same instance of service is available ```Application-wide```. All components and directives.

 - AppComponent --> Same instance of service is available for ```all components``` (but ```not for other Services```)

##### Important: The instances do not propagate up, they only go down that tree of components. 
 
 - Any other Component --> Same instance of service is available for ```the Component and all its child components```.

##### The lowest level therefore is a single component with no child

#### How to implement in Hierarchial Level
Considering Level of ComponentParent with 2 children ComponentChildA and ComponentChildB

```ts
@Component({
    ...
    providers: [MySevice]
})
export class ComponentParent {
    constructor(private myService: MyService){}
}
```

```ts
export class ComponentChildA{
    constructor(private myService: MyServuce){}
}

export class ComponentChildB{
    constructor(private myService: MyServuce){}
}
```
So, for all children you ```have to``` remove the instance of service provider in ```@Component```, because when you keep you are saying that each Component 
will have their own  instance. But in this case we need to use the same instance accross the component, so you have to keep only the declarion on the constructor,
and use ```provider``` only in the ```parent level```.

#### Inject Service into Services.
Basically when you want to user service into a another services you have to inject this services. For this you can simply add reference of service in the 
constructor. Also to work you hbave to specify a metadata ````@Injectable()```
```ts
@Injectable() //<-- Receive other service injectable.
export class MyServiceA{
    constructor(private myServiceB: MyServiceB)
}
```
Where ```@Injectable``` imports from ```'@angular/core'```. This tells to Angular that now this service is injectable or that something can be injected in there.

You only have to use ```@Injectable``` to the ```receiving service``` (when you expect to get injectable)

### Version Notation
#### Services in Angular 6+
If you're using ```Angular 6+``` (check your ```package.json```  to find out), you can provide application-wide services in a different way.

Instead of adding a service class to the ```providers[]```  array in AppModule , you can set the following config in ```@Injectable()``` :
```ts
@Injectable({providedIn: 'root'})
export class MyService { ... }
```
This is exactly the same as:
```ts
export class MyService { ... }
```
and
```ts
import { MyService } from './path/to/my.service';
 
@NgModule({
    ...
    providers: [MyService]
})
export class AppModule { ... }
```

Using this new syntax is ```completely optional```, the traditional syntax (using ```providers[]``` ) will still work. 
The "new syntax" does offer one advantage though: Services ```can be loaded lazily``` by Angular (behind the scenes) and redundant code can be removed automatically. This can lead to a better performance and loading speed - though this really only kicks in for bigger services and apps in general.