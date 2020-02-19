# 1-Structure

When you create a new app, by default it creates some folders defined by Angular

- src -> Contains the source code

- app -> Define the components of my application. There are css, html, ts files for my specific component and also module file that I can register depends that will be used in my component. So, CLI will build the application and render the element by using tag <selector>. For example:
```html
    <body>
        <app-root> </app-root> <-- it is your tag defined in app.component.ts
    </body>
```
in your app.component.ts you will see this declarion
```ts
@Component({
  selector: 'app-root', // it is your tag defined inside <body> in index.html
  templateUrl: './app.component.html', // template will be rendered in this tag
  styleUrls: ['./app.component.css'] // style definition
})
```

The main.ts file is the first code executed, so the browser will create some references for index.html.

### References:
```
    -> main.ts
        --> app,module.ts
            --> app,compoenent.ts

```
 in main.ts this line is very important:
 ```ts
import { AppModule } from './app/app.module';

platformBrowserDynamic().bootstrapModule(AppModule)
 ```
 where it is passed the module as argument.

 then in app.module.ts
 ```ts
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]     // <- this call the app.compoenent.ts>
})
 ```
call the app.compoenent.ts. In this file we can see some declarations:
```ts
Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent { // <- this the class declaration used in aap.module.ts>
  name = 'This is my first App';
}

```

Afterwards, the tag <app-root> will show the proper compoenent.