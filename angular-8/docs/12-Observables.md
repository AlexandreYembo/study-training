### 12-Observables
Basically observables is a feature added by some other third-party package, not by Angular, by ```heavilly``` used by Angular which allow you to easily work with asynchronous tasks.

So an observable is an easy way to subscribe to some event which might happen in the future, to then execute some code when it happens without having to wait for it now.

#### What is an Observable?
- Various Data Sources (User input) Events, Http Requests, Triggered in code, etc.

- There is a observable pattern where there is a observable and an observer. In between, there is stream timeline, there are few events emitted by an observable or data package emitted by an observable. It depends on the datasource (could be connected with a button event, or Http requests, etc).

- Observer -> this is the subscribe function. There are 3 ways of handle data package

1- Handle Data

2- Handle Error

3- Handle Completion

###### They are asyncronous task. You don't need to wait to completion of these events. 

Therefore, we need such methods of handle asyncronous tasks, you might use ```callbacks``` or ```Promises```, and it is not necessary to use them. Observable it is a different approach, alternative to handle them.

Obserables are constructs to which you subscribe to be informed when there is any change of data, because observables are stream of data and whenever a new data piece is emitted, the subscription will know about it.



#### Example of subscribe
```rxjs``` is a package to use observable. This is not native from javascript nor typescript.

```ts
import { interval } from 'rxjs';

export class MyObservableComponent implements OnInit {
    constructor() { }
    
    ngOnInit() {
        interval(1000).subscribe(count => {
             console.log(count);
        });
    }
}
```

You can also unsubscribe an observable by storaging the subscription:

```ts
import { interval, Subscription } from 'rxjs';
export class MyObservableComponent implements OnInit, OnDestroy {
    private firstObsSubscription: Subscription;

    ngOnInit() {
        this.firstObsSubscription = interval(1000).subscribe(count => {
             
        });
    }

    ngOnDestroy(): void {
        this.firstObsSubscription.unsubscribe();
    }
}
```

This help to prevent memory leaks.

###### Any angular observable is managed by Angular, so you don't need to subscribe since the Angular will manage the life cicle of their observables.


[Building your own customize observable](https://github.com/AlexandreYembo/study-training/blob/master/angular-8/docs/12.1-Custom-observables.md)


#### Operators
When you want to transform the data of the observable result you can use it. By calling the method ```pipe()```. Every observable has pipe method

```ts
import { map } from 'rxjs/operators'; // one of the operator.

myObservable.pipe(map((data: number) => {
    return 'Round: ' + (data + 1);; //transform your data here
})).subscribe((data => ){
    // data will return --> round: 1, round: 2 -> transformed in map declared inside pipe() method
});
```

###### You can declare many operators in the same pipe().
```ts
import { map, filter } from 'rxjs/operators'; // one of the operator.

myObservable.pipe(filter(data => { 
    return data > 0; //return true or false
    }), map((data: number) => {
    return 'Round: ' + (data + 1);; //transform your data here
})).subscribe((data => ){
    // data will return --> round: 1, round: 2 -> transformed in map declared inside pipe() method
});
```

#### Subject
You can use a better approach when emit and event. For example
```ts
activatedEmitter = new EventEmitter<boolean>();
```
for the Subject
```ts
import { Subject } from 'rxjs';

activatedEmmiter = new Subject<boolean>(); 
```
but you have to replace on the component. Rather than call ```activatedEmitter.emit(true)``` you will use:
```ts
activatedEmitter.next(true);
```
###### Subject are bit more efficient than EventEmitter. You can also use all these operators because a subject in the end is kind of an observable. So, there are a huge advantage.
You don't use subjects instead of event emitter when you are using @Output(), because subject is not suitable for that, and you will need the Angular event emitter.

Only use subjects to communicate across components, through services where in the end subscribe to somewhere.

###### If you are not subscribing to an event emitter, then it probably is an output, if you do plan to subscribe manually then it is a subject


##### Useful Resources:

Official Docs: https://rxjs-dev.firebaseapp.com/

RxJS Series: https://academind.com/learn/javascript/understanding-rxjs/

Updating to RxJS 6: https://academind.com/learn/javascript/rxjs-6-what-changed/