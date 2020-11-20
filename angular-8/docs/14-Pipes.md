# Pipes
### What are Pipes?
Pipes are features that allows to transform the output in your template.

### Examples
```ts
username = 'Alexandre'
```
```html
<p>{{username}}</p>
```
You wanna display as ```ALEXANDRE```. To do so, you use pipes:
```html
<p>{{username | uppercase}}</p>
```
It will transform the output to Uppercase

### Parametrizing Pipes
If you want to create parameter in the pipes:
```html
<p> Date = { createdOn | date:'fullDate'}
```
Multiple parameters:
```html
<p> Date = { createdOn | date:'fullDate': 2}
```

### Chain pipe
You can add multiple pipes by splitting by ```'|'``` and it is very important to follow the order, from left to right
```html
<p> Date = { createdOn | date:'fullDate' | uppercase }
```

### Building a custom pipe
Create a new file, example: ```shorte.pipe.ts```
```ts
@Pipe({
    name: 'shorten'
})
export class ShortenPipe implements PipeTransform{
    transform(value: any){
        return value.substr(0, 10);
    }
}
```
where ```PipeTransform``` is an interface and it imports from ```'@angular/core'```, and also declare the decorator: ```@Pipe``` where you can specify a name for the pipe.

And to use this pipe, needs to declarate in ```app.module.ts```:
```ts
declarations: [ShortenPipe]
```
and then
```html
<p> {{ username | shorten }} </p>
```

###### using arguments in your customized pipe
```ts
@Pipe({
    name: 'shorten'
})
export class ShortenPipe implements PipeTransform{
    transform(value: any, limit: number){
        return value.substr(0, limit);
    }
}
```
where ```limit``` is the argument
```html
<p> {{ username | shorten:10 }} </p>
```

###### using 2 arguments or more in your customized pipe
```ts
@Pipe({
    name: 'shorten'
})
export class ShortenPipe implements PipeTransform{
    transform(value: any, limit: number, anotherArg: any){
        return value.substr(0, limit);
    }
}
```
where ```limit``` is the argument and you can add as much parameters as you want, just separating in the component by ```':'```.
```html
<p> {{ username | shorten:10:true }} </p>
```

### Auto generating a Pipe
You can simply run the command ```ng g p``` and it will create the pipe and also register in ```app.module.ts```

 Filter pipe
```ts
@Pipe({
    name: 'filter'
})
export class FilterPipe implements PipeTransform{
    transform(value: any, filterString: string, propName: string): any{
        if(value.length === 0 || filterString === '')
            return value;

        const resultArray = [];

        for(const item of value){
            const resultArray = [];
            if(item[propName] === filterString){
                resultArray.push(item);
            }
        }

        return resultArray;
    }
}
```
```html
<input [(ngModel)]="filteredStatus">
<li *ngFor="let server of servers | filter:filteredStatus: 'status'"></li>
```

###### Important: WHen you are using a pipe like custom pipe with Filter for example, it will trigger the pipe every time that the user change the input of the property applied on the pipe, but once you have an array and you add new items, it won't trigger the pipe. It is good because avoids that every time the array trigger this event and it would be worst in the performance scenario. Also it would run everytime that any data changes on page.

But you can force the pipe to be triggered everytime that the data changes, but beware of this. You can simply change on pipe file, adding ```pure=false``` as parameter on the ```@Pipe``` decorator:
```ts
@Pipe({
    name: 'filter',
    pure: false //by default it is true
})
```


#### Async Pipe
```appcomponent.ts```
```ts
appStatus = new Promise((resolve, reject) =>{
    setTimeout(() = {
        resolve('stable');
    }, 2000);
});
```
```html
<p> {{appStatus}} </p>
```
it will show as ```[object object]```. This is because it is an object and promise, so we need to transform this data to string, by using ```async```
```html
<p> {{appStatus | async}} </p>
```
it will display the label after few seconds.