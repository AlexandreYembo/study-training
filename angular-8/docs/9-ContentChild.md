# 9-ContentChild
So, if we want to access a local reference from the parent in a child component 

In parent component HTML:
```html
    <app-mycontent>
        <p #myLocalReference> </p>
    </app-mycontent>
```
In the child component this reference is not accessable because the localvariable is not part of the view, it is part of the content which is why we also have separated hooks: ```contentInit``` and ```viewInit```.
 
But to be accessable you have to add in child component typescript:
```ts
    export class MyComponentChild {
        @ContentChild('myLocalReference') myProperty: ElementRef;
    }
```
where ```@ContentChild``` is imported from ```"@angular/core"```.