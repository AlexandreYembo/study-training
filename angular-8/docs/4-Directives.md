# 4-Directives
### What are Directives?
Directives are instructions in the DOM.

There are directives that use template and also without template.

```html
    <p myDirective> </p>
```

```ts
    @Directive({
        selector: '[myDirective]'
    });

    export class MyDirectiveClass {
        ...
    }
```

### Using ngIf to Output Data Conditionally.
Use ngIF by declaring in HTML code using * ``` *ngIf```.

```html
    <p *nfIf="myVariableBoolean"> </p> <-- if it is true, so this element will be created in the DOM. Otherwise, there is no  in the DOM, instead of hide the element.
```

So, ngIF can add or remove item from the DOM dinamically.

To enhancing ngif with an else condition, you place a ```local reference``` on the element by using a marker ```#myLocalReference``` and change the ```<p>``` to ```<ng-template>``` as you can see in the bellow example:


```html
    <p *ngIf="myVariableBoolean; else myLocalReference">  <-- this mark 'myLocalReference' will be replaced by the ng-template >

    <ng-template #myLocalReference>
        <p>
            My text
        </p>
    </ng-template>
```

### ngStyle - Styling elements dynamically
Allows us to change the CSS style itself.

Unlike structural directives ``` <my-directive> ```, attribute directives ```<p my-directive>``` don't add or remove elements. They only change the element they were placed on.

To implement ngStyle you can use:
```html
    <p [ngStyle]="{'background-color': 'blue'}"> </p> <-- This is not property binding>
```
or

```html
    <p [ngStyle]="{backgroundColor: 'blue'}"> </p> <-- This is not property binding>
```
or you can use method:

```html
    <p [ngStyle]="{backgroundColor: getColor()}"> </p> <-- This is not property binding>
```

##### *** Important to understand that property binding is not the same as directive. It is totally different. We are binding to a property of the directive.

##### And square brackets are not part of the directive name. The directive name is just ngStyle.

##### The square brackets indicate that we want to bind to some property on this directive and this property name happens to also be ngStyle.


### ngClass - Applying Css Classes dynamically
Allows us to dynamically add or remove CSS classes.
```html
    <p [ngStyle]="{backgroundColor: getColor()}"
    [ngClass]="{myCSS: myBoolean === true }"> </p> <-- This is not property binding>
```

The code above used Javascript object and ```ngClass```. We also have key-value pairs, the keys are the CSS class names and the values are the conditions determining whether this class should be attached or not.
```
    [ngClass]="{myKey: <value: my condition>}"
```

### ngFor
Star (*) -> because this is now also a structural directive changin the DOM itself.

In the service component you add a new property
```ts
    servers = ['Element 1', 'Elemement 2']
```
``` *ngFor="let myTemporaryVariable of myArray" ```

```html
    <app-server *ngFor="let server of servers"></app-server>
```

##### Getting the index using ngFor

```html
    <div *ngFor="let item of array; let i = index"></div>
```end