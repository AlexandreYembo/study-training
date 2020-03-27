# Versions notation
### @ViewChild()
#### in Angular 8+
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

#### in Angular 9
You only need to add ```{ static: true }``` (if needed) but not ```{ static: false }```.


### @ContentChild()
#### in Angular 8+
``` @ContentChild('contentParagraph', {static: true}) paragraph: ElementRef; ```

The same change (add ```{ static: true }``` as a second argument) needs to be applied to ALL usages of ```@ContentChild()``` if you use the selected element inside of ```ngOnInit```.

If you DON'T use the selected element in ```ngOnInit```, set ```static: false``` instead.

### Services
#### In Angular 6+
If you're using ```Angular 6+``` (check your ```package.json```  to find out), you can provide application-wide services in a different way.

Instead of adding a service class to the ```providers[]```  array in AppModule , you can set the following config in ```@Injectable()``` :
```ts
@Injectable({providedIn: 'root'})
export class MyService { ... }
```
This is exactly the same as:
```ts
export class MyService { ... }
```
and
```ts
import { MyService } from './path/to/my.service';
 
@NgModule({
    ...
    providers: [MyService]
})
export class AppModule { ... }
```

Using this new syntax is ```completely optional```, the traditional syntax (using ```providers[]``` ) will still work. 
The "new syntax" does offer one advantage though: Services ```can be loaded lazily``` by Angular (behind the scenes) and redundant code can be removed automatically. This can lead to a better performance and loading speed - though this really only kicks in for bigger services and apps in general.