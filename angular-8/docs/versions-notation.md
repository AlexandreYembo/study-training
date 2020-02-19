# Versions notation

### @ViewChild() in Angular 8+
Instead of:
```ts
@ViewChild('serverContentInput') serverContentInput: ElementRef;
```
use:
```ts
    @ViewChild('serverContentInput', {static: true}) serverContentInput: ElementRef;
```
The same change (add { static: true } as a second argument) needs to be applied to ALL usages of ```@ViewChild()``` (and also ```@ContentChild()```) IF you plan on accessing the selected element inside of ```ngOnInit()```.

If you DON'T access the selected element in ```ngOnInit``` (but anywhere else in your component), set ```static: false``` instead!

### @ViewChild() in Angular 9
You only need to add ```{ static: true }``` (if needed) but not ```{ static: false }```.