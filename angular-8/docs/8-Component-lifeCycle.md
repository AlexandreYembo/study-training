# 8-Component LifeCycle

All hook will be imported from ```"@angular/core"```

###### It is a good practice to implement interfaces for all hook.

### - ngOnChange
- Called after a bound input property changes.

- Only properties decorated with ```@input```

```ts
    export class MyComponent implements OnChange{
        ngOnChange(changes: SimpleChanges){
            ...     
        }
    }
```
```ngOnChange``` implements the interface ```OnChange```

where ```SimpleChanges``` imports from ```"@angular/core"```

SimpleChanges contains properties: currentValue, firstChange and previousValues.

### - ngOnInit
- This method gets executed once the component has been initialized. It has not been added to the DOM yet.

- Our properties can now be accessed and initialized.

- ngOnInit will run after the constructor.

```ts
    export class MyComponent implements OnInit{
        ngOnInit(){
            ...     
        }
    }
```
```ngOnInit``` implements the interface ```OnInit```

### - ngDoCheck
- Called during every change detection run.

- Also run multiple times. Actually this method will be executed a lot because this will run whenever change detection runs.

- if a property with ```@output``` render in our tamplate that will change the DOM, then ```ngDoCheck``` is a hook executed on every check Angular makes.

- Also not implement code that will affect the performance, because this hook calls multiple time.

##### Important: Not just if something changed, a lot of times ngDoCheck will run because you clicked some button which does not change anything, but still it's an event and on events Angular has to check if something changed.
So It has to check on certain triggering event like you clicked somewhere or a time firer or an observable was resolved.

### - ngAfterContentInit
- Called after content (ng-content) has been projected into view.

### - ngAfterContentChecked
- Called every time the projected content has been checked.

### - ngAfterViewInit
- Called after the component's view (and child views) has been initialized.

### - ngAfterViewChecked
- Called every time the view (and child views) have been checked.

### - ngOnDestroy
- Called once the component is about to be destroyed.

- When you use If for example, and in this condition you pass true, then you are going to remove an specific element from the DOM, this method will be executed.

- This is called before the object itself will be destroyed.
