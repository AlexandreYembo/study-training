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

```

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