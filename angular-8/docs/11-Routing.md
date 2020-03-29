# Routing
This is the core of a project.

### Where to register a rote?
In AppModule.ts
```ts
const appRoutes: Routes = [
    {   path: '', //<-- localhost:4200
        component: HomeComponent
    },
    {   path: 'users', //<-- localhost:4200/users
        component: UsersComponent
    }
]

```
where ```Routes```imports from ```'@angular/router'```

then you have to register the routers in your appModules
```ts
const appRoutes = ... //<-- My code above
@NgModules({
    ...
    imports:[
        ...
        RouterModule.forRoot(appRoutes); // <- forRoot: Allow us to register some routes for our main application here.
    ]
})
```

where ```RouterModule```imports from ```'@angular/router'```

Also you can see the [Implementation reference](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/src/routing/routing-start/src/app/app.module.ts)

Now in your component, you have to change directives to enable the navigation thourgh the elements:
```html
    <div>
        <app-home> </app-home>
    </div>
```
to
```html
    <div>
        <router-outlet> </router-outlet>
    </div>
```
This ```<router-outlet>``` is a special directive shipping with Angular. This simply marks the place in our document where we want the Angular router to load the component of the currently selected route.

You can navigate:
http://localhost:4200/

http://localhost:4200/servers

http://localhost:4200/users

and you can see the proper component rendering.

Also you can see the [Implementation reference](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/src/routing/routing-start/src/app/app.component.html)

### Navigating with Router links
When you implement in your navigation component ```<a href="/myRoute">``` it refreshs the page every time you click in a link.
It is not good because when you reload the page it loses the app state. So, for this you have to implement a special directive
called RouterLink.

RouteLink catches the click on the element, prevents the default which would be to send a request and instead analyses what we passed to the
routerLink directive and then parses it and checks if it finds a fitting route in our configuration which it does because we defined all the paths in ```appRoutes``` in ```AppModules.ts```.
```html
    <a routerLink="myRoute">
```
Also you can implement other way for ```routerLink```
```html
    <a [routerLink]="['myRoute']">
```
It allows you to construct more complex path very easily.

###### So, the benefits are give better use experience, it does not restart the app, therefore it keeps the app state and it is much faster than reloading the page all the time.

Also you can see the [Implementation reference](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/src/routing/routing-start/src/app/app.component.html)

When you use relative path ```mypath``` rather than absolute path ```/mypath``` it always append the path you specify in routerLink to the end of your current path and it is important the current path depends on which component you are currently on.

If you use relative paths inside of active components, active routes might be nice thing if you have nested routes.

You can see  the example [here](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/src/routing/routing-start/src/app/servers/servers.component.html)

### Styling Active Router Links
When you have nav component you want to active specific tab you are current active. For this you have to replace and use an specific directive Angular called ```routerLinkActive```:

You change:
```html
 <li role="presentation" class="active"><a routerLink="/">Home</a></li>
```
To 
```html
<li role="presentation" routerLinkActive="active"><a routerLink="/">Home</a></li>
```
Also it is important for your first nav item you have to use other special directive ```[routerLinkActiveOptions]="{exact: true}"```, that tell Angular only add the routerLink active class if the exact, the full path is only if everything is just slash ```'/'``` and not if it is only part of the path.

You can see  the example [here](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/src/routing/routing-start/src/app/servers/servers.component.html)

### Navigating Programmatically.
You can create some functionality you want to navigate after you finish a specific operator or also you can have an event that redirect you to another router. For this you can implement the follow code:
```ts
export class MyComponent{
    constructor(private router: Router){ }
    onMyNativate(){
        this.router.navigate(['/servers']);
    }
}
```
where ```router``` imports from ```'@angular/router'```

### Diferences between routerLink and Navigate Method
When you use relative path in the same component to navigate, navigate method ```this.router.navigate(['servers'])``` unlike routerLink this method does not know on which route you are currently on. The routerLink always knows in which component it sits.

But we can tell to navigate method where we currently are. So we have to pass a second argument to the navigate method to configure it.
First we have to inject type ```ActivatedRoute```  in the constructor to define our current route.
```ts
    constructor(private router: Router, private currentRoute: ActivatedRoute)

```
where ```Router``` and ```ActivatedRoute``` import from ```'@angular/router'```.

This will inject the currently active routes, so for the component you loaded, this will be the route which loaded this component and the route simply is kind of a complex Javascript object which keeps a lot of meta information about the currently active route.

and then we have to change the configuration for navigate.
```ts
    this.router.navigate(['servers'], { relativeTo: this.currentRoute });

```
relativeTo --> We define relative to which route this link should be loaded and by default, this is always the root domain.

### Passing Parameters to Routes
In appModules.ts you have to change the appRoutesConfiguration
```ts
    const appRoutes: Routes = [
        {path: 'users/:id', component: UserComponent},  // get 1 parameter: id
        {path: 'users/:id/:name', component: UserComponent}, //get 2 parameters: id and name
    ]
```
where ```:id``` is the parameter you pass in your route.

Now to fetch route parameters you have to change your component typescript.

You have to inject  ```ActivatedRoute``` and import from ```'@angular/router'```.
```ts
export class UserComponent implements onInit {
    user: {id: name, name: string };
    constructor(private currentRoute: ActivatedRoute){ }
        
    ngOnInit(){
        this.user = {
            id: this.currentRoute.snapshot.params['id'], // <- takes from route/:id
            name: this.currentRoute.snapshot.params['name'],// <- takes from route/:id/:name
        }
    }
}
```
###### Important: To avoid confusion, the ActivatedRoute object we injected will give us access to the id passed in the URL.

If you want to construct a route which is your user id and name in your component, by using ```routerLink``` we can implement the follow code:
```html
<a [routerLink]="['/users', 10, 'Ana']"> Reload users </a> <!-- /users/10/Ana -->
```
This code will change the Url but the parameters won't change. It is because when you implement in ```ngOnInit()``` the snapshot takes the parameter from the route you defined in ```appRoute``` in  ```appModule```. Basically does not re-render the component because it would cost us performance.

So, it is good that by default, it won't recreate the whole component and destroy the old one if we already are on that component.

Now, to be able to readct to subsequent changes, we need a different approach:
```ts
 ngOnInit(){
        this.user = {
            id: this.currentRoute.snapshot.params['id'], // <- takes from route/:id
            name: this.currentRoute.snapshot.params['name'],// <- takes from route/:id/:name
        }
    }
    this.route.params
        .subscribe(     //< This method will be called once the parameter change, not when you load your component.
           (params: Params) => { // < first parameters is more important. Basically whenever the parameters change.  
                                //It will be fired whenever new data is sent through that observable.
                this.user.id = params['id'];
                this.user.name = params['name'];
           }
        );
```
where ```Params``` imports from ```'@angular/router'```

we used snapshot than params before, because params is an ```observable```.

- You can check the note about Route Observable [here](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/docs/11.1-Routing-observables-note.md) 


### Observable
Bisically observablese are a feature added by some other third-party package, not by Angular, by ```heavilly``` used by Angular which allow you to easily work with asynchronous tasks.

So an observable is an easy way to subscribe to some event which might happen in the future, to then execute some code when it happens without having to wait for it now.