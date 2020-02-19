# TypeScript Tips

### Constructor declaration in Model class
So you can define a constructor to set values in properties of a model class, by doing:
```ts
    export class Model {
        public prop1: string;
        public prop2: string
    
        constructor(prop1: string, prop2: string){
            this.prop1 = prop1;
            this.prop2 = prop2;
        }
    }
```
Alternativily you can setup in the constructor and it will automatically assign the values 
```ts
    export class Model {
        constructor(public prop1: string, public prop2: string){

        }
    }
```

### Debuging in browser.
Type script does not run on the browser, but you can debug there. Instead of there are javascripts bundles.

But we can access type scrpts file, becase javascript files support ```source maps```.

##### Souce maps
Source maps are addition the CLI adds to our bundles which allow the browser to translate or map the javascript code to typescript.

We can access those files in WebPack folder, in chrome DevTools for example.
```
    webpack:// --> . --> srcproject
```

### Generic types
In Typescript if you want to define a generic you use: ```<> ```.