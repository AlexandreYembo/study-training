# Using local references in template
Instead of use this implementation:
```html
    <input type="text" class="form-control" [(ngModel)]="myModelName">
```

You create a local reference on the element. A local reference can be placed on any HTML element, not only in input element. You only need to add ```#```:
```html
    <input type="text" class="form-control" #myVariableNameInput>
````
##### Important: This reference will hold a reference to this element, so not to the value we entered here, but to the whole HTML element with all its properties:
```html
    <button class="btn btn-primary"
    (click)="onMyEvent(myVariableNameInput)">  <-- I apply my variable I defined in input element, in my event button>
```
##### Important: This local reference can be used inside your template HTML, not in the Typescript code.
In local reference you can get access to some elements in your template (html element).
```ts
    onMyEvent(nameInput: HMTLInputElement){
        this.prop1 = nameInput.value;
    }
```