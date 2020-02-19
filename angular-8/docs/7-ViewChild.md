# ViewChild

### Getting Access to the Template & DOM with @ViewChild
You defined in HTML the local reference:
```html
    <input type="text" class="form-control" #>
```
and in the Typescript code:
```ts
    export class MyComponent {
        // property and defined by the attribute @ViewChild that contains the alias defined by local reference in HTML template.
        //And this is a type of element ref. Then you can define the reference to that element: ElementRef
        @ViewChild('myVariableNameInput') myVariableNameInput: ElementRef; 
    }
```
where ```@ViewChild``` and ```ElementRef``` are from ```"@angular/core"```

In ```@ViewChild``` you have to pass the argument to work and actually this argument is a selector of the element.

if you don't want to pass as string but you want to select a component, you can defined this in the app.component for example:
```ts
    export class AppComponent {
        @ViewChild(MyComponent) myVariableNameInput; 
    }
```
where ```MyComponent``` is the child component of app.component.