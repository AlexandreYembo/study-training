# 2-Components
Each tamplate has their own component. It is a type script class.

You need to define a decorator to create a component.
```ts
import { Component } from '@angular/core';
@Component() // <-- decorator>
export class ServerComponent 
```

When you create your new component, you have to register that the component exits. You have to register your ```@ngModule``` to tell Angular that the element difined in @ngModule is part of your new component.

In your app.module you define this register.
```ts
import { myNewComponent } from './myNewComponent/myNewComponent.componenrt'
@ngModule({
    declarations:[
        AppComponent,
        MyNewComponent // <- Your new component>
    ]
})
```

Wnen you use ```import``` you don't specify .ts extension.  The extension is add by the webpackages bundle automatically. This is a feature of Type Script.

### App.Module
Definition: Angular uses component to build web page and uses modules to bundle different pieces.


### Creating Component with the CLI
you can use this command to generate the component:
```
>: ng generate component servers

or 
>: ng g c servers
```

It will generate a folder with all files (css, html and ts) also it will register automatically in app.module.ts

# Using Html tag in your component registration
You can use html tag instead of specify an html file. You can change in myNewComponent.component.ts by change ```templateUrl``` to ```template```
```ts
@Component({
  ...
  template: '<app-server></app-server><app-server></app-server>',
  ...
})
```

### Component selector

The example below shows the selector by using ```app-server``` that means it works like css selector.
```ts
  @Component({
    selector: 'app-servers'
  });
```

But you can define ```[app-server]``` to use the attribute selector.

```ts
  @Component({
    selector: '[app-servers]'
  });
```

But after this change you need to change your html element
```html
  <app-servers> </app-servers>
```
to
```html
  <div app-servers> </div>
```

### Component by class

The example below shows the selector by using ```app-server``` that means it works like css class.
```ts
  @Component({
    selector: 'app-servers'
  });
```

But you can define ```.app-server``` to use the class.

```ts
  @Component({
    selector: '.app-servers'
  });
```

But after this change you need to change your html element
```html
  <app-servers> </app-servers>
```
to
```html
  <div class="app-servers"> </div>
```

### Important
#### you cannot use ID, this is not supported by Angular.

#### You should use ```<app-servers>``` to be unlimited.