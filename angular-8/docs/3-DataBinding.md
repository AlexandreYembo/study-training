# 3-DataBinding

### What is it?
Used to display the information dynamically, what is not harded coded into the template.

You could understand Databinding as communication between your type script code (Business Logic), and the template (HTML).

### How can  you do?
#### Output data by using
##### - String Interpolation:
```{{ data }}```

##### - Property binding:
``` [property]="data"```

#### React to (User) Events
##### - Event binding:
```(event)="expression```

#### Combination of Both
##### - Two-Way-Binding:
```[(ngModel)="data"]```

### String Interpolation
```ts
export class ServerComponent {
    serverId: number = 10;
    serverStatus: string = 'offline';
}
```
```html
<p>Server with ID {{ serverid }} is {{ serverStatus }}</p>
```
Any expression can result in string in the end.
```html
<p>{{ 'Server' }} with ID {{ serverid }} is {{ serverStatus }}</p>
```

### Property Binding
Square brackets indicate angular that you are using property binding.
```html
<button class="btn btn-primary" disabled>
```
instead of this you use property
```html
<button class="btn btn-primary" [disabled]="yourvariable"> <-- instead of this you use property>
```

#### Important: By default all properties of components are only accessable inside this component, not from outside.
```ts
    export class Component1 {
        myProperty: {prop1: string, prop2: string};   // Only my Component1 will have access for this property
    }
```
But If you want to change this property to be accessable in parent level, you need to add a decorator for this property. Dispite of decorator are not available for classes, in properties we can the decorator ```@Input()```:
```ts
    export class Component1 {
        @Input() myProperty: {prop1: string, prop2: string};   // Only my Component1 will have access for this property
    }
```
and import from '@angular/core' --> ``` { Input } ```

#### Assign an Alias to the property
So, when you don't want to use the same name of the property you have assing in the component outside, you can add alias:
```ts
    @Input('myPropertyNameOutside') myProperty: {prop1: string, prop2: string};
```



### String Interpolation vs Property Binding
#### For string interpolation you can show a dynamic label:
```html
<p> {{myVariable}} </p>
```
#### but you also can use property binding:
```html
<p [innerText]="myVariable"> </p>
```
If you want to bring text from your template, just use string interpolation.

If you want to change some property, be that HTML element or a directive or a component, so you can use property binding.

#### String interpolation only works in a normal template, not within another expression of that template, not within a property binding or something like this.


### Event Binding
Insteof of use ``` onclick ``` you define by using ``` (click)="myfunction()" ```

```html
    <button class="btn btn-primary"
     [disabled]="yourvariable"
     (click)="myfunction()"> </button>
```

### Passing and using Data with Event Binding
```html
    <input type="text"
    class="form-control"
    (input)="myFunction()">

```
```(input) ``` this is a normal DOM event provided by the input element.

Now to passe the value of this field, you can do by passing ```$event ```

```html
<input type="text"
    (input)="myFunction($event)>

```

```$event``` is kind of a reserved variable name. You can use in the template when using event binding.

###### Important: For this event, only between these quotation marks " ". Example: "function($event)". $event will simply be the data emitted with that event.
So, the click event gives us an object which for example holds the coordinates where we clicked and the input event also gives us some data, some information about event. Now we can capture this data with ```$event``` passed as an argument to the method we are calling or used anywhere between these quotation marks in the code we are executing.

##### Implementation
HTML
```html
    <input type="text"
    class="form-control"
    (input)="myFunction($event)">

```
Type script code
```ts
    export class MyComponent implements OnInit {
        myFunction(event: Event){
            this.value = event.target.value;
        }
    }
```
Also we can explicitly inform it about the type in TypeScript by adding ```<HTMLInputElement>```
```ts
    this.value = (<HtmlInputElement>event.target).value;
```

### Two-way-Databinding

###### Important: FormsModule is required for Two-Way-Binding! You need to enable ngModel directive. This is done by adding the FormsModule to the imports[] array in the AppModule.
###### You then also need to add the import from '@angular/forms' in the app.module.ts file:
```ts
    import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    ...
    FormsModule //declare to use [(ngModel)] for two-way binding
  ],
})
```
Two-way-Databinding basically combine propert binding and event binding. You also combine the sintax ```[(ngModel)]``` brackets and parenteses + directive ```ngModel```.

#### How to implement?
```html
    <input type="text"
           class="form-control"
           [(ngModel)]="myProperty">

```
It will trigger on the input event and update the value in our component automatically. On other hand, since it is two-way binding, it will also update the value of the input element if we change the propert value somewhere else.


### Binding to Custom Events
So, if you want to get the event from a child component to a parent you can define in the attribute component:

##### In the parent component
```html
    <my-component 
        (myEvent1)="onMyEventFunction1($event)"
        (myEvent1)="onMyEventFunction1($event)"> 
    </my-component>>
```

```ts
    // myProperty: type of object expected to get in this method.
    onMyEventFunction1(myProperty1: {prop1: string, prop2: string}){
    }

     onMyEventFunction2(myProperty2: {prop1: string, prop2: string}){
    }
```
##### In the child component
Create 2 new properties and transform them in events emitter with the same name of the event defined in the parent componentf:

```ts
    @Output() myEvent1 = new EventEmitter<{ prop1: string, prop2: string }>();
    @Output() myEvent2  = new EventEmitter<{ prop1: string, prop2: string }>();

```
where ```{ EventEmitter } ``` is imported from ```"@angular/core``` 

```EventEmitter```is used to create an event
```@Output``` is a decorator to be listenable outside.

where ```{ Output } ``` is imported from ```"@angular/core``` 

Now, in your event in child component you simply call:
```ts
    onEventCallMyFunction1(){
        this.myEvent1.emit({
            prop1: 'event1',
            prop2: 'event1'
        });
    }

     onEventCallMyFunction2(){
        this.myEvent2.emit({
            prop1: 'event2',
            prop2: 'event2'
        });
    }
```

#### Assign an Alias to custom events
If you want to assing a alias to the event:
```ts
    @Output('AliasEvent1') myEvent1 = new EventEmitter<{ prop1: string, prop2: string }>();
```
In the parent component you change for the alias:
```html
    <my-component 
        (AliasEvent1)="onMyEventFunction1($event)"> 
    </my-component>>
```