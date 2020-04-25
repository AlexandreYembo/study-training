# 11-Routing
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
```relativeTo``` --> We define relative to which route this link should be loaded and by default, this is always the root domain.

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

### Passing Query Parameters and Fragments
So, if you want to implement query in parameters url and fragments ```http://localhost:4200/servers/10/Anna?mode=editing#```.

where parameters is ```'?mode=editing'``` 

and fragments ```'#'``` with the hash sign to jump to a specific place in your app.

In your ```appRoute``` in ```appModule.ts``` you might change or create a new route configuration.
```ts
const appRoutes: Routes = [
     {path:'users', component: UserComponent},
    {path:'users/:id/edit', component: EditUserComponent} //< where Id is the parameter and after slash, example 'edit' to describe 
                                                    // what will happen in this component.
]
```

Then you can implement in your component a link to redirect the user to edit an specific component:
```html
<a [routerLimk]="['/users', 5, 'edit']"> <!-- 'edit' is the parameter that choose the EditUserComponent -->
```
Now to add the query parameter you might change the code above:
```html
<a [routerLimk]="['/users', 5, 'edit',]"
   [queryParams]="{allowEdit: '1'}"> <!-- 'queryParams' we can define in this javascript object a query params, defined by key-value pairs-->
```
Query Params ```[queryParams]``` is ```not a new directive```, it's just another bindable property of the ```routerLink``` directive.

Then the result: ```http://localhost:4200/users/5/edit?allowEdit=1```.

If you want to implement you might use another bindable property: ```[fragment]```.
```html
<a [routerLimk]="['/users', 5, 'edit',]"
   [queryParams]="{allowEdit: '1'}"
   fragment="'loading'"
>
```
Then the result: ```http://localhost:4200/users/5/edit?allowEdit=1#loading```.

Now for navigate method:
```ts
    this.router.navigate(
        ['/users', id, 'edit'], 
        {
            queryParams: { allowEdit: '1' }
        }, 
        fragment='loading');
```

### Retrieving Query Parameters and Fragments
First you have to inject ```ActivatedRoute``` on the constructor.
```ts
    constructor(private route: ActivatedRoute){}
```
Where ```ActivatedRoute``` imports from ```'@angular/router'```.

and in ```ngOnInit``` you can use 2 ways.
```ts
    ngOnInit(){
       var par1 = this.route.snapshot.queryParams;
       var par2 = this.route.snapshot.framgment;
    }
```
This might bring the same problem as with when we use params, because this only run or update at the time this component is created.

For the other you can also use observable:
```ts
    this.route.queryParams.subscribe();
    this.route.fragment.subscribe();
```
###### Important: You don't need to unsubscribe here, Angular will handle it for you just like it did for params.

### Child (nested) routes
You will need to change your ```appRoute``` in ```app.modules.ts``` and add a children array
```ts
const appRoutes: Routes = [
    { path: 'servers', component: ServersComponent, children:[
        { path: ':id', component: ServersComponent },
        { path: ':id/edit', component: EditServersComponent }
    ]}
]
```
Child routes of a route need a separate outlet because they can't overwrite my Component. Instead they should be loaded nested into this component.

For this, in my component I have to remove ```<app-mycomponent>``` and change for ```<router-outlet>```.

This will add a new hook which will be used on all child routes of the route being loaded the component (serversComponent) which is defined in the route ```path: 'servers', children [...]```

### Configuring the Handling of Query Parameters
When you access children route, sometimes you need to handle (preserve) query parameters to don't lose the information. For this you have to do some implementations. When using router natigate you need to add ```queryParamsHandling```.
```ts
    this.router.navigate('[edit]', {relativeTo: this.route, queryParamsHandling: 'preserve'})

```
For ```queryParamsHandling``` you can use:

- ```'merge'``` -> this merge to a old query params which any new.

- ```'preserve'``` -> keep the old query params. This will override a new query, for the old ones.

### Redirecting the user to 404 error handling
You create a new component and register the route of the new component on ```app.module.ts```
```ts
const appRoutes: Routes = [
    { path: '**', component: NotFoundComponent}
]
```
When you use ```'**'``` in route, this is the wildcard route which mean catch all paths you don't know and the order is super important here.

###### Important: Make sure that thius very generic route is the last one in your array of routes because your routes get parsed from top to bottom.
In other words, if this is defined at the beginning, you would always get redirected to ```not found ```.

### How to create a custom app module for routing?
- You can see the implementation [here](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/docs/11.2-Creating-a-route-app-module.md) 

### Guards
- You can see the documentation [here](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/docs/11.3-Guards.md) 

### Passing static data to a route.
On your route file configuration, you need to define a route passing data parameter:
```ts
  { path: 'not-found', component: YourErrorComponent, data : {message: 'Page not found!'} },
```
and on your component ts
```ts
export class YourErrorComponent implements OnInit {
  errorMessage: string;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    //this.errorMessage = this.route.snapshot.data['message']; if does not change you can use this
    this.route.data.subscribe(
      (data: Data) => {
        this.errorMessage = data['message'];
      }
    );
  }
}
```
and HTML file
```html
<h4> {{ errorMessage }} </h4>
```
Then when you pass any information that it is not found for example, it will redirect to this page passing the parameter through the data defined on Route configuration.

### Resolving Dynamic data with the resolve Guard
